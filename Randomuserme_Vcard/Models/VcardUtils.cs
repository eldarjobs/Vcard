using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class VcardUtils
{
    public static string VcardFormat(Vcard vcard)
    {
        return "BEGIN:VCARD\r\n" +
               $"VERSION:3.0\r\n" +
               $"FN:{vcard.Name}{vcard.Surname}\r\n" +
               $"ORG:{vcard.Email}\r\n" +
               $"TEL:{vcard.Phone}\r\n" +
               $"EMAIL:{vcard.City};;{vcard.Country}\r\n" +
               $"END:VCARD\r\n";
    }
    public enum ForFormating
    {
        VCF,
        TXT,
        Both
    }
    public static void SaveVCard(Vcard vcard, string saveDirectory, ForFormating format)
    {
        string vcfFileName = Path.Combine(saveDirectory, $"{vcard.Name}_{vcard.Surname}.vcf");
        string txtFileName = Path.Combine(saveDirectory, $"{vcard.Name}_{vcard.Surname}.txt");

        if (format == ForFormating.VCF || format == ForFormating.Both)
        {


            string vcardData = VcardUtils.VcardFormat(vcard);
            File.WriteAllText(vcfFileName, vcardData);
        }

        if (format == ForFormating.TXT || format == ForFormating.Both)
        {
            string txtData = $"Name: {vcard.Name} {vcard.Surname}\n" +
                             $"Email: {vcard.Email}\n" +
                             $"Phone: {vcard.Phone}\n" +
                             $"Address: {vcard.City}, {vcard.Country}\n";
            File.WriteAllText(txtFileName, txtData);
        }
    }
    public static void VcardDeleter(string saveDirectory)
    {
        try
        {
            if (Directory.Exists(saveDirectory))
            {
                Directory.Delete(saveDirectory, true);
                Console.WriteLine("VCF lerin hamisi silindi.");
            }
            else
            {
                Console.WriteLine("Silinmeli file tapilmadi");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Filelllar silinerken error bash verdi");
        }
    }
}