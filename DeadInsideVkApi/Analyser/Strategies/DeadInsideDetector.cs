using DeadInsideVkApi.Analyser.API;
using DeadInsideVkApi.VK;

namespace DeadInsideVkApi.Analyser.Strategies
{
    internal class DeadInsideDetector : IDetector
    {
        public void Detect()
        {
            CheckUserDomain();
            CheckUserGroups();
        }

        private void CheckUserDomain()
        {
            string domain = VkHandler.Instance.GetUsersInfo(new long[] { 249764138 },
                VkNet.Enums.Filters.ProfileFields.Domain).First().Domain;

            // ... 

            Console.WriteLine(domain);
        }

        private void CheckUserGroups()
        {
            var groups = VkHandler.Instance.GetGroups(249764138);

            foreach(var g in groups)
            {
                Console.WriteLine(g.Name);
            }
        }
    }
}
