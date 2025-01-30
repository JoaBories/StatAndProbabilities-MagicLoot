public enum Rarities
{
    Common,
    Uncommon,
    Rare,
    Mythic,
    Error
}

public struct CardData
{
    public Rarities rarity;
    public ConsoleColor color;
    public int percentage;
    public float averagePrice;

    public CardData(Rarities p3 ,ConsoleColor p1, int p2, float p4)
    {
        rarity = p3;
        color = p1;
        percentage = p2;
        averagePrice = p4;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Random rand = new Random();

        int boosterSize = 6;

        List<CardData> normalBooster = new List<CardData>();
        normalBooster.Add(new CardData(Rarities.Uncommon,ConsoleColor.DarkGray,  84, 0.1f));
        normalBooster.Add(new CardData(Rarities.Common,  ConsoleColor.Green, 10, 0.25f));
        normalBooster.Add(new CardData(Rarities.Rare,    ConsoleColor.Blue,  5,  1f));
        normalBooster.Add(new CardData(Rarities.Mythic,  ConsoleColor.Magenta,   1,  4.9f));

        List<CardData> premiumBooster = new List<CardData>();
        premiumBooster.Add(new CardData(Rarities.Common, ConsoleColor.Green, 79, 0.25f));
        premiumBooster.Add(new CardData(Rarities.Rare,   ConsoleColor.Blue,  17,  1f));
        premiumBooster.Add(new CardData(Rarities.Mythic, ConsoleColor.Magenta,   4,  4.9f));

        CardData DrawCard(List<CardData> booster)
        {
            int magicNumber = rand.Next(0, 100);

            int a = 0;
            for (int i = 0; i < booster.Count; i++) {
                if (magicNumber >= a && magicNumber < a + booster[i].percentage)
                {
                    return booster[i];
                }
                a += booster[i].percentage;
            }
            return new CardData();
        }

        Dictionary<CardData, int> DrawBooster(List<CardData> booster)
        {
            Dictionary<CardData, int> cards = new Dictionary<CardData, int>();
            foreach (CardData rarity in booster)
            {
                cards.Add(rarity, 0);
            }

            for (int i = 0; i < boosterSize; i++)
            {
                CardData card = DrawCard(booster);
                cards[card]++;
            }

            return cards;
        }

        void DrawXBoosters()
        {
            List<CardData> booster = new List<CardData>();
            string boosterName = "";
            float boosterPrice = 0;
            int loadingInterval = 500;
            float totalPrice = 0;
            ConsoleColor baseColor = Console.ForegroundColor;

            Dictionary<CardData, int> collection = new Dictionary<CardData, int>();

            #region number of boosters
            Console.WriteLine("How many boosters do you want to open");
            int X = Convert.ToInt32(Console.ReadLine());
            #endregion

            #region type of booster
            Console.WriteLine("Which booster do you want N - normal 3.99 cred, P - premium 8.99 creds");
            var temp = Console.ReadLine();
            while (temp == null || (temp != "N" && temp != "P"))
            {
                Console.WriteLine("Error Retry");
                Console.WriteLine("Which booster do you want N - normal 3.99 cred, P - premium 8.99 creds");
            }
            string answer = temp;

            switch (answer)
            {
                case "N":
                    booster = normalBooster;
                    boosterName = "normal";
                    boosterPrice = 3.99f;
                    break;

                case "P":
                    booster = premiumBooster;
                    boosterName = "PREMIUM";
                    boosterPrice = 8.99f;
                    break;
            }
            #endregion

            #region loading anim
            Console.Clear();

            totalPrice = X*boosterPrice;
            Console.WriteLine($"Buy {X} {boosterName} boosters for {totalPrice} credits");
            Console.WriteLine("Enter to Confirm");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Processing .");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("█████▒▒▒▒▒");
            Console.WriteLine("Processing ..");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("██████████");
            Console.WriteLine("Processing ...");
            Thread.Sleep(loadingInterval);

            Console.Clear();
            Console.WriteLine("Open them");
            Console.WriteLine("Enter to Confirm");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Openning .");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("██▒▒▒▒▒▒▒▒");
            Console.WriteLine("Openning ..");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("████▒▒▒▒▒▒");
            Console.WriteLine("Openning ...");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("██████▒▒▒▒");
            Console.WriteLine("Openning .");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("████████▒▒");
            Console.WriteLine("Openning ..");
            Thread.Sleep(loadingInterval);
            Console.Clear();
            Console.WriteLine("██████████");
            Console.WriteLine("Openning ...");
            Thread.Sleep(100);

            Console.Clear();
            #endregion

            for (int i = 0; i < X; i++)
            {
                Dictionary<CardData, int> tempBooster = DrawBooster(booster);
                foreach (CardData key in tempBooster.Keys)
                {
                    if (collection.ContainsKey(key))
                    {
                        collection[key] += tempBooster[key];
                    }
                    else
                    {
                        collection.Add(key, tempBooster[key]);
                    }
                }
            }

            float totalReSell = 0;

            foreach (CardData key in collection.Keys)
            {
                float reSell = key.averagePrice * collection[key];
                totalReSell += reSell;
                Console.ForegroundColor = key.color;
                Console.Write($"█ {key.rarity}");
                Console.ForegroundColor = baseColor;
                Console.WriteLine($" : {collection[key]} -- {reSell} credits");
            }

            Console.WriteLine($"You got for {totalReSell} creds in Cards after paying {totalPrice} creds");
        }

        DrawXBoosters();
        DrawXBoosters();
        DrawXBoosters();
        DrawXBoosters();
        DrawXBoosters();
        DrawXBoosters();

    }
    

}


