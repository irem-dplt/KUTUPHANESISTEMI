using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KutuphaneProjesi
{
    public partial class Form1 : Form
    {
        // Kütüphane sınıfını çağırıyoruz
        Kutuphane kutuphane = new Kutuphane();

        public Form1()
        {
            InitializeComponent();
        }

        // Tabloyu güncelleyen yardımcı kod
        private void TabloyuGuncelle(List<Kitap> liste)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste;
        }

        // EKLE BUTONU (Senin tasarımında button1)
        private void button1_Click(object sender, EventArgs e)
        {
            // HATA BURADAYDI: label1 yerine txtAd kullanmalıyız
            if (txtAd.Text == "" || txtYazar.Text == "" || txtYil.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                // Verileri Textbox'lardan (Kutulardan) alıyoruz
                string ad = txtAd.Text;
                string yazar = txtYazar.Text;
                int yil = int.Parse(txtYil.Text);

                Kitap yeniKitap = new Kitap(ad, yazar, yil);
                kutuphane.KitapEkle(yeniKitap);

                MessageBox.Show("Kitap Eklendi!");
                TabloyuGuncelle(kutuphane.ListeyiGetir());

                // Kutuları temizliyoruz (Etiketleri değil!)
                txtAd.Clear();
                txtYazar.Clear();
                txtYil.Clear();
            }
            catch
            {
                MessageBox.Show("Yıl kısmına sadece sayı giriniz!");
            }
        }

        // SİL BUTONU (Senin tasarımında button2)
        private void button2_Click(object sender, EventArgs e)
        {
            string silinecek = txtAd.Text; // label1 değil txtAd
            kutuphane.KitapSil(silinecek);
            MessageBox.Show("İşlem tamamlandı.");
            TabloyuGuncelle(kutuphane.ListeyiGetir());
        }

        // ARA BUTONU (Senin tasarımında button3)
        private void button3_Click(object sender, EventArgs e)
        {
            string aranan = txtAd.Text;
            if (aranan == "")
            {
                aranan = txtYazar.Text;
            }

            List<Kitap> sonuc = kutuphane.AramaYap(aranan);
            TabloyuGuncelle(sonuc);
        }

        // LİSTELE BUTONU (Senin tasarımında button4)
        private void button4_Click(object sender, EventArgs e)
        {
            TabloyuGuncelle(kutuphane.ListeyiGetir());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Burası boş kalabilir
        }
    }
}