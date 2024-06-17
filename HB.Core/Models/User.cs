namespace HB.Core.Models
{
    public class User
    {
        public required Guid UserId { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
      
    }
}
