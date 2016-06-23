using SharpRaven.Data;

namespace SharpRaven.ToStorage {
    public interface IConfigurationContainer {
        string AccountName { get; }
        string KeyValue { get; }
        string ContainerName { get; }
        SentryEvent SentryEvent { get; }

        ISendToStorage ToContainername(string containerName);
    }
}