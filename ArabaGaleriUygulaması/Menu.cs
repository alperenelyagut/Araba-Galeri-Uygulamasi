using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGaleriUygulaması
{
    public class Menu
    {
        static List<OtomobilEkle> otomobiller = new List<OtomobilEkle>();

        public static void ArabaEkle()
        {
            otomobiller = new List<OtomobilEkle>();
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Bmw",
                Model = "3.16i",
                UretimYili = 2016,
                Renk = "Gri",
                Fiyat = 600000
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Mercedes",
                Model = "Benz",
                UretimYili = 2018,
                Renk = "Siyah",
                Fiyat = 150000
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Mercedes",
                Model = "C-Class",
                UretimYili = 2022,
                Renk = "Siyah",
                Fiyat = 150000000
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Audi",
                Model = "A3",
                UretimYili = 2020,
                Renk = "Siyah",
                Fiyat = 707000
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Audi",
                Model = "A4",
                UretimYili = 2018,
                Renk = "Mat",
                Fiyat = 1217000
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Citroen",
                Model = "C3",
                UretimYili = 2022,
                Renk = "Beyaz",
                Fiyat = 296000
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Honda",
                Model = "Civic",
                UretimYili = 2022,
                Renk = "Beyaz",
                Fiyat = 525870
            });
            otomobiller.Add(new OtomobilEkle()
            {
                Marka = "Jeep",
                Model = "Renegade",
                UretimYili = 2021,
                Renk = "Beyaz",
                Fiyat = 660000
            });
        }
        public static void Islemler(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    OtomobilEkle("Otomobil Ekle");
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    OtomobilSil("Otomobil Sil");
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    OtomobilListele("Otomobil Listele");
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    ZamUygula("Zam Uygula");
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    IndirimUygula("İndirim Uygula");
                    break;
            }
        }
        private static void IndirimUygula(string v)
        {
            Baslik(" ");
            int indirimUygula = KullaniciHatalari.GetInt("İndirim Oranı Giriniz: ",5,30);
            for (int i = 0; i < otomobiller.Count; i++)
                otomobiller[i].Fiyat = (otomobiller[i].Fiyat) - (otomobiller[i].Fiyat * indirimUygula / 100);

            AnaMenu("Tüm otomobillere indirim uygulandı.");
        }

        private static void ZamUygula(string v)
        {
            Baslik(" ");
            int zamUygula = KullaniciHatalari.GetInt("Zam Oranı Giriniz: ",5,30);
            for (int i = 0; i < otomobiller.Count; i++)
                otomobiller[i].Fiyat = (otomobiller[i].Fiyat) + (otomobiller[i].Fiyat * zamUygula / 100);
            
            AnaMenu("Tüm otomobillere zam uygulandı.");
        }

        private static void OtomobilListele(string v)
        {
            Console.Clear();
            Baslik(v);
            if (otomobiller.Count > 0)
            {
                for (int i = 0; i < otomobiller.Count; i++)
                    otomobiller[i].EkranaYazdir2(i + 1);
            
                Console.WriteLine(string.Format("Toplam {0} Adet Araç Listelendi", otomobiller.Count));
                Baslik(" ");
                Console.WriteLine("*****Arama Seçenekleri*****");
                Console.WriteLine();
                Console.WriteLine("1.Markaya Göre Arama");
                Console.WriteLine("2.Üretim Yılına Göre Ara");
                Console.WriteLine("3.Fiyatına Göre Ara");
                Console.WriteLine("4.Tüm Otomobilleri Listele");
                Console.WriteLine("0.Ana Menüye Dön");
                Console.WriteLine();
                Console.Write("Seçim: ");
                ConsoleKey info = Console.ReadKey().Key;
                Baslik(" ");
                aramaSecim(info);
            }
            else
                AnaMenu("Listelenecek Araç Bulunamadı");
        }
        private static void OtomobilSil(string v)
        {
            Console.Clear();
            Baslik(v);
            for (int i = 0; i < otomobiller.Count; i++)
                 otomobiller[i].EkranaYazdir(i + 1);
           
            Console.WriteLine();
            int siraNo = KullaniciHatalari.GetInt("Silmek İstediğiniz Otomobil Sıra Numarasını Giriniz: ", 1, otomobiller.Count);
            int indexNo = siraNo - 1;
            Console.Write(otomobiller[indexNo].TamAdi + " Otomobili Silmek İstediğinize Emin Misiniz?(e) ");

            if (Console.ReadKey().Key == ConsoleKey.E)
            {
                string silinen = otomobiller[indexNo].TamAdi;
                otomobiller.RemoveAt(indexNo);
                AnaMenu(silinen + " İsimli Otomobil Silinmiştir.");
            }
            else
                AnaMenu("Silme İşlemi İptal Edildi");
        }

        public static void OtomobilEkle(string v)
        {
            Console.Clear();
            Baslik(v);
            OtomobilEkle otomobilBilgileri = new OtomobilEkle();
            otomobilBilgileri.Marka = KullaniciHatalari.GetString("Marka Adı: ");
            otomobilBilgileri.Model = KullaniciHatalari.GetString("Model Adı: ");
            otomobilBilgileri.UretimYili = KullaniciHatalari.GetInt("Üretim Yılı: ");
            otomobilBilgileri.Renk = KullaniciHatalari.GetString("Renk: ");
            otomobilBilgileri.Fiyat = KullaniciHatalari.GetInt("Fiyat: ");
            otomobiller.Add(otomobilBilgileri);
        }
        public static void Baslik(string v)
        {
            Console.WriteLine(v);
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }
        private static void AnaMenu(string v)
        {
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Ana Menüye Dönmek İçin Bir Tuşa Basınız");
            Console.ReadKey();
        }
        public static void aramaSecim(ConsoleKey key)
        {
            string aranacakMarka;
            int aranacakUretimYili;
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    aranacakMarka = KullaniciHatalari.GetString("Aranacak kelime yazın: ");
                    aranacakKelime(aranacakMarka);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine();
                    aranacakUretimYili = KullaniciHatalari.GetInt("Üretim yılını yazın: ",1950,2022);
                    aranacakKelime2(aranacakUretimYili);
                    break;

                case ConsoleKey.D3: 
                case ConsoleKey.NumPad3:
                    Console.WriteLine();
                    aranacakKelime3();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.WriteLine();
                    aranacakKelime4();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Console.WriteLine();
                    AnaMenu(" ");
                    break;
            }
        }

        public static void aranacakKelime(string temp)
        {
            string aranacakKelime = temp;
            int sayac = 0;
            Baslik(" ");

            for (int i = 0; i < otomobiller.Count; i++)
            {
                if (otomobiller[i].Marka == aranacakKelime)
                {
                    sayac++;
                    otomobiller[i].EkranaYazdir2(i + 1);
                }
                else
                    continue;
            }
            if (sayac == 0)
                Console.WriteLine("Sonuç Bulunamadı.");
            AnaMenu(string.Format("Toplam {0} Adet Araç Listelendi", sayac));
        }
        public static void aranacakKelime2(int temp)
        {
            int aranacakKelime = temp;
            int sayac = 0;

            Baslik(" ");
            for (int i = aranacakKelime; i <= DateTime.Now.Year; i++)
            {
               aranacakKelime++;

                for (int j = 0; j < otomobiller.Count; j++)
                {
                    if (aranacakKelime-1 == otomobiller[j].UretimYili)
                    {
                        sayac++;
                        otomobiller[j].EkranaYazdir2(j + 1);
                    }
                }
            }
            if (sayac == 0)
                Console.WriteLine("Sonuç Bulunamadı.");
            AnaMenu(string.Format("Toplam {0} Adet Araç Listelendi", sayac));
        }
        public static void aranacakKelime3()
        {
            int sayac = 0;
            int altSinir = KullaniciHatalari.GetInt("Fiyat Alt Sınırı Yazın: ");
            int ustSinir = KullaniciHatalari.GetInt("Fiyat Üst Sınırı Yazın: ");
            Baslik(" ");
            for (int i = 0; i < otomobiller.Count; i++)
            {
                if (altSinir<otomobiller[i].Fiyat && ustSinir >otomobiller[i].Fiyat)
                {
                    sayac++;
                    otomobiller[i].EkranaYazdir2(i + 1);
                }
            }
            if (sayac == 0)
                Console.WriteLine("Sonuç Bulunamadı.");
            AnaMenu(string.Format("Toplam {0} Adet Araç Listelendi", sayac));
        }

        private static void aranacakKelime4()
        {
            Console.Clear();
            int sayac = 0;
            for (int i = 0; i < otomobiller.Count; i++)
            {
                sayac++;
                otomobiller[i].EkranaYazdir2(i + 1);
            }
            AnaMenu(string.Format("Toplam {0} Adet Araç Listelendi", sayac));
        }
    }
}
