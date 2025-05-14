using System;
using System.Collections.Generic;

namespace st10449610_partOne
{
    public class design_prompt
    {
        private memory memory = new memory();
        private string user_name = string.Empty;
        private string user_asking = string.Empty;

        //sentiment detection
        //this part analyzes the user's input by checking for emotional words the adjusting the chtbot's tone
        private List<string> negativeWords = new List<string> { "sad", "scared", "worried", "afraid", "angry", "hate" };
        private List<string> positiveWords = new List<string> { "happy", "excited", "glad", "safe", "love" };

        private string DetectSentiment(string input)
        {
            string loweredInput = input.ToLower();

            foreach (string word in negativeWords)
            {
                if (loweredInput.Contains(word))
                {
                    return "negative";
                }
            }

            foreach (string word in positiveWords)
            {
                if (loweredInput.Contains(word))
                {
                    return "positive";
                }
            }

            return "neutral";
        }


        private Dictionary<string, string> responses = new Dictionary<string, string>
        {
            { "how are you", "I am eager to help! How can I assist you today?" },
            { "purpose", "My purpose is to make answer your cybersecurity queries and help you stay safe and confident online." },
            { "what can i ask", "You can ask me about cybersecurity topics like password safety, phishing, viruses and public Wi-fi." },
            { "browsing", "Always check the URL before clicking or entering any personal information. \nIf there is no 'https://' or strange spellings, it's a scam!" },
     
        };
        private List<string> passwordResponse = new List<string>();
        //init = initialize.  I initialized a list of responses related to password safety
        public void initPassword()
        {
            passwordResponse.Add("Always use a strong password with a mix of letters, numbers, and symbols. \nNever reuse passwords!");
            passwordResponse.Add("Use a password manager to safely store different passwords for each account.");
            passwordResponse.Add("Avoid using obvious passwords like 'password123' or your birthday.");
            passwordResponse.Add("Use long passwords with a mix of letters, numbers, and symbols.");
        }

        private List<string> virusResponse = new List<string>();
        //I initialized a list of responses related to viruses
        public void initVirus()
        {
            virusResponse.Add("A virus is a malware that sneaks into your device and spreads and causes damage to data. \\nTo avoid being attacked by a virus, do not click dodgy links or download stuff from strange websites, or use antivirus software.\"  ");
            virusResponse.Add("Scan USB drives before opening files on them.");
            virusResponse.Add("Use a reputable antivirus program and run regular scans.");
            virusResponse.Add("Don’t open email attachments unless you're expecting them and trust the sender.");
        }

        private List<string> phishingResponse = new List<string>();
        public void initPhishing()
        {
            phishingResponse.Add("Phishing is when hackers send deceptive emails/messages tricking users into revealing sensitive information.");
            phishingResponse.Add("Basically, phishing is online trickery. Someone fakes being a trusted source to get your login details or money.\nAlways look for signs like weird links or urgent messages.");
            phishingResponse.Add("Always access websites by typing the address yourself, instead of clicking on links in emails.");
            phishingResponse.Add("Look for spelling mistakes and urgent language; these are common signs of phishing.");
            phishingResponse.Add("Check the sender's email address carefully. Even a small change can indicate a fake.");
        }

        private List<string> WiFiResponse = new List<string>();
        public void initWiFi()
        {
            WiFiResponse.Add("Avoid accessing sensitive accounts like banking on public Wi-Fi.");
            WiFiResponse.Add("Use a VPN to encrypt your connection when using public networks.");
            WiFiResponse.Add("Using public Wi-Fi is convenient but is very unsafe as hackers can spy on what you are doing. \nAvoid logging into banking apps or important accounts using public Wi-Fi.");
            WiFiResponse.Add("Disable auto-connect to open Wi-Fi networks in your device settings.");
        }

        public string getRandomResponse(List<string> list)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, list.Count);
            return ((string)list[r]);
            
        }


        public design_prompt()
        {
            initPassword();
            initVirus();
            initPhishing();
            initWiFi();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                         Ultron the CYBERSECURITY AWARENESS CHATBOT                            ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ultron <3: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello! What is your name? ");

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
            memory.Name = user_name;

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

            string lowerAsk = asked.ToLower();
            string sentiment = DetectSentiment(asked); // Detect emotional tone of the input
            bool responded = false; // Track if a keyword-based response was already given

            // Check if user is expressing interest in a topic to remember it
            if (lowerAsk.Contains("i'm interested in") || lowerAsk.Contains("i am interested in"))
            {
                memory.RememberTopic(asked);
                Console.ResetColor();
                return;
            }

            // Keyword recognition and response
            if (lowerAsk.Contains("password"))
            {
                Console.WriteLine(getRandomResponse(passwordResponse));
                responded = true;
            }
            else if (lowerAsk.Contains("phishing"))
            {
                Console.WriteLine(getRandomResponse(phishingResponse));
                responded = true;
            }
            else if (lowerAsk.Contains("virus"))
            {
                Console.WriteLine(getRandomResponse(virusResponse));
                responded = true;
            }
            else if (lowerAsk.Contains("wifi"))
            {
                Console.WriteLine(getRandomResponse(WiFiResponse));
                responded = true;
            }
            else
            {
                // Match general dictionary responses
                foreach (var key in responses.Keys)
                {
                    if (lowerAsk.Contains(key))
                    {
                        Console.WriteLine(responses[key]);
                        responded = true;
                        break;
                    }
                }
            }

            // Sentiment-based supportive message
            if (sentiment == "positive")
            {
                Console.WriteLine("I'm glad you're feeling good!");
            }
            else if (sentiment == "negative")
            {
                Console.WriteLine("I'm really sorry you're feeling this way. I'm here to help.");
            }
            else if (!responded)
            {
                // Only show this if no relevant keyword was found
                Console.WriteLine(" Thanks for sharing. Let's keep chatting!");
            }

            Console.ResetColor(); // Reset the console color after output
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