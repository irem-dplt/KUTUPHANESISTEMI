namespace KutuphaneProjesi
{
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public int Yil { get; set; }

        public Kitap(string ad, string yazar, int yil)
        {
            Ad = ad;
            Yazar = yazar;
            Yil = yil;
        }
    }
}