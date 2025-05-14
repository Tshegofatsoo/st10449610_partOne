using System;

namespace st10449610_partOne
{
    public class memory
    {
        public string Name { get; set; }
        public string FavoriteTopic { get; set; }
        public memory()
        {
            Name = string.Empty;
            FavoriteTopic = string.Empty;
        }

        public void RememberTopic(string input)
        {
            string lowerInput = input.ToLower();
            if (lowerInput.Contains("i'm interested in") || lowerInput.Contains("i am interested in"))
            {
                int index = lowerInput.IndexOf("interested in");
                string topic = input.Substring(index + "interested in".Length).Trim();
                if (!string.IsNullOrWhiteSpace(topic))
                {
                    FavoriteTopic = topic;
                    Console.WriteLine($"Great! I'll remember that you're interested in {topic}. It's an important part of cybersecurity.");
                }
            }
        }

        public bool IsTopicRemembered()
        {
            return !string.IsNullOrWhiteSpace(FavoriteTopic);
        }
    }
}
       