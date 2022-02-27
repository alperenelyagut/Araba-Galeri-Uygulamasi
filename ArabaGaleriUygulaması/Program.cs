using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGaleriUygulaması
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.ArabaEkle();
            ConsoleKey secim;
            do
            {
                Console.Clear();
                Console.WriteLine("***** ARABA GALERİ UYGULAMASINA HOŞGELDİNİZ *****");
                Console.WriteLine();
                Console.WriteLine("1. Otomobil Ekle");
                Console.WriteLine("2. Otomobil Sil");
                Console.WriteLine("3. Otomobil Listele");
                Console.WriteLine("4. Zam Uygula");
                Console.WriteLine("5. İndirim Uygula");
                Console.WriteLine("0. Çıkış");
                Console.WriteLine();
                Console.Write("Lütfen seçim yapınız: ");
                secim = Console.ReadKey().Key;
                Menu.Islemler(secim);

            } while (secim!=ConsoleKey.NumPad0 && secim!=ConsoleKey.D0);
            Console.Clear();
            Console.WriteLine("Uygulamayı Kapattığınız için teşekkürler");
            Console.ReadKey();
        }
    }
}
