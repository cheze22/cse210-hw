// File: Activity.cs
// Base class with shared attributes and behaviors
public abstract class Activity
{
        // private members (encapsulation)
        private string _name;
        private string _description;
        private int _durationSeconds; // user-specified duration

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _durationSeconds = 0;
        }

        // Public API
        public void Start()
        {
            Console.Clear();
            ShowStartMessage();
            AskDuration();
            PrepareToBegin();
            var startTime = DateTime.Now;
            Run(); // implemented by derived classes
            var endTime = DateTime.Now;
            var actualSeconds = (int)(endTime - startTime).TotalSeconds;
            ShowEndMessage(actualSeconds);

            // Log the session
            Logger.Log($"{DateTime.Now:u} | {_name} | requested_duration_seconds: {_durationSeconds} | actual_seconds: {actualSeconds}");
        }

        protected abstract void Run(); // concrete behavior per activity

        // Methods that could be shared
        protected void ShowStartMessage()
        {
            Console.WriteLine($"Starting {_name}.\n");
            Console.WriteLine(_description + "\n");
        }

        protected void AskDuration()
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            int seconds;
            while (!int.TryParse(input, out seconds) || seconds <= 0)
            {
                Console.Write("Please enter a positive integer for seconds: ");
                input = Console.ReadLine();
            }
            _durationSeconds = seconds;
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("\nGet ready to begin...");
            PauseWithCountdown(3);
        }

        protected void ShowEndMessage(int actualSeconds)
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            PauseWithSpinner(3);
            Console.WriteLine($"You have completed the activity: {_name}");
            Console.WriteLine($"Total time: {actualSeconds} seconds.\n");
            PauseWithCountdown(3);
        }

        // Utility methods for animation & pausing (shared)
        protected void PauseWithSpinner(int seconds)
        {
            var spinner = new[] { '/', '-', '\\', '|' };
            var start = DateTime.Now;
            int i = 0;
            while ((DateTime.Now - start).TotalSeconds < seconds)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write('\b');
                i++;
            }
            Console.Write(' ');
            Console.Write('\b');
        }

        protected void PauseWithCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write('\b');
            }
            Console.Write(' ');
            Console.Write('\b');
            Console.WriteLine();
        }

        // Expose duration to derived classes
        protected int GetDurationSeconds()
        {
            return _durationSeconds;
        }
}
