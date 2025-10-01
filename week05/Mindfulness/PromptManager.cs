// File: PromptManager.cs
// Simple class that manages a list of prompts and ensures no repeats until all are used
public class PromptManager
{
        private List<string> _allPrompts;
        private Queue<string> _queue;
        private Random _rand;

        public PromptManager(List<string> prompts)
        {
            _rand = new Random();
            _allPrompts = new List<string>(prompts);
            Reshuffle();
        }

        private void Reshuffle()
        {
            var list = new List<string>(_allPrompts);
            // Fisher-Yates shuffle
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
            _queue = new Queue<string>(list);
        }

        public string NextPrompt()
        {
            if (_queue.Count == 0) Reshuffle();
            return _queue.Dequeue();
        }
}