using VkNet;
using VkNet.Model;
using VkNet.Utils;

namespace DeadInsideVkApi.VK
{
    public class VkHandler
    {
        private VkApi api;
        public static VkHandler Instance;
        public VkHandler(string token)
        {
            api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = token, 
            });
            Instance = this;
        }
        public VkCollection<Group> GetGroups(long u_id, int count = 10, int offset = 0) 
        {
            return api.Groups.Get(new VkNet.Model.RequestParams.GroupsGetParams() {
                UserId = u_id, Count = count, Offset = offset, Extended = true 
            });
        }
        public void GetUserInfo()
        {
            var users = api.Users.Get(new long[] { 249764138, 522339419 });
            foreach (var u in users)
            {
                if (u.Domain != null)
                {
                    Console.WriteLine($"User domain is {u.Domain}");
                }
                else
                {
                    Console.WriteLine("User name not found");
                }
            }
        }
    }
}
