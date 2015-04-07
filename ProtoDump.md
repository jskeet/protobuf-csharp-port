# Command line syntax #

ProtoDump takes two command line parameters - the first parameter describes the .NET type for the message, including assembly name; the second parameter is a path to the binary file to load and then convert to text.

So to convert a message with a .NET type of `Project1.Type1` in `Assembly1.dll` against `message1.dat` and `Project2.Type2` in `Assembly2.dll` against `message2.dat` you'd use:

```
ProtoDump.exe Project1.Type1,Assembly1 message1.dat Project2.Type2,Assembly2 message2.dat
```

Note that you don't specify the file extension in the assembly name. Nested classes are indicated with "+" so you might have `Project3.ProtoWrapper+Message3,Assembly3` if you have nesting turned on.

For further details on assembly-qualified type names, see [MSDN](http://msdn.microsoft.com/en-us/library/system.type.assemblyqualifiedname.aspx).

Currently you must have the assembly containing the message type in the same directory as `ProtoDump.exe` due to the way the type is loaded - this restriction will be removed at a later date.

# Example #

  * From the root directory, build everything
  * Go into the address book demo directory
  * Run the address book demo and create a couple of entries
  * Copy `ProtoDump.exe` to the same directory (so it can load types from this directory)
  * Run `ProtoDump.exe`

```
> nant build
(build output)
> cd src\AddressBook\bin\Debug
> AddressBook.exe
(add a couple of people)
> copy ..\..\..\..\dist\ProtoDump.exe .
> ProtoDump.exe Google.ProtocolBuffers.Examples.AddressBook.AddressBook,AddressBook addressbook.data
person {
  name: "John Smith"
  id: 1
  email: "johnsmith@protocolbufferdemo.org"
  phone {
    number: "555 12345678"
    type: HOME
  }
  phone {
    number: "555 87654321"
    type: MOBILE
  }
}
person {
  name: "Jane Smith"
  id: 2
  email: "janesmith@protocolbufferdemo.org"
  phone {
    number: "555 00000000"
    type: WORK
  }
  phone {
    number: "555 99999999"
    type: HOME
  }
}
```

# Current limitations #

  * The assembly containing the message type must be in the same directory as `ProtoDump.exe`