
using System;

namespace CyberAwarenessBot
{
    public class Chatbot
    {
        // Automatic property to hold the user's name
        public string UserName { get; private set; }
        private bool isRunning;

        public void Start()
        {
            isRunning = true;

            // Display visual and plays audio greeting
            UIHelper.PrintAsciiArt();
            UIHelper.PlayGreeting("greeting.wav");

            UIHelper.PrintHeader("INITIALIZING SYSTEM");
            UIHelper.Typewrite("Loading cybersecurity modules...", ConsoleColor.Cyan);

            // Initial text-based greeting 
            UIHelper.Typewrite("\nHello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.", ConsoleColor.Yellow);
            UIHelper.Typewrite("Before we begin, may I know your name?", ConsoleColor.White);

            UserName = GetValidInput("Your Name: ");

            UIHelper.Typewrite($"\nNice to meet you, {UserName}! Let's improve your cybersecurity knowledge.", ConsoleColor.Green);
            UIHelper.PrintDivider();

            RunMainLoop();
        }

        private void RunMainLoop()
        {
            UIHelper.Typewrite("You can ask me things like 'How are you?', 'What's your purpose?', or ask about 'phishing', 'passwords', or 'safe browsing'.", ConsoleColor.Gray);
            UIHelper.Typewrite("Type 'exit' or 'quit' to close the application.\n", ConsoleColor.Gray);

            while (isRunning)
            {
                string input = GetValidInput($"{UserName} > ").ToLower();
                ProcessInput(input);
            }
        }

        private string GetValidInput(string prompt)
        {
            string input = "";

            // Input Validation Loop to Prevent empty or whitespace-only inputs
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(prompt);
                Console.ResetColor();

                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    UIHelper.Typewrite("\n[System] Invalid input detected. Please do not leave the field blank.\n", ConsoleColor.Red);
                }
            }
            return input;
        }

        private void ProcessInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Bot > ");
            Console.ResetColor();

            if (input.Contains("exit") || input.Contains("quit") || input.Contains("bye"))
            {
                UIHelper.Typewrite($"Stay safe online, {UserName}! Goodbye.", ConsoleColor.Yellow);
                isRunning = false;
            }
            else if (input.Contains("how are you"))
            {
                UIHelper.Typewrite("I am functioning at 100% capacity and ready to talk about cybersecurity!", ConsoleColor.Green);
            }
            else if (input.Contains("purpose") || input.Contains("who are you"))
            {
                UIHelper.Typewrite("My purpose is to educate South African citizens on identifying and mitigating cyber threats in response to the growing national threat landscape.", ConsoleColor.Green);
            }
            else if (input.Contains("what can i ask") || input.Contains("help"))
            {
                UIHelper.Typewrite("You can ask me about various cybersecurity topics, including: \n  - Password safety\n  - Phishing\n  - Safe browsing", ConsoleColor.Green);
            }
            else if (input.Contains("password"))
            {
                UIHelper.Typewrite("PASSWORD SAFETY TIPS:\n1. Use a mix of upper/lower case letters, numbers, and symbols and a.\n2. Never reuse passwords across different sites.\n3. Consider using a reputable password manager rather write it on paper.\n4. Enable Two-Factor Authentication (2FA) wherever possible.", ConsoleColor.Magenta);
            }
            else if (input.Contains("phish"))
            {
                UIHelper.Typewrite("PHISHING AWARENESS:\nPhishing is when attackers send deceptive emails or messages to trick you into revealing sensitive info.\n- Always verify the sender's email address.\n- Don't click on suspicious links.\n- Look out for urgent language demanding immediate action or threatening account closure.", ConsoleColor.Magenta);
            }
            else if (input.Contains("brows") || input.Contains("safe"))
            {
                UIHelper.Typewrite("SAFE BROWSING PRACTICES:\n- Ensure websites use HTTPS (look for the padlock icon).\n- Avoid downloading files from untrusted sources.\n- Keep your browser and antivirus software updated.\n- Be highly cautious when connected to public Wi-Fi networks.", ConsoleColor.Magenta);
            }
            else
            {
                // Default fallback response
                UIHelper.Typewrite("I didn't quite understand that. Could you rephrase? Try asking about 'phishing', 'passwords', or 'safe browsing'.", ConsoleColor.DarkYellow);
            }

            Console.WriteLine(); 
        }
    }
}