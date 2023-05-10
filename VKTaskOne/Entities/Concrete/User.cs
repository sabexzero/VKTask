using VKTaskOne.Entities.Abstract;

namespace VKTaskOne.Entities.Concrete
{
    public class User : Base
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserGroupId { get; set; }
        public Guid UserStateId { get; set; }
    }
}
