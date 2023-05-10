using VKTaskOne.Entities.Abstract;

namespace VKTaskOne.Entities.Concrete
{
    public class UserGroup : Base
    {
        public GroupCode Code { get; set; }
        public string? Description { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
    
    public enum GroupCode
    {
        Admin,
        User
    }
}
