using System.Collections.ObjectModel;
using VkNet;
using VkNet.Model;
using VkNet.Utils;

namespace DeadInsideVkApi.Handlers
{
    public class VkHandler
    {
        public VkApi Api { get; }
        public UserHandler UserHandler { get; }
        public VkHandler(string token)
        {
            Api = new VkApi();
            Api.Authorize(new ApiAuthParams
            {
                AccessToken = token,
            });
            UserHandler = new UserHandler(this);
        }
        public VkCollection<Group> GetGroups(long u_id, int offset = 0)
        {
            return Api.Groups.Get(new VkNet.Model.RequestParams.GroupsGetParams()
            {
                UserId = u_id,
                Offset = offset,
                Extended = true
            });
        }
    }
}
