using DeadInsideVkApi.Analyser.API;
using DeadInsideVkApi.ConfigTypes;
using DeadInsideVkApi.Extensions;
using DeadInsideVkApi.Handlers;
using DeadInsideVkApi.System;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace DeadInsideVkApi.Analyser.Strategies
{
    internal class DeadInsideDetector : IDetector
    {
        private readonly VkHandler _handler;
        private readonly AppConfig _appConfig;
        const int MAX_SCORE = 3;

        public DeadInsideDetector()
        {
            _appConfig = Storage.Get<AppConfig>()!;
            _handler = Storage.Get<VkHandler>()!;
        }

        public float FullDetect(long uid)
        {
            var user = _handler.UserHandler.GetUser(uid);

            int finalScore = CheckProperty(user.Domain, "domain") + CheckProperty(user.Status, "status") + CheckUserGroups(user);

            return finalScore * 100 / MAX_SCORE;
        }

        private int CheckProperty(string property)
        {
            var exist = _appConfig.Tags.Any(word => property.Contains(word));
            return exist ? 1 : 0;
        }

        private int CheckProperty(string property, string property_name)
        {
            Console.WriteLine($"\r\nChecking for user's {property_name}..");
            return CheckProperty(property);
        }

        private int CheckUserGroups(User user)
        {
            Console.WriteLine("\r\nChecking for user's groups..");
            var groups = user?.GetAllUserGroups(GroupsFilters.Publics).SelectMany(t => t);
            var score = groups?.Select(group => CheckProperty(group.Name)).Sum() ?? 0;
            Console.WriteLine();
            return score > MAX_SCORE ? MAX_SCORE : score;
        }

    }
}
