namespace HB.Api.Models
{
    public class User()
    {
        public required Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
    }
}
