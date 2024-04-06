using FiebaseManager.Dto;
using System.Threading.Tasks;

namespace FiebaseManager.Manager
{
    public interface IFirebaseNotificationsRepository
    {
        public Task<bool> SendPushNotification(MessageDto message);
    }
}