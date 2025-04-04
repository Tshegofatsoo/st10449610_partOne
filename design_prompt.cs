using System;
using System.Collections.Generic;

namespace st10449610_partOne
{
    public class design_prompt
    {
        private string user_name = string.Empty;
        private string user_asking = string.Empty;
        private Dictionary<string, string> responses = new Dictionary<string, string>
        {
            { "how are you", "I am eager to help! How can I assist you today?" },
            { "purpose", "My purpose is to make answer your cybersecurity queries and help you stay safe and confident online." },
            { "what can i ask", "You can ask me about cybersecurity topics like password safety, phishing, viruses and public Wi-fi." },
            { "password", "Always use a strong password with a mix of letters, numbers, and symbols. \nNever reuse passwords!" },
            { "phishing", "Phishing is when hackers send deceptive emails/messages tricking users into revealing sensitive information." },
            { "browsing", "Always check the URL before clicking or entering any personal information. \nIf there is no 'https://' or strange spellings, it's a scam!" },
            { "Wi-Fi safety", "Using public Wi-Fi is convenient but is very unsafe as hackers can spy on what you are doing. \nAvoid logging into banking apps or important accounts using public Wi-Fi." },
            { "viruses", "A virus is a malware that sneaks into your device and spreads and causes damage to data. \nTo avoid being attacked by a virus, do not click dodgy links or download stuff from strange websites, or use antivirus software." }

        };

        public design_prompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                         Ultron the CYBERSECURITY AWARENESS CHATBOT                            ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ultron <3: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("What is your name? ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You: ");
            Console.ForegroundColor = ConsoleColor.White;
            user_name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(user_name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ultron <3: Please enter a valid name.");
                Console.ResetColor();
                Console.Write("You: ");
                user_name = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ultron <3: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hey {user_name}! My name is Ultron <3. How can I assist you today?");

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{user_name}: ");
                Console.ForegroundColor = ConsoleColor.White;
                user_asking = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(user_asking))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ultron <3: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    Console.Write($"{user_name}: ");
                    user_asking = Console.ReadLine();
                }

                answer(user_asking);

            } while (user_asking.ToLower() != "exit");

            ExitChat();
        }

        private void answer(string asked)
        {
            Console.Write("Ultron <3: ");
            Console.ForegroundColor = ConsoleColor.Magenta;

            string response = "Sorry, I can only assist with cybersecurity-related queries.";

            foreach (var key in responses.Keys)
            {
                if (asked.ToLower().Contains(key))
                {
                    response = responses[key];
                    break;
                }
            }

            Console.WriteLine(response);
            Console.ResetColor();
        }

        private void ExitChat()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nUltron <3: It was great chatting with you! Stay safe online.");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}