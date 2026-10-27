using System.Formats.Tar;
using System.Xml.Serialization;


public class Guy
{
    public string Name;
    public int Cash;
    /// <summary>
    /// Wyświetla w konsoli imię oraz sianko posiadane
    /// </summary>
    public void WriteMyInfo()
    {
        Console.WriteLine(Name + " ma " + Cash + " zł. ");
    }
    /// <summary>
    /// Przekazuje pieniądze i usuwa je z portfela lub wyświetla o braku środków 
    /// </summary>
    /// <param name="amount"> Przekazywana kwota</param>
    /// <returns>Ilość becelu wyjmowana z portfela lub 0 jeśli brak pieniedzy lub za małe</returns>
    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " Mówi: " + Cash + "nie jest poprawną kwotą");
            return 0;
        }
        if (amount > Cash)
        {
            Console.WriteLine(Name + " mówi: " + "nie mam wystarczających środków, aby ci dać " + amount + " zł. ");
            return 0;
        }
        Cash -= amount;
        return amount;
    }
    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " mówi: " + " nie przyjmę " + amount + "zł.");
        }
        else
        {
            Cash += amount;
        }

    }
    static void Main(string[] args)
    {
        Random random = new Random();
        //double odds = .75;
        Random losowa_szansa = new Random();
        double min = 0.10;
        double max = 0.75;
        double szansa = losowa_szansa.NextDouble() * (max - min) + min;
        Guy player = new Guy { Cash = 100, Name = "Gracz" };
        Guy player1 = new Guy { Cash = 200, Name = "Gracz 2" };
        Console.WriteLine($"Witaj w kasynie. Prawdopodobieństwo przegranej: {szansa:F2}");
        while (player.Cash > 0 && player1.Cash > 0)
        {
            player.WriteMyInfo();
            player1.WriteMyInfo();
            Console.Write("Stawiana kwota gracza 1: ");
            string howMuch = Console.ReadLine();
            Console.Write("Stawiana kwota gracza 2: ");
            string howMuch2 = Console.ReadLine();
            if (howMuch == "") return;
            if (int.TryParse(howMuch, out int amount) && int.TryParse(howMuch2, out int amount2))
            {
                int pot = player.GiveCash(amount) * 2;
                int pot2 = player1.GiveCash(amount2) * 2;
                if (pot > 0 && pot2 > 0)
                {
                    if (random.NextDouble() > szansa)
                    {
                        int winnings = pot;
                        int winnigns1 = pot2;
                        Console.WriteLine("Gracz 1 wygrał" + winnings + " ZŁ.");
                        Console.WriteLine("Gracz 2 wygrał" + winnings + " ZŁ.");
                        player.ReceiveCash(winnings);
                        player1.ReceiveCash(winnigns1);
                    }
                    else
                    {
                        Console.WriteLine("Niestety przegrałeś");
                    }
                }
            }
            else
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }



        }
        Console.WriteLine("Kasyno zawsze wygrywa.");
    }
}
