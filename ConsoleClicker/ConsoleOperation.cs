namespace ConsoleClicker
{
    internal class ConsoleOperation
    {
        public static void WriteString(string text)
        {
            Console.WriteLine(text);
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
        
        public static void KeyPressHandler(ConsoleKey Key, Clicker Clicker, Clicker[] Clickers)
        { 
            switch (Key)
            {
                case ConsoleKey k when k == Clicker.InteractKey:
                    Clicker.IncreaseClickCount();
                    break;
                case ConsoleKey k when k == ConsoleKey.M:
                    ConsoleOperation.ClearConsole();
                    WriteString("which key would you like to change?");
                    ConsoleKeyInfo ToChange = ReadKey();
                    foreach (var clicker in Clickers)
                    {
                        if (clicker.InteractKey == ToChange.Key)
                        {
                            ClearConsole();
                            WriteString($"currently changing clicker: {clicker.InteractKey}");
                            clicker.ChangeInteractKey(ReadKey().Key);
                        }
                    }
                    break;
            }
        }
    }
}
