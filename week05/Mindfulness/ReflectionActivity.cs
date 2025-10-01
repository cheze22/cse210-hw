// File: ReflectionActivity.cs
public class ReflectionActivity : Activity
{
        private PromptManager _prompts;

        public ReflectionActivity(string name, string description, PromptManager prompts)
            : base(name, description)
        {
            _prompts = prompts ?? throw new ArgumentNullException(nameof(prompts));
        }

        protected override void Run()
        {
            int duration = GetDurationSeconds();
            Console.WriteLine();
            // Show the random prompt
            string prompt = _prompts.NextPrompt();
            Console.WriteLine("Prompt: " + prompt + "\n");
            Console.WriteLine("Reflect on the following questions:");

            var questionPool = _prompts; 

            var questions = new PromptManager(new List<string> {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            });

            int elapsed = 0;
            while (elapsed < duration)
            {
                string question = questions.NextPrompt();
                Console.WriteLine("Q: " + question);
                // Pause with spinner for a short period to let user think
                int thinkSeconds = 6;
                if (elapsed + thinkSeconds > duration) thinkSeconds = Math.Max(1, duration - elapsed);
                PauseWithSpinner(thinkSeconds);
                elapsed += thinkSeconds;
                Console.WriteLine();
            }
        }
}
