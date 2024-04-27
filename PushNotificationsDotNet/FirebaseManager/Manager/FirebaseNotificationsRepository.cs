using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using FirebaseManager.Dto;
using Google.Apis.Auth.OAuth2;
using System.IO;

namespace FirebaseManager.Manager
{
    public class FirebaseNotificationsRepository : IFirebaseNotificationsRepository
    {
        public async Task<bool> SendPushNotification(MessageDto message)
        {
            try
            {
                FirebaseApp defaultApp = FirebaseApp.DefaultInstance;
                string filePath = Path.Combine("..", "FirebaseManager", "key.json");
                defaultApp ??= FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(filePath),
                    });
                Console.WriteLine(defaultApp.Name);

                FirebaseMessaging messaging = FirebaseMessaging.GetMessaging(defaultApp);
                foreach (string device in message.Registration_ids)
                {
                    string result = await messaging.SendAsync(new Message()
                    {
                        Data = new Dictionary<string, string>()
                        {
                            ["FirstName"] = message.Name,
                            ["LastName"] = message.FullName
                        },
                        Notification = new Notification
                        {
                            Title = message.Notification.Title,
                            Body = message.Notification.Body,
                        },
                        Token = device,
                    });
                    Console.WriteLine(result); //projects/projectId/messages/0:messageId
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}