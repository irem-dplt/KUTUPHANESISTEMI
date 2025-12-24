using System.Collections.Generic;

namespace KutuphaneProjesi
{
    class Kutuphane
    {
        public List<Kitap> kitaplar = new List<Kitap>();

        public void KitapEkle(Kitap k)
        {
            kitaplar.Add(k);
        }

        public void KitapSil(string silinecekAd)
        {
            Kitap silinecek = null;
            foreach (var k in kitaplar)
            {
                if (k.Ad.ToLower() == silinecekAd.ToLower())
                {
                    silinecek = k;
                    break;
                }
            }
            if (silinecek != null)
            {
                kitaplar.Remove(silinecek);
            }
        }

        public List<Kitap> AramaYap(string arananKelime)
        {
            List<Kitap> sonuclar = new List<Kitap>();
            foreach (var k in kitaplar)
            {
                if (k.Ad.ToLower().Contains(arananKelime.ToLower()) ||
                    k.Yazar.ToLower().Contains(arananKelime.ToLower()))
                {
                    sonuclar.Add(k);
                }
            }
            return sonuclar;
        }

        public List<Kitap> ListeyiGetir()
        {
            return kitaplar;
        }
    }
}