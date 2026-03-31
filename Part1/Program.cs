using System;

namespace CyberAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot - Part 1";

            Chatbot bot = new Chatbot();
            bot.Start();
        }
    }
}