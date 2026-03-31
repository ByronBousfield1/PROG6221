using System;
using System.Threading;
using System.Media;
using System.IO;

namespace CyberAwarenessBot
{
    public static class UIHelper
    {
        // Creates a simulated conversational typing effect
        public static void Typewrite(string message, ConsoleColor color = ConsoleColor.White, int delay = 15)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Slight delay for typing effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Prints a formatted section header
        public static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"  {title}  ");
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();
        }

        // Prints a visual divider
        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();
        }

        // Prints the ASCII art logo
        public static void PrintAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string art = @"
   _____       _               _____           _   
  /  __ \     | |             |  _  |         | |  
  | /  \/_   _| |__   ___ _ __| | | |___ _ __ | |_ 
  | |   | | | | '_ \ / _ \ '__| | | / __| '_ \| __|
  | \__/\ |_| | |_) |  __/ |  \ \_/ /\__ \ | | | |_ 
   \____/\__, |_.__/ \___|_|   \___/ |___/_| |_|\__|
          __/ |                                     
         |___/      Awareness Bot v1.0               
            ";
            Console.WriteLine(art);
            Console.ResetColor();
        }

        // Plays the greeting .wav file using System.Media
        public static void PlayGreeting(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    using (SoundPlayer player = new SoundPlayer(filepath))
                    {
                        player.Play(); // Plays asynchronously so it doesn't freeze the console
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[Warning: Audio File '{filepath}' not found. Please add it to the execution folder.]");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Audio playback failed: {ex.Message}]");
                Console.ResetColor();
            }
        }
    }
}