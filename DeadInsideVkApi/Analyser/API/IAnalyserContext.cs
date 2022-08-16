namespace DeadInsideVkApi.Analyser.API
{
    internal interface IAnalyserContext
    {
        void Analyse();
        void SwapAnalyser(IDetector new_detector);
    }
}
