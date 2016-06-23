using System;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SharpRaven.ToStorage {
    public class SendToMsStorage : ISendToStorage {
        private readonly ConfigurationContainer configuration;

        public SendToMsStorage(ConfigurationContainer configuration) {
            this.configuration = configuration;
        }

        public void SendToStorage(string logmessage, string subfolder) {
            try {
                var cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(configuration.AccountName, configuration.KeyValue), true);

                var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                var cloudBlobContainer = cloudBlobClient.GetContainerReference(configuration.ContainerName);

                var blobReference = cloudBlobContainer.GetBlockBlobReference(BuildFileName(subfolder));
                blobReference.Properties.ContentType = "text/plain";

                blobReference.UploadText(logmessage.Replace("\n", "\r\n"), Encoding.UTF8);

                var sas = blobReference.GetSharedAccessSignature(new SharedAccessBlobPolicy {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTime.UtcNow + TimeSpan.FromDays(30)
                });

                configuration.SentryEvent.Extra = new LogMessage {
                    Url = $"{blobReference.Uri.AbsoluteUri}{sas}"
                };
            } catch (Exception e) {
                throw new Exception("Error sending log file for Storage. \nError:" + e.Message, e);
            }
        }

        private static string BuildFileName(string subfolder) {
            var groupFolder = "";
            if (!string.IsNullOrWhiteSpace(subfolder)) {
                groupFolder = subfolder + "/";
            }

            return $"{groupFolder}{Guid.NewGuid() + ".txt"}";
        }
    }
}