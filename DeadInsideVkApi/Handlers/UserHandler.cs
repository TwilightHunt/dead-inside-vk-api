using VkNet.Model;

namespace DeadInsideVkApi.Handlers
{
    public class UserHandler
    {
        private VkHandler _handler;
        public UserHandler(VkHandler handler)
        {
            _handler = handler;
        }

        public User? GetUser(long uid) => _handler.Api.Users.Get(
            new long[] { uid }, VkNet.Enums.Filters.ProfileFields.All
        ).FirstOrDefault();
    }
}
