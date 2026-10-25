namespace ConsoleClicker
{
    internal class Clicker
    {
        private int clicks;
        private ConsoleKey interactKey;
        
        //when using JsonSerializer this counts as a property because of get and set
        public ConsoleKey InteractKey
        {
            get { return interactKey; }
            
            private set
            {
                interactKey = value;
            }
        }
        
        public int Clicks
        {
            get { return clicks; }
            //only code from inside this class can assign value even though the int is public. f.ex "clicker.Clicks = 100" won't work if called from Main()
            private set
            {
                if (value > 0)
                {
                    clicks = value;
                }
            }
        }

        //when Deserializing json this constructor is what gets used even tho the JsonSerializer uses the public variables in the class
        public Clicker(int clicks, ConsoleKey interactKey)
        {
            Clicks = clicks;
            InteractKey = interactKey;
        }
        
        public void KeyPressHandler(ConsoleKey Key)
        { 
            switch (Key)
            {
                case ConsoleKey k when k == InteractKey:
                    Clicks++;
                    break;
                case ConsoleKey k when k == ConsoleKey.M:
                    ConsoleOperation.ClearConsole();
                    ConsoleOperation.WriteString($"press the key you want to change {InteractKey} into");
                    InteractKey = Console.ReadKey().Key;
                    break;
            }
        }

        public void ChangeInteractKey(ConsoleKey InputKey)
        {
            InteractKey = InputKey;
        }

        public void IncreaseClickCount()
        {
            Clicks++;
        }
    }
}