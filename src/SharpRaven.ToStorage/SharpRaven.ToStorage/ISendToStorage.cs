namespace SharpRaven.ToStorage {
    public interface ISendToStorage {
        void SendToStorage(string logmessage, string subfolder);
    }
}