using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGaleriUygulaması
{
    public class OtomobilEkle
    {
        public string Marka { get ; set; }
        public string Model { get; set; }
        public int UretimYili { get; set; }
        public string Renk { get; set; }
        public int Fiyat { get; set; }
        public string TamAdi
        {
            get { return Marka + " " + Model; }
        }
        public string TamAdi2
        {
            get { return "Marka: "+Marka+ " Model: " +Model+ " Üretim Yılı: " +UretimYili+ " Renk: " +Renk+ " Fiyat: " +Fiyat; }
        }
        public void EkranaYazdir(int sira)
        {
            Console.WriteLine(sira + "- " + TamAdi);
        }
        public void EkranaYazdir2(int sira)
        {
            Console.WriteLine(sira + "- " + TamAdi2);
        }
    }
}
