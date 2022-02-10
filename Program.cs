namespace Cursor
{
    public class Program
    {
        public static void Calc()
        {
            int waitTime = 50;
            Thread.Sleep(waitTime);
        }
        public static void Main()
        {
            // ███████████████████████████▒▒▒ 100,00%
            Loader loader = new Loader();

            loader.LoopPrintPercent(new Range(0, 100), Calc);
            Console.WriteLine();

            // ███████████████████████████▒▒▒ 100,00 number
            loader = new Loader(0, 100);
            loader.LoopPrintNumber(new Range(0, 100), Calc);
            Console.WriteLine();

            //****************************** 100,00%
            loader = new Loader(0, 40, '*', ' ');
            loader.LoopPrintPercent(new Range(0, 100), Calc);
            Console.WriteLine();

            //================================ 100,00%
            loader = new Loader(50, 100, '=', ' ');
            loader.LengthBar = 32;
            loader.LoopPrintNumber(new Range(0, 100), Calc);

            Console.WriteLine();
        }
    }
}
