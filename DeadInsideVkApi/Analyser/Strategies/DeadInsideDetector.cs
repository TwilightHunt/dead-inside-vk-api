using DeadInsideVkApi.Analyser.API;
using DeadInsideVkApi.ConfigTypes;
using DeadInsideVkApi.System;
using DeadInsideVkApi.VK;

namespace DeadInsideVkApi.Analyser.Strategies
{
    internal class DeadInsideDetector : IDetector
    {
        int maxScore = 0;
        int finalScore = 0;

        public float FullDetect(int uid)
        {
            var config = Storage.Get<AppConfig>(Constants.SYSTEM_CONFIG);

            if (CheckUserViaBase(config, uid))
            {
                Console.WriteLine("User was detected in base as dead inside");
                return 100f;

            }
            else
            {
                CheckUserDomain(config, uid);
                CheckUserStatus(config, uid);
                CheckUserGroups(config, uid);
                return finalScore * 100 / maxScore;
            }
        }

        private bool CheckUserViaBase(AppConfig config, int uid)
        {
            foreach (var u in config.Users)
            {
                if (u == uid)
                {
                    return true;
                }
            }
            return false;
        }

        private bool AnalyseUserProperty(AppConfig config, string property)
        {
            foreach (string word in config.Tags)
            {
                if (property.Contains(word))
                {
                    Console.WriteLine($"Forbidden tag '{word}' was found");
                    finalScore++;
                    return true;
                }
            }
            return false;
        }

        private void CheckUserDomain(AppConfig config, int uid)
        {
            maxScore++;

            Console.WriteLine("Cheking for user's domain..");

            string domain = VkHandler.Instance.GetUsersInfo(new long[] { uid },
                    VkNet.Enums.Filters.ProfileFields.Domain).First().Domain;

            if (!AnalyseUserProperty(config, domain)) { Console.WriteLine("Clear!"); }
        }

        private void CheckUserStatus(AppConfig config, int uid)
        {
            maxScore++;

            Console.WriteLine("Cheking for user's status..");

            string status = VkHandler.Instance.GetUsersInfo(new long[] { uid },
                VkNet.Enums.Filters.ProfileFields.Status).First().Status;

            if (!AnalyseUserProperty(config, status)) { Console.WriteLine("Clear!"); }
        }

        private bool CheckUserGroups(AppConfig config, int uid)
        {
            maxScore++;

            Console.WriteLine("Cheking for user's groups..");

            var groups = VkHandler.Instance.GetGroups(uid);

            foreach (var g in groups)
            {
                if (AnalyseUserProperty(config, g.Name)) return true;
            }
            Console.WriteLine("Clear!");
            return false;
        }

    }
}
