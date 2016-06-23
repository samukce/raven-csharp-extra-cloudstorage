# Extension for RavenCsharp (Sentry)

Extension for ravensharp-sentry to send long file text to storage.
Usefull when it is have a long text to analyse.

# Usage

Before you have to read the main project https://github.com/getsentry/raven-csharp

So, with sentryEvent is possible send a log file to storage of the Microsoft Storage.

```csharp
sentryEvent.WithCredenctials("accountname", "keyValue")
                           .ToContainername("containerName")
                           .SendToStorage("logmessage", "subfolder");
```

Get it!
-------
You can clone and build SharpRaven yourself, but for those of us who are happy with prebuilt binaries, there's [a NuGet package](https://www.nuget.org/packages/SharpRaven.ToStorage/).
