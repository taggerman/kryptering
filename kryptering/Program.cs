using System.Text;

start:
Console.WriteLine("hej welkommen til krypterings appen-_-");
Console.WriteLine("tryk e for krypter c for de kryptere");

string? valg = Console.ReadLine();
switch (valg)
{
    case "e":
    case "E":
        Kryptering();
        break;
    case "c":
    case "C":
        DeKryptering();
        break;
    default:
        Console.Clear();
        goto start;
}



Console.WriteLine("vil du gå tilbage til start");
Console.WriteLine("så tryk j for ja og n for nej");
string? valg2= Console.ReadLine();
if (valg2 == "j" || valg2 == "J")
{
    Console.Clear();
    goto start;
}



void Kryptering()
{
    Console.Clear();
    Console.WriteLine(" du valgte kryptering");
    Console.WriteLine(" ");
    Console.WriteLine(" indset test for at kryptere");
    string? tekst = Console.ReadLine();

    Console.WriteLine("Enter key");
    string? key = Console.ReadLine();

    byte[] tekstInBytes = Encoding.UTF8.GetBytes(tekst);
    byte[] keyInBytes = Encoding.UTF8.GetBytes(key);

    byte[] kryptering = new byte[tekstInBytes.Length];


    int keyIndex = 0;
    for (int i = 0; i < tekstInBytes.Length; i++)
    {
        kryptering[i] = (byte)(tekstInBytes[i]+keyInBytes[keyIndex]);

        if (keyIndex >=keyInBytes.Length -1)
        {
            keyIndex=0;
        }
        else
        {
            keyIndex++;
        }

    }

    Console.WriteLine(Convert.ToBase64String(kryptering));


}

void DeKryptering()
{
    Console.Clear();
    Console.WriteLine(" du valgte Dekryptering");
    Console.WriteLine(" ");
    Console.WriteLine(" indset test for at Dekryptere");
    string? tekst = Console.ReadLine();

    Console.WriteLine("Enter key");
    string? key = Console.ReadLine();

    byte[] tekstInBytes = Convert.FromBase64String(tekst);
    byte[] keyInBytes = Encoding.UTF8.GetBytes(key);

    byte[] kryptering = new byte[tekstInBytes.Length];


    int keyIndex = 0;
    for (int i = 0; i < tekstInBytes.Length; i++)
    {
        kryptering[i] = (byte)(tekstInBytes[i] - keyInBytes[keyIndex]);

        if (keyIndex >=keyInBytes.Length -1)
        {
            keyIndex=0;
        }
        else
        {
            keyIndex++;
        }

    }

    Console.WriteLine(Encoding.UTF8.GetString(kryptering));
}