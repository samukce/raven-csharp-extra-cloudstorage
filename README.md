# Extension for Sentry (https://github.com/samukce/raven-csharp)

Extension for ravensharp-sentry to send long file text to storage.
Usefull when it is have a long text to analyse.

# Usage

Before you have to read the main project https://github.com/samukce/raven-csharp

So, with sentryEvent is possible send a log file to storage of the Microsoft Storage.

```csharp
sentryEvent.WithCredenctials("accountname", "keyValue")
                           .ToContainername("containerName")
                           .SendToStorage("logmessage", "subfolder");
```
