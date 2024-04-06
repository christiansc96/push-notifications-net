namespace FiebaseManager.Dto
{
    public class MessageDto
    {
        public string[] Registration_ids { get; set; }
        public NotificationDto Notification { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}