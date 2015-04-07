# Command line syntax #

` ProtoMunge <descriptor type name> <input data> <output file> `

ProtoMunge takes three command line parameters - the first parameter describes the .NET type for the message, including assembly name; the second parameter is the binary file to load and the third parameter is the path to file to save the result to.

So to "munge" a message with a .NET type of `Project1.Type1` in `Assembly1.dll` against `message1.dat` and `Project2.Type2` in `Assembly2.dll` against `message2.dat` you'd use:

```
ProtoDump.exe Project1.Type1,Assembly1 message1.dat Project2.Type2,Assembly2 message2.dat
```

Note that you don't specify the file extension in the assembly name. Nested classes are indicated with "+" so you might have `Project3.ProtoWrapper+Message3,Assembly3` if you have nesting turned on.

For further details on assembly-qualified type names, see [MSDN](http://msdn.microsoft.com/en-us/library/system.type.assemblyqualifiedname.aspx).

Currently you must have the assembly containing the message type in the same directory as `ProtoMunge.exe` due to the way the type is loaded - this restriction will be removed at a later date.

# What does it do? #

I used ProtoMunge to generate the benchmark data that comes with the project. Originally the message format and data contained sensitive information. The message formats were easy enough to desensitise, just changing real field names into "field1" etc by hand. However, doing this to the sample messages themselves is much harder - in order to keep the data realistic, I wanted to make sure that the desensitised data had the same size for each field as the original. (As well as keeping the data realistic, this also means that benchmarks should be comparable between sensitive and munged data.)

# Example #

  * Follow the ProtoDump tutorial first, to get a small address book to munge
  * Copy `ProtoMunge.exe` into the current directory
  * Run `ProtoMunge.exe`
  * Run `ProtoDump.exe` to see the results

```
> copy ..\..\..\dist\ProtoMunge.exe .
> ProtoMunge.exe Google.ProtocolBuffers.Examples.AddressBook.AddressBook,AddressBook addressbook.data addressbook.munged
> ProtoDump.exe Google.ProtocolBuffers.Examples.AddressBook.AddressBook,AddressBook addressbook.munged
person {
  name: "tIcI#E=;:G"
  id: 87
  email: "F&Xaj*uN@7(o>!Tv>_\'K]C%yRZWDe\\}4"
  phone {
    number: "?x7:>bBd?jPQ"
    type: WORK
  }
  phone {
    number: "YEGMN~Z2z#\"!"
    type: HOME
  }
}
person {
  name: "./QPhc8rPD"
  id: 98
  email: ":WZ=B,qrS-x50u6]B!Cu59^S22n\"l8x("
  phone {
    number: " \\3vD=on1.LP"
    type: MOBILE
  }
  phone {
    number: "y@YR%up-NT!w"
    type: MOBILE
  }
}
```

# Current limitations #

  * ProtoMunge doesn't support non-ASCII text.
  * The assembly containing the message type must be in the same directory as `ProtoMunge.exe`