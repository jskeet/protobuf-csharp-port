# Command line syntax #

ProtoBench takes pairs of command line parameters - the first parameter describes the .NET type, including assembly name, to benchmark; the second parameter is a path to the file to benchmark against.

So to benchmark `Project1.Type1` in `Assembly1.dll` against `message1.dat` and `Project2.Type2` in `Assembly2.dll` against `message2.dat` you'd use:

```
ProtoBench.exe Project1.Type1,Assembly1 message1.dat Project2.Type2,Assembly2 message2.dat
```

Note that you don't specify the file extension in the assembly name. Nested classes are indicated with "+" so you might have `Project3.ProtoWrapper+Message3,Assembly3` if you have nesting turned on.

For further details on assembly-qualified type names, see [MSDN](http://msdn.microsoft.com/en-us/library/system.type.assemblyqualifiedname.aspx).

Currently you must have the assembly containing the message type in the same directory as `ProtoBench.exe` due to the way the type is loaded - this restriction will be removed at a later date.

_New feature under development:_ ProtoBench will soon support "benchmark scripts" - an easier way of configuring a sequence of tests. See below.

# Results #

Each type/message pair goes through the following steps:

  * Create the default message for the type
  * Load the file (so we can deserialize)
  * Build a sample message (so we can serialize)

Then six benchmarks are run:

  * Serialize to `ByteString`
  * Serialize to `byte[]`
  * Serialize to `MemoryStream`
  * Deserialize from `ByteString`
  * Deserialize from `byte[]`
  * Deserialize from `MemoryStream`

For each benchmark, the action is run a few times so we can see how long it takes, and then run for a large number of iterations (without checking the time in between) where the number is chosen such that each benchmark lasts _roughly_ the same amount of time (30 seconds so far).

The results are given in terms of number of iterations and time, as well as (most importantly) the serialization/deserialization speed in terms of megabytes per second.

# Example #

  * From the root directory, build the release version of everything
  * Go into the address book demo directory
  * Run the address book demo and create a couple of entries
  * Copy `ProtoBench.exe` to the same directory
  * Run `ProtoBench.exe`

```
> nant -D:build-configuration=Release build
(build output)
> cd src\AddressBook\bin\Release
> AddressBook.exe
(add a couple of people)
> copy ..\..\..\..\dist\ProtoBench.exe .
> ProtoBench.exe Google.ProtocolBuffers.Examples.AddressBook.AddressBook,AddressBook addressbook.data

Benchmarking Google.ProtocolBuffers.Examples.AddressBook.AddressBook,AddressBook with file addressbook.data
Serialize to byte string: 1842428 iterations in 5.479s; 40.410MB/s
Serialize to byte array: 1874759 iterations in 4.868s; 46.280MB/s
Serialize to memory stream: 1354615 iterations in 4.613s; 35.284MB/s
Deserialize from byte string: 785653 iterations in 5.110s; 18.474MB/s
Deserialize from byte array: 822291 iterations in 5.010s; 19.723MB/s
Deserialize from memory stream: 691115 iterations in 5.040s; 16.479MB/s
```

(The first command line argument to ProtoBench is slightly confusing, it's a class called `AddressBook` in the `Google.ProtocolBuffers.Examples.AddressBook` namespace, in an assembly called `AddressBook` - hence the repetition of `AddressBook` so many times!)

# Current limitations #

  * The assembly containing the message type must be in the same directory as `ProtoBench.exe`

# Benchmark scripts #

_Feature under development_

Instead of only being able to specify options on the command line, you will soon be able to pass a command line argument specifying a script. A script contains a sequence of "test configurations" where each test configuration has default values from the previous one so only changes need to be specified. The final part of each configuration is a `run` command. It's probably easiest to demonstrate this with an example:

```
# Comments start with a hash

# Empty lines are ignored
# Property names and values are trimmed


# Types are specified as namespace-qualified type names. Nested types
# still need to be specified with a + though:
type =   Namespace.OuterType+NestedType

# The assembly containing the message type is specified as a file relative to
# the working directory
assembly = ../bin/Assembly2.dll

# The message file is specified as a file relative to the working directory
message = testdata/message1.dat

# The number of iterations can be specified directly, or left at 0 to
# mean "auto-detect". Auto-detect mode uses two other properties:
# the time to try to run the main test for, and the sampling time
# used to guess at the number of iterations for the main test.
# Both are expressed in seconds
# These properties are ignored when the number of iterations is non-zero.
iterations = 10000
# auto-detect-sample = 3
# auto-detect-target = 30

# This runs the tests. There are currently 6 tests:
#   from_byte_array, from_byte_string, from_stream
#   to_byte_array, to_byte_string, to_stream
# These are grouped as "deserialization" and "serialization", and "all"
# runs everything. We may introduce more tests at a later date.
run all

# Change to use a different data file - all the other settings stay the same
message = testdata/message2.dat

# Just run the serialization tests
run serialization
```