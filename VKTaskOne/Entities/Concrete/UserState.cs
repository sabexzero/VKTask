using VKTaskOne.Entities.Abstract;

namespace VKTaskOne.Entities.Concrete
{
    public class UserState : Base
    {
        public StateCode Code { get; set; }
        public string? Description { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }

    public enum StateCode
    {
        Active,
        Blocked
    }
}
