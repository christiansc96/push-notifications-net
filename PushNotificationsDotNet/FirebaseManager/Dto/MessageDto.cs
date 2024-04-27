namespace FirebaseManager.Dto
{
    public class MessageDto
    {
        public required string[] Registration_ids { get; set; }
        public required NotificationDto Notification { get; set; }
        public required string Name { get; set; }
        public required string FullName { get; set; }
    }
}