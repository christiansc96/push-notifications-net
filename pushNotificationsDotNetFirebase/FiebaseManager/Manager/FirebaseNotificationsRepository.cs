using FiebaseManager.Dto;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FiebaseManager.Manager
{
    public class FirebaseNotificationsRepository : IFirebaseNotificationsRepository
    {
        public async Task<bool> SendPushNotification(MessageDto message)
        {
            try
            {
                FirebaseApp defaultApp = FirebaseApp.DefaultInstance;
                if (defaultApp == null)
                {
                    defaultApp = FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(Path
                        .Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
                    });
                }
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
            catch
            {
                return false;
            }
        }
    }
}