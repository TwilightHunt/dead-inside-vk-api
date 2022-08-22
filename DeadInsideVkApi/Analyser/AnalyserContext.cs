using DeadInsideVkApi.Analyser.API;
using DeadInsideVkApi.Analyser.Strategies;

namespace DeadInsideVkApi.Analyser
{
    internal class AnalyserContext : IAnalyserContext
    {
        private IDetector Detector;

        public AnalyserContext()
        {
            Detector = new DeadInsideDetector();
        }

        public void Analyse()
        {
            Console.Write("Enter ID: ");
            long id = Convert.ToInt64(Console.ReadLine());

            float result = Detector.FullDetect(id);
            Console.WriteLine($"User is dead inside for {result}%");         
        }

        public void SwapAnalyser(IDetector new_detector)
        {
            Detector = new_detector;
            // ...
        }
    }
}
