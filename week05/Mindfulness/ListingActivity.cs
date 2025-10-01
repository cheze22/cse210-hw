// File: ListingActivity.cs
public class ListingActivity : Activity
{
        private PromptManager _prompts;

        public ListingActivity(string name, string description, PromptManager prompts)
            : base(name, description)
        {
            _prompts = prompts ?? throw new ArgumentNullException(nameof(prompts));
        }

        protected override void Run()
        {
            int duration = GetDurationSeconds();
            Console.WriteLine();
            string prompt = _prompts.NextPrompt();
            Console.WriteLine("Prompt: " + prompt + "\n");
            Console.WriteLine("You will have a few seconds to think, then start listing items. Press Enter after each item.\n");
            Console.Write("Prepare: ");
            PauseWithCountdown(5);

            Console.WriteLine("Start listing (press Enter on an empty line to stop early):");
            var items = new List<string>();
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < duration)
            {
                if (Console.KeyAvailable)
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) break;
                    items.Add(line.Trim());
                }
                else
                {
                    // small sleep to avoid busy-waiting
                    Thread.Sleep(200);
                }
            }

            Console.WriteLine($"\nYou entered {items.Count} items.");
            Console.WriteLine("Items:");
            foreach (var it in items)
            {
                Console.WriteLine("- " + it);
            }
        }
}