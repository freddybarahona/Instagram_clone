namespace InstagramClone.Application.Models.DTOs
{
    public class PostDTO
    {
        public Guid PostID { get; set; }
        public Boolean IsStory { get; set; }
        public Guid UserID { get; set; }
        public string PostDescription { get; set; }
        public string? LocationName { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string MediaUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
