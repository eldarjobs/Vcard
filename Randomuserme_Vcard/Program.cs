using System;
using System.IO;
using System;
using System.IO;
using System.Threading.Tasks;
using static HttpRequest;
using static VcardUtils;
using System.Globalization;

public class Program
{
    private static readonly string saveDirect = "Vcards";
    public static async Task Main(string[] args)
    {
        Directory.CreateDirectory(saveDirect);
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Random user vcard generator -a xosh gelmisiziniz");
            Thread.Sleep(1000);
            Console.WriteLine("1. Randomuser vcard generate et");
            Console.WriteLine("2. Randomuser manual vcard generate et");
            Console.WriteLine("3. Yaradilan vcardlari sil");
            Console.WriteLine("4. Cixis et");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await CreateVCardsAsync();
                    break;
                case "2":
                    await CreateVCardsManualAsync();
                    break;
                case "3":
                    await VcardDeleter(saveDirect);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Yanlis daxil edin");
                    break;
            }
            if (!exit)
            {
                Console.WriteLine("Devam etmek isteyirsiniz? (y/n)");
                Console.ReadKey();

            }
        }
    }

    public static async Task VcardDeleter(string saveDirectory)
    {
        Console.WriteLine("Yaradilan vcardlari silmek isteyirsiniz? (y/n)");
        string input = await Task.Run(() => Console.ReadLine());
        if (input.ToLower() == "y")
        {
            VcardDeleter(saveDirectory);
        }
    }

    static async Task CreateVCardsAsync()
    {
        while (true)
        {
            Console.Write("Yaratmaq istediyiniz Vcard sayini qeyd edin");
            string input = Console.ReadLine();

            if (input.ToLower() == "e")
                break;

            if (!int.TryParse(input, out int count) || count <= 0)
            {
                Console.WriteLine("Tam eded daxil edin");
                continue;
            }

            var data = await GetAsyncdata(count);
            if (data.data != null)
            {
                Vcard[] vcards = WriteUserData(data.data);

                ForFormating selectedFormat = GetUserFileFormat();
                SaveVCards(vcards, saveDirect, selectedFormat);

                Console.WriteLine($"Cemi {vcards.Length} vCard yaradildi ve save olundu.");
            }
            else
            {
                Console.WriteLine("Melumatlari elde etmek alinmadi. Yeniden cehd edin");
            }
        }
    }
    static async Task CreateVCardsManualAsync()
    {
        while (true)
        {
            Console.Write("Yaratmaq istediyiniz Vcard sayini qeyd edin");
            string input = Console.ReadLine();

            if (input.ToLower() == "e")
                break;

            if (!int.TryParse(input, out int count) || count <= 0)
            {
                Console.WriteLine("Tam eded daxil edin");
                continue;
            }
            Console.WriteLine("Vcard olkesini sechin.Meselen:us,tr,fr,gb,au");
            string country = Console.ReadLine();

            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("Yanliş olke. Melumatlari duzgun daxil edin.");
                continue;
                continue;
            }
            var data = await GetManualAsyncdata(count, country);
            if (data.data != null)
            {
                Vcard[] vcards = WriteUserData(data.data);

                ForFormating selectedFormat = GetUserFileFormat();
                SaveVCards(vcards, saveDirect, selectedFormat);

                Console.WriteLine($"Cemi {vcards.Length}  vCard yaradildi ve save olundu.");
            }
            else
            {
                Console.WriteLine("Melumatlari elde etmek alinmadi. Yeniden cehd edin");
            }
        }
    }
    static bool ValidCard(Vcard vcard)
    {
        return !string.IsNullOrEmpty(vcard.Name) && !string.IsNullOrWhiteSpace(vcard.Surname);



    }
    static ForFormating GetUserFileFormat()
    {
        while (true)
        {
            Console.WriteLine("Vcard formatini sechin");
            Console.WriteLine("1. VCF");
            Console.WriteLine("2. TXT");
            Console.WriteLine("3.Her iki format");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return ForFormating.VCF;
                case "2":
                    return ForFormating.TXT;
                case "3":
                    return ForFormating.Both;
                default:
                    Console.WriteLine("Error meydana geldi");
                    break;
            }
        }
    }
    static void SaveVCards(Vcard[] vcards, string saveDirectory, ForFormating selectedFormat)
    {
        foreach (var vcard in vcards)
        {
            SaveVCard(vcard, saveDirectory, selectedFormat);
        }
    }
}


