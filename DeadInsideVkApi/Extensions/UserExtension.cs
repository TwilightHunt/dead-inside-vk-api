using DeadInsideVkApi.Handlers;
using DeadInsideVkApi.System;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace DeadInsideVkApi.Extensions
{
    public static class UserExtension
    {
        public static VkCollection<Group> GetUserGroups(this User user, GroupsFilters filter, long count = 20, long offset = 0)
        {
            var vk = Storage.Get<VkHandler>()!;
            var groups = vk.Api.Groups.Get(new VkNet.Model.RequestParams.GroupsGetParams()
                { Count = count, Offset = offset, UserId = user.Id, Extended = true, Filter = filter }
            );
            return groups;
        }

        public static IEnumerable<VkCollection<Group>> GetAllUserGroups(this User user, GroupsFilters filter)
        {
            long to_load = 20;
            long loaded = to_load;
            var loaded_groups = user.GetUserGroups(filter, to_load);
            var total = Convert.ToInt64(loaded_groups.TotalCount);
            yield return loaded_groups;
            while (loaded < total)
            {
                loaded = loaded + to_load > total ? total : loaded + to_load;
                yield return user.GetUserGroups(filter, to_load);
            }
        }
    }
}
