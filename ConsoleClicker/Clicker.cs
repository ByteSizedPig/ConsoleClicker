namespace ClickerConstructor
{
    class Clicker
    {
        private int clicks;

        //when using JsonSerializer this counts as a field because it doesnt have get and set
        public ConsoleKey InteractKey;
        
        //when using JsonSerializer this counts as a property because of get and set
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
        public Clicker(int clicks, ConsoleKey interactkey)
        {
            Clicks = clicks;
            InteractKey = interactkey;
        }

        public void Write()
        {
            Console.WriteLine($"{Clicks} : {InteractKey} Clicks");

        }

        public void KeyPressHandler(ConsoleKey Key)
        { 
            if (InteractKey == Key) 
            {
                Clicks++;
            }
            
        }
    }
}