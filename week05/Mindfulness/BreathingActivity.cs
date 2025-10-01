// File: BreathingActivity.cs
public class BreathingActivity : Activity
{
        public BreathingActivity(string name, string description, PromptManager reflectionPrompts = null, PromptManager listingPrompts = null)
            : base(name, description)
        {
            // nothing else needed here
        }

        protected override void Run()
        {
            int duration = GetDurationSeconds();
            Console.WriteLine();
            int elapsed = 0;
            while (elapsed < duration)
            {
                // Breathe in
                Console.WriteLine("Breathe in...");
                CountdownDuringPause(4); // breath in 4 seconds
                elapsed += 4;
                if (elapsed >= duration) break;

                // Breathe out
                Console.WriteLine("Breathe out...");
                CountdownDuringPause(6); // breath out 6 seconds
                elapsed += 6;
            }
        }

        private void CountdownDuringPause(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
                Console.Write('\b');
                // backspace to remove the number and space; since numbers may be multi-digit we keep it simple
            }
            Console.WriteLine();
        }
}