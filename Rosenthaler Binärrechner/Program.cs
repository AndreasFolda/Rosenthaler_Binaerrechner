using System.Numerics;

internal class Rosenthaler_Binaerrechner
{
    private static void Main(string[] args)
    {
        var rechner = new Rosenthaler_Binaerrechner();
        BigInteger zahl = rechner.Eingabe();
        int max_i = rechner.findMax(zahl);
        rechner.Rechnung(zahl, max_i);
    }

    public BigInteger Eingabe()
    {
        bool richtigeEingabe = false;
        BigInteger zahl = 0;
        string? input;
        while (richtigeEingabe == false)
        {
            Console.WriteLine("Bitte geben Sie eine ganze positive Zahl ein: ");
            input = Console.ReadLine();
            try
            {
                zahl = Int128.Parse(input);
                if (zahl >= 0)
                {
                    richtigeEingabe = true;
                    return zahl;
                }
            }
            catch (Exception) { }
        }
        return zahl;
    }

    public int findMax(BigInteger zahl)
    {
        int max_i;

        for (int i = 0; i < zahl; i++)
        {
            var zwischenZahl = zahl - BigInteger.Pow(2, i);
            if (zwischenZahl < 0)
            {
                Console.WriteLine("Die größte Zahl die wir zerlegen können ist: " + Math.Pow(2, i - 1));
                max_i = i - 1;
                return max_i;
            }
        }
        return 0;
    }

    public void Rechnung(BigInteger zahl, int max_i)
    {
        bool rechnungBeendet = false;
        List<int> output = new List<int>();
        Console.WriteLine("'Berechne' die Binärzahl....");
        if (zahl == 0)
        {
            ;
            rechnungBeendet = true;
        }
        else
        {
            while (max_i >= 0 && rechnungBeendet == false)
            {
                BigInteger abzug = BigInteger.Pow(2, max_i);
                BigInteger zwischenZahl = zahl - abzug;
                if (zwischenZahl >= 0)
                {
                    output.Add(1);
                    zahl = zwischenZahl;
                    Console.WriteLine("Wir sind und sehr sicher dass in der Zerlegung der Zahl nach der Rosenthaler Ratewissenschaft die Zahl " + abzug + " benötigt wird"!);
                    Console.WriteLine("Füge eine 1 hinzu!");
                    Thread.Sleep(100);
                }
                else
                {
                    output.Add(0);
                    Console.WriteLine("Wir sind und sehr sicher dass in der Zerlegung der Zahl nach der Rosenthaler Ratewissenschaft die Zahl " + abzug + " NICHT benötigt wird"!);
                    Console.WriteLine("Füge eine 0 hinzu!");
                    Thread.Sleep(100);
                }
                max_i--;
            }
        }
        string result = string.Join("", output);
        Console.WriteLine("Die Binärzahl ist ziemlich sicher:");
        if (result.Length == 0) { Console.WriteLine("0"); }
        else { Console.WriteLine(result); }
    }
}