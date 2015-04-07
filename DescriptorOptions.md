# Introduction #

When generating C# source code from a `.proto` file, there are a number of options available. While the options for Java are built into protoc, those for ProtoGen are specified as extensions to the core descriptors. (Internally Protocol Buffers represents each of the elements of a .proto file - the messages, services, fields, enums etc - as Protocol Buffer messages. It's all very recursive.) The C# options are specified in http://code.google.com/p/protobuf-csharp-port/source/browse/protos/google/protobuf/csharp_options.proto csharp\_options.proto] which is in the `protos/google/protobuf` directory in the source distribution.

# Importing csharp\_options.proto #

To use the options, you have to have an appropriate import line in your `.proto` file. Currently you have to import the core `descriptor.proto` file as well, but this restriction will go away when the main project's release 2.0.3 comes out. So currently you need something like this:

```
import "google/protobuf/csharp_options.proto";
import "google/protobuf/descriptor.proto";
```

**Note**: For protoc.exe to find these files the path to the parent directory of 'google' above must be specified with the "--proto\_path=" option.

There are currently two types of options: top-level ones which apply to the whole file (file descriptor options), and ones which apply to fields within a message (field descriptor options).

# Top-level options #

Top-level options are specified outside any messages, just like the options understood by protoc. The format is a little more cumbersome though:

```
option (google.protobuf.csharp_file_options).option_name = value;
```

Only one option can be set per line, even though they are both parts of the `csharp_file_options` message. For example, it's common to set the umbrella class name and the namespace, which takes two lines like this:

```
option (google.protobuf.csharp_file_options).namespace = "MyCompany.MyProject";
option (google.protobuf.csharp_file_options).umbrella_classname = "ProjectProtos";
```

The following top-level options are supported:

| **Option** | **Type** | **Description** |
|:-----------|:---------|:----------------|
| **namespace** | String | Namespace for generated classes; defaults to the package. |
| **umbrella\_classname** | String | Name of the "umbrella" class used for metadata about all the messages within this file. Default is based on the name of the file. |
| **public\_classes** | Bool | Whether classes should be public (true) or internal (false). |
| **nest\_classes** | Bool | Whether to nest messages within a single umbrella class (true) or create the umbrella class as a peer, with messages as top-level classes in the namespace (false). |
| **code\_contracts** | Bool | Generate appropriate support for Code Contracts (Ongoing; support should improve over time) |
| **expand\_namespace\_directories** | Bool | Create subdirectories for namespaces, e.g. namespace "Foo.Bar" would generate files within {output directory}/Foo/Bar. |
| **cls\_compliance** | Bool | Generate attributes indicating non-CLS-compliance. |
| **file\_extension** | String | The extension that should be appended to the umbrella\_classname when creating files. |
| **umbrella\_namespace** | String | A nested namespace for the umbrella class.  Helpful for name collisions caused by umbrella\_classname conflicting with an existing type.  This will be automatically set to 'Proto' if a collision is detected with types being generated.  This value is ignored when nest\_classes is true. |
| **output\_directory** | String | The output path for the source file(s) generated, default is the current directory. |
| **ignore\_google\_protobuf** | Bool | Will ignore the type generations and remove dependencies for the descriptor proto files that declare their package to be "google.protobuf".  This is useful to disable the generation of CsharpOptions.cs. |

# Field options #

Field-level options are specified within a field definition, like this:

```
optional string some_field = 10 [(google.protobuf.csharp_field_options).option_name = value];
```

For example, to specify the property name explicitly you might have something like:

```
message Example {
  optional int32 delay = 10 [(google.protobuf.csharp_field_options).property_name = "DelayMs"];
}
```

The following field options are supported:

| **Option** | **Type** | **Description** |
|:-----------|:---------|:----------------|
| **property\_name** | String | Provides the ability to override the name of the property generated for this field. This is applied to all properties and methods to do with this field, including HasFoo, FooCount, FooList etc. |