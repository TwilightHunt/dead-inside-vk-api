using DeadInsideVkApi.VK;
using VkNet.Model;
using VkNet.Utils;

namespace DeadInsideVkApi.UserInfo
{
    public class User
    {
        public int Id { get; private set; }
        public float Result { get; set; }

        public User(int id)
        {
            Id = id;
        }

        public string GetDomain()
        {
            return VkHandler.Instance.GetUsersInfo(new long[] { Id },
                    VkNet.Enums.Filters.ProfileFields.Domain).First().Domain;
        }
        public string GetStatus()
        {
            return VkHandler.Instance.GetUsersInfo(new long[] { Id },
                    VkNet.Enums.Filters.ProfileFields.Status).First().Status;
        }

        public VkCollection<Group> GetGroups()
        {
            return VkHandler.Instance.GetGroups(Id);
        }
    }
}
