This C# port was designed from the outset to be like the Java code, but with a familiar C# feel to it. There are alternative projects which build more code dynamically at execution time, etc. Some of that may become part of this project eventually, but at the moment the core looks quite like the Java code. Most of the natural differences between Java and C# are hidden under the covers, but some differences are user-visible. Of course, this in no way reduces the portability between the two - anything data serialized by the C# code should be able to be deserialized by the Java code, and vice versa.

Currently this list is just a brain dump. Eventually it may be more usefully categorised.

  * C#-style properties instead of getter and setter methods. This is pretty much a given, but it's worth noting that the builders still have `SetXXX` methods which return `this` at the end to allow fluent building in C# 2 code.
  * More complicated generic interfaces. The core Java interfaces (`Message` and `Builder`) are non-generic. In C#, there are up to three levels of genericity: `IMessage<TMessage, TBuilder>` extends `IMessage<TMessage>` which extends `IMessage`, and `IBuilder<TMessage, TBuilder>` extends `IBuilder`. Most of the time the caller doesn't need to care about this, but it can get quite confusing if you're dabbling in the core. I've tried multiple solutions, and this appears to be the neatest balance of type safety and flexibility.
  * Public constructors for builder types. C# 3 object initializers allow a fairly concise syntax for building messages - but this is **only** available when directly calling a constructor (instead of a factory method). For example:

```
Person jon = new Person.Builder { Name="Jon", Company="Google" }.Build();
```
