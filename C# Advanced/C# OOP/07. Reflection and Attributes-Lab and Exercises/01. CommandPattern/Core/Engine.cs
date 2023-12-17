using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();
                try
                {
                    string command = commandInterpreter.Read(args);
                    Console.WriteLine(command);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
