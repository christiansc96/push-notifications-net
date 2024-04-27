using FirebaseManager.Dto;
using FirebaseManager.Manager;
using Microsoft.AspNetCore.Mvc;

namespace PushNotificationsDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController(IFirebaseNotificationsRepository firebaseNotificationsRepository) : ControllerBase
    {
        private readonly IFirebaseNotificationsRepository _firebaseNotificationsRepository = firebaseNotificationsRepository;

        [HttpPost]
        public async Task<IActionResult> Send(MessageDto message)
        {
            bool result = await _firebaseNotificationsRepository.SendPushNotification(message);
            return result ? Ok() : BadRequest();
        }
    }
}