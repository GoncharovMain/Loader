namespace Cursor
{
    public class Loader
    {
        private int _minBar;
        private int _maxBar;
        private char _bar;
        private char _emptyBar;
        public int LengthBar { get; set; }
        public delegate void Function();
        public Loader()
        {
            _minBar = 0;
            _maxBar = 30;

            LengthBar = 30;

            _bar = (char)9608; // █
            _emptyBar = (char)9618; // ▒
        }
        public Loader(int minBar, int maxBar) : this()
        {
            _minBar = minBar;
            _maxBar = maxBar;
        }
        public Loader(int minBar, int maxBar, char bar, char emptyBar) : this(minBar, maxBar)
        {
            _bar = bar;
            _emptyBar = emptyBar;
        }
        public void LoopPrintPercent(Function function)
        {
            for (double percent = 0; percent <= 100; percent++)
            {
                function();
                PrintPercentAsync(percent / 100);
            }
            Console.WriteLine();
        }
        public void LoopPrintNumber(Function function)
        {
            for (int number = _minBar; number <= _maxBar; number++)
            {
                PrintNumberAsync(number);
                function();
            }
            Console.WriteLine();
        }
        public async void PrintPercentAsync(double percent)
        {
            await Task.Run(() => PrintPercent(percent));
        }
        public async void PrintNumberAsync(int numberBar)
        {
            await Task.Run(() => PrintNumber(numberBar));
        }
        public void PrintPercent(double percent) => Console.Write(GetProgressPercentBar(percent));
        public void PrintNumber(int numberBar) => Console.Write(GetProgressNumberBar(numberBar));
        public void PrintNumber(int numberBar, string name) => Console.Write(GetProgressNumberBar(numberBar, name));
        public string GetProgressNumberBar(int numberBar, string name = "number")
        {
            ValidateNumberBar(numberBar);

            double percent = (double)(numberBar - _minBar) / (double)(_maxBar - _minBar);

            string fullBar = GetFullBar(percent);

            return FormatNumber(fullBar, numberBar, name);
        }

        public string GetProgressPercentBar(double percent)
        {
            string fullBar = GetFullBar(percent);

            return FormatPercent(fullBar, percent);
        }

        private string GetFullBar(double percent)
        {
            ValidatePercentBar(percent);

            int currentLengthBar = (int)(LengthBar * percent);

            string loadProc = new String(_bar, currentLengthBar);

            return loadProc.PadRight(LengthBar, _emptyBar);
        }
        private string FormatPercent(string fullBar, double percent) => $"\r{fullBar} {100 * percent:00.00}%";
        private string FormatNumber(string fullBar, int numberBar, string name) => $"\r{fullBar} {numberBar} {name}";

        private void ValidateNumberBar(int numberBar)
        {
            if (numberBar < _minBar || _maxBar < numberBar)
                throw new Exception($"numberBar: {numberBar} is out of range [{_minBar}, {_maxBar}]");
        }
        private void ValidatePercentBar(double percent)
        {
            if (0 > percent || percent > 1)
                throw new Exception("Percent must be to have a range [0, 1]");
        }

    }
}
