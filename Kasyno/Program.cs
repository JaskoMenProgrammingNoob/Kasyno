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
            double odds = .75;
            Guy player = new Guy { Cash = 100, Name = "Gracz" };
            Console.WriteLine($"Witaj w kasynie. Prawdopodobieństwo przegranej: {odds}");
            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.Write("Stawiana kwota: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("Wygrałeś: " + winnings + " ZŁ.");
                            player.ReceiveCash(winnings);
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
