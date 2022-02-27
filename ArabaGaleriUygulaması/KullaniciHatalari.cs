using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGaleriUygulaması
{
    internal class KullaniciHatalari
    {
        public static string GetString(string metin, int min = 3, int max = 25)
        {
            string txt = string.Empty; // Girilen değer boş veya null bir değer ise.
            bool hata = false;
            do
            {
                Console.Write(metin);
                txt = Console.ReadLine();
                if (txt == " ")
                {
                    Console.WriteLine("Boş Bir Değer Giremezsiniz.");
                    hata = true;
                }
                else
                {
                    if (txt.Length < min || txt.Length > max)
                    {
                        Console.WriteLine("Lütfen min. {0} ile max. {1} Uzunluğunda Bir Metin Girin", min, max);
                        hata = true;
                    }
                    else
                    {
                        try
                        {
                            int.Parse(txt);
                            Console.WriteLine("Lütfen Metinsel Bir İfade Girin.");
                            hata = true;
                        }
                        catch (Exception)
                        {
                            hata = false;
                        }
                    }
                }
            } while (hata);
            return txt;
        }
        public static int GetInt(string metin, int min = int.MinValue, int max = int.MaxValue)
        {
            int sayi = 0;
            bool hata = false;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = int.Parse(Console.ReadLine());
                    if (sayi >= min && sayi <= max)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} arasında bir değer girin.", min, max);
                        hata = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    hata = true;
                }
            } while (hata);
            return sayi;
        }
    }
}
