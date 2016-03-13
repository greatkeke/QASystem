namespace QASystem.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ImgUrl { get; set; }
        public int QuestionCollectionCount { get; set; }
        public int TopicCollectionCount { get; set; }
        public int UserCollectionCount { get; set; }
    }
}