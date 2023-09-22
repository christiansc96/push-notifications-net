using FiebaseManager.Dto;
using FiebaseManager.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace pushNotificationsDotNetFirebase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IFirebaseNotificationsRepository _firebaseNotificationsRepository;

        public NotificationsController(IFirebaseNotificationsRepository firebaseNotificationsRepository)
        {
            _firebaseNotificationsRepository = firebaseNotificationsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Send(MessageDto message)
        {
            bool result = await _firebaseNotificationsRepository.SendPushNotification(message);
            return result ? Ok() : BadRequest();
        }
    }
}