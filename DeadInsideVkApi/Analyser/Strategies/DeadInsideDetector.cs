using DeadInsideVkApi.Analyser.API;
using DeadInsideVkApi.ConfigTypes;
using DeadInsideVkApi.System;
using DeadInsideVkApi.UserInfo;
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

            User user = new User(uid);

            if (CheckUserViaBase(config, ref user))
            {
                return user.Result;

            }
            else
            {
                CheckUserDomain(config, user);
                CheckUserStatus(config, user);
                CheckUserGroups(config, user);

                float result = finalScore * 100 / maxScore;
                user.Result = result;
                config.UpdateUserBase(user);

                return result;
            }
        }

        private bool CheckUserViaBase(AppConfig config, ref User user)
        {
            foreach (var u in config.Users)
            {
                if (u.Id == user.Id)
                {
                    user = u;
                    return true;
                }
            }
            return false;
        }

        private void AnalyseUserProperty(AppConfig config, string property)
        {
            maxScore++;
            foreach (string word in config.Tags)
            {
                if (property.Contains(word))
                {
                    Console.WriteLine($"'{property}' - Forbidden tag '{word}' was founded");
                    finalScore++;
                    return ;
                } 
            }
            Console.WriteLine($"'{property}' - Clear!");
        }

        private void CheckUserDomain(AppConfig config, User user)
        {
            Console.WriteLine("\r\nCheking for user's domain..");

            AnalyseUserProperty(config, user.GetDomain());
        }

        private void CheckUserStatus(AppConfig config, User user)
        {
            Console.WriteLine("\r\nCheking for user's status..");

            AnalyseUserProperty(config, user.GetStatus());
        }

        private void CheckUserGroups(AppConfig config, User user)
        {
            Console.WriteLine("\r\nCheking for user's groups..");

            var groups = user.GetGroups();

            foreach (var g in groups)
            {
                AnalyseUserProperty(config, g.Name);    
            }
        }

    }
}
