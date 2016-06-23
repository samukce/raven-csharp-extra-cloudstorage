using SharpRaven.Data;

namespace SharpRaven.ToStorage {
    public class ConfigurationContainer : IConfigurationContainer {
        public string AccountName { get; }
        public string KeyValue { get; }
        public string ContainerName { get; private set; }
        public SentryEvent SentryEvent { get; }

        public ConfigurationContainer(SentryEvent sentryEvent, string accountname, string keyValue) {
            SentryEvent = sentryEvent;
            AccountName = accountname;
            KeyValue = keyValue;
        }

        public ISendToStorage ToContainername(string containerName) {
            ContainerName = containerName;

            return new SendToMsStorage(this);
        }
    }
}