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
            // ... | some prepare logic
            Detector.Detect();
            Console.WriteLine("Detect..");
        }

        public void SwapAnalyser(IDetector new_detector)
        {
            Detector = new_detector;
            // ...
        }
    }
}
