using System.Collections.ObjectModel;
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
        public VkCollection<Group> GetGroups(long u_id, int offset = 0) 
        {
            return api.Groups.Get(new VkNet.Model.RequestParams.GroupsGetParams() {
                UserId = u_id, Offset = offset, Extended = true 
            });
        }
        public ReadOnlyCollection<User> GetUsersInfo(long[] id, VkNet.Enums.Filters.ProfileFields filter)
        {
            return api.Users.Get(id, filter);
        }
    }
}
