using DeadInsideVkApi.Handlers;
using DeadInsideVkApi.System;

namespace DeadInsideVkApi.CLI
{
    class App
    {
        public static void Main(string[] args)
        {
            new DeadInside().Bootstrap();
        }
    }
}
