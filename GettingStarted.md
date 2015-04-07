# Pre-requisites #

Rather than reproduce all the documentation of the main [Google Protocol Buffers project page](http://code.google.com/p/protobuf/), I'll just reference it - so please read at least [the language guide](http://code.google.com/apis/protocolbuffers/docs/proto.html) before going any further. The rest of the wiki assumes you already know the basics of Protocol Buffers. Likewise, currently the project only works on Windows and .NET; when support is provided for Mono on other platforms, the documentation will be updated.

First, either grab the [source](http://code.google.com/p/protobuf-csharp-port/source/checkout) or a [distribution](http://code.google.com/p/protobuf-csharp-port/downloads/list). All new development is now done in Mercurial on Google Code; the previous github repository is obsolete.

If you fetched the source version, build the code. From the `build` directory, run (for a Release build for .NET 3.5):

  * `build NET35 Rebuild Release`
  * `build NET35 BuildPackage Release`

This will create a directory `build_output\Package` containing:

  * A `protos` directory with reference messages
  * A `Protoc` directory containing `protoc.exe`. This is the native executable from the [main Protocol Buffers project](http://protobuf.googlecode.com). It's always possible that other versions of `protoc.exe` will work with this project (it's just a stock build) but obviously I'm more confident in the particular version supplied, simply because I know more about it.
  * A `Release` directory containing all the release binaries:
    * `Google.ProtocolBuffers.dll` - the main library
    * `Google.ProtocolBuffersList.dll` - a lightweight version of the library with slightly less functionality, designed for constrained environments.
    * [ProtoGen.exe](ProtoGen.md) - the source code generator
    * [ProtoMunge.exe](ProtoMunge.md) - tool to remove sensitive data from binary messages
    * [ProtoDump.exe](ProtoDump.md) - tool to dump a binary message as text
    * [ProtoBench.exe](ProtoBench.md) - tool to run performance benchmarks on binary messages

# Sample application: an address book #

In-keeping with the sample provided in the main project, the C# port comes with an address book application so you can see the basics of how to get going with Protocol Buffers. The code is built as part of the normal build in the source distribution, but we'll take it step by step here.

## The .proto file ##

Let's start off with the `addressbook.proto` file which describes the messages. This lives in `protos/tutorial` in the source distribution.

```
package tutorial;
 
import "google/protobuf/csharp_options.proto";

option (google.protobuf.csharp_file_options).namespace = "Google.ProtocolBuffers.Examples.AddressBook";
option (google.protobuf.csharp_file_options).umbrella_classname = "AddressBookProtos";

option optimize_for = SPEED;

message Person {
  required string name = 1;
  required int32 id = 2;        // Unique ID number for this person.
  optional string email = 3;
 
  enum PhoneType {
    MOBILE = 0;
    HOME = 1;
    WORK = 2;
  }
 
  message PhoneNumber {
    required string number = 1;
    optional PhoneType type = 2 [default = HOME];
  }
 
  repeated PhoneNumber phone = 4;
}
 
// Our address book file is just one of these.
message AddressBook {
  repeated Person person = 1;
}
```

This is mostly just the same as the file in the main Protocol Buffers project, but there are a few tweaks:

  * The Java options have been removed, just for simplicity. (If you want a single .proto file which can generate Java code and C# code, you just need the Java options _and_ the C# options. They don't conflict at all.)
  * There's an import of `google/protobuf/csharp_options.proto` in order to use the C#-specific option extensions.
  * There are two C#-specific options specified:
    * The name of the class containing the descriptor representing the overall `.proto` file. (This is called the "umbrella" class.) The generated source file is also named after this class. In this case we're using `AddressBookProtos`.
    * The namespace to use for all the generated classes. For the address book application we're using Google.ProtocolBuffers.Examples.AddressBook.
  * The optimization flag is set to optimize for speed instead of code size. This does generate quite a lot more code, but it's a _lot_ faster.

Other options are available - see DescriptorOptions for details.

## Generating the source code ##

For simplicity, I would recommend copying protoc.exe from the Protoc directory into the Release directory; ProtoGen.exe can spot the existence of protoc.exe in the current directory (or in the path) and run it automatically. This is simpler than the old "two step" approach.

```
protogen ..\protos\tutorial\addressbook.proto 
         ..\protos\google\protobuf\csharp_options.proto 
         ..\protos\google\protobuf\descriptor.proto
         --proto_path=..\protos
```

That will create a collection of `.cs` files in the current directory. We only actually need `AddressBookProtos.cs` - the others are the dependencies (the core Protocol Buffers descriptors and the C# options). You can optionally ignore dependencies, and also specify the output directory as of version 2.3.

We'll look into ways of making this slightly simpler... in particular, protogen now allows you to specify C# options on the command line, rather than in the proto file.

**A few words of advice**
  1. Make sure that you do not use a non-ASCII encoding with your text file.  The protoc.exe compiler will complain with the following message:
```
    tutorial/addressbook.proto:1:1: Expected top-level statement (e.g. "message").
```
> > The best way to fix this is with Visual Studio.  Open the proto file and select "File" -> "Save as...".  From the save dialog click the down arrow next to the save button and select "Save with Encoding".  Select the "US-ASCII" codepage (near the bottom) and click save.
  1. It's often easiest keep all your proto files in a single directory tree.  This allows to omit the --proto\_path option by running protoc.exe from the top of the this directory tree.  Always keep the 'google/protobuf/`*`.proto' files available so that you can import them to specify options, or use the options through protogen.
  1. Unlike a programming language like `C#` it is usually expected that your proto file will specify numerous messages, not one.  Name your proto files based on the namespace, not the message.  Create proto files only as often as you would create a new namespace to organize those classes.

# Example Usage #

The following example uses the classes generated by the above proto file to perform these operations:
  1. Create a builder to construct a `Person` message
  1. Sets the field values of the builder
  1. Creates the `Person` immutable message class
  1. Writes the `Person` to a stream
  1. Creates a new `Person` from the bytes written
  1. Adds the `Person` to a new `AddressBook`
  1. Saves the `AddressBook` to bytes and recreates it
  1. Verifies the `AddressBook` contents

```
    static void Sample()
    {
        byte[] bytes;
        //Create a builder to start building a message
        Person.Builder newContact = Person.CreateBuilder();
        //Set the primitive properties
        newContact.SetId(1)
                  .SetName("Foo")
                  .SetEmail("foo@bar");
        //Now add an item to a list (repeating) field
        newContact.AddPhone(
            //Create the child message inline
            Person.Types.PhoneNumber.CreateBuilder().SetNumber("555-1212").Build()
            );
        //Now build the final message:
        Person person = newContact.Build();
        //The builder is no longer valid (at least not now, scheduled for 2.4):
        newContact = null;
        using(MemoryStream stream = new MemoryStream())
        {
            //Save the person to a stream
            person.WriteTo(stream);
            bytes = stream.ToArray();
        }
        //Create another builder, merge the byte[], and build the message:
        Person copy = Person.CreateBuilder().MergeFrom(bytes).Build();

        //A more streamlined approach might look like this:
        bytes = AddressBook.CreateBuilder().AddPerson(copy).Build().ToByteArray();
        //And read the address book back again
        AddressBook restored = AddressBook.CreateBuilder().MergeFrom(bytes).Build();
        //The message performs a deep-comparison on equality:
        if(restored.PersonCount != 1 || !person.Equals(restored.PersonList[0]))
            throw new ApplicationException("There is a bad person in here!");
    }
```