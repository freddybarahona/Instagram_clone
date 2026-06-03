namespace InstagramClone.Application.Models.Requests.Posts
{
    public class GetPostsRequest : BaseRequest
    {
        public string? PostDescription { get; set; }
        public string? UserName { get; set; }
        public List<string>? hashtags { get; set; }

    }
}
