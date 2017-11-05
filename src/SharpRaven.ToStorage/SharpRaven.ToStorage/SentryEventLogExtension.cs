using SharpRaven.Data;

namespace SharpRaven.ToStorage {
    public static class SentryEventLogExtension {
        public static IConfigurationContainer WithCredentials(this SentryEvent sentryEvent, string accountname, string keyValue) {
            return new ConfigurationContainer(sentryEvent, accountname, keyValue);
        }
    }
}
