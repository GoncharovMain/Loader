namespace Cursor
{
    public class Program
    {
        public static void Calc()
        {
            int waitTime = 75;
            Thread.Sleep(waitTime);
        }
        public static void Main()
        {
            // ███████████████████████████▒▒▒ 100,00%
            Loader loader = new Loader();
            loader.LoopPrintPercent(Calc);

            // ███████████████████████████▒▒▒ 100,00 number
            loader = new Loader(0, 100);
            loader.LoopPrintNumber(Calc);

            //****************************** 100,00%
            loader = new Loader(0, 40, '*', ' ');
            loader.LoopPrintNumber(Calc);

            //================================ 100,00%
            loader = new Loader(50, 100, '=', ' ');
            loader.LengthBar = 32;
            loader.LoopPrintPercent(Calc);

        }
    }
}
