using FirebaseManager.Dto;

namespace FirebaseManager.Manager
{
    public interface IFirebaseNotificationsRepository
    {
        public Task<bool> SendPushNotification(MessageDto message);
    }
}