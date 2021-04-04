/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 3
**				ÖĞRENCİ ADI............: Abdurrahman DOĞAN
**				ÖĞRENCİ NUMARASI.......: B181210394
**              DERSİN ALINDIĞI GRUP...: 1/B
****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ndp_Odev3
{
    public partial class Form1 : Form
    {
        public Form1()
        {          
            InitializeComponent();
     
        }
        Buzdolabi buzdolabi;
        LedTv ledTv;
        CepTelefonu cepTelefonu;
        Laptop laptop;
        int secilenTelevizyonAdet = 0;
        int secilenBuzdolabiAdet = 0;
        int secilenLaptopAdet = 0;
        int secilenTelefonAdet = 0;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            buzdolabi = new Buzdolabi("Bosch KGN36NL30N", "Bosch", "KGN36NL30N", "Inox", 3500, Convert.ToInt32(buzdolabiAdetTutar.Value), "329 Litre", "A++");
            System.Threading.Thread.Sleep(125);
            ledTv = new LedTv("Samsung QE75Q90RATXTK", "Samsung", "QE75Q90RATXTK", "4K Qled", 4000, Convert.ToInt32(televizyonAdetTutar.Value), "75''", "4K");
            System.Threading.Thread.Sleep(155);
            cepTelefonu = new CepTelefonu("Apple iPhone XS", "Apple", "iPhone XS", "Akıllı Telefon", 2500, Convert.ToInt32(telefonAdetTutar.Value), "64GB", "4GB", "2658mAh");
            System.Threading.Thread.Sleep(185);
            laptop = new Laptop("Monster Abra A5 v13.4", "Monster", "Abra A5 v13.4", "Dizüstü", 6000, Convert.ToInt32(laptopAdetTutar.Value), "15.6''", "1920x1080", "256GB", "16GB", "46.74WH");
            buzdolabiFiyatLabel.Text = Convert.ToString(buzdolabi.hamFiyat);
            buzdolabiStokLabel.Text = Convert.ToString(buzdolabi.stokAdedi);
            televizyonStokLabel.Text = Convert.ToString(ledTv.stokAdedi);
            televizyonFiyatLabel.Text = Convert.ToString(ledTv.hamFiyat);
            laptopFiyatLabel.Text = Convert.ToString(laptop.hamFiyat);
            laptopStokLabel.Text = Convert.ToString(laptop.stokAdedi);
            telefonFiyatLabel.Text = Convert.ToString(cepTelefonu.hamFiyat);
            telefonStokLabel.Text = Convert.ToString(cepTelefonu.stokAdedi);
            hataTextbox.Hide();

            /*
            LedTv l = new LedTv(0);
            System.Threading.Thread.Sleep(250);
            Buzdolabi b = new Buzdolabi(0);
            System.Threading.Thread.Sleep(250);
            CepTelefonu c = new CepTelefonu(0);
            System.Threading.Thread.Sleep(250);
            Laptop la = new Laptop(0);

            buzdolabiFiyatLabel.Text = Convert.ToString(b.hamFiyat);
            buzdolabiStokLabel.Text = Convert.ToString(b.stokAdedi);
            televizyonFiyatLabel.Text = Convert.ToString(l.hamFiyat);
            televizyonStokLabel.Text = Convert.ToString(l.stokAdedi);
            telefonFiyatLabel.Text = Convert.ToString(c.hamFiyat);
            telefonStokLabel.Text = Convert.ToString(c.stokAdedi);
            laptopFiyatLabel.Text = Convert.ToString(la.hamFiyat);
            laptopStokLabel.Text = Convert.ToString(la.stokAdedi);
            */
            buzdolabiPictureBox.ImageLocation = "Buzdolabi.jpg";
            televizyonPictureBox.ImageLocation = "LedTv.jpg";
            laptopPictureBox.ImageLocation = "laptop.jpg";
            telefonPictureBox.ImageLocation = "CepTelefonu.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hataTextbox.Hide();
            Sepet sepet = new Sepet();

            laptop.secilenAdet = Convert.ToInt32(laptopAdetTutar.Value);
            cepTelefonu.secilenAdet = Convert.ToInt32(telefonAdetTutar.Value);
            buzdolabi.secilenAdet = Convert.ToInt32(buzdolabiAdetTutar.Value);
            ledTv.secilenAdet = Convert.ToInt32(televizyonAdetTutar.Value);

            sepet.sepeteUrunEkle(laptop);
            secilenLaptopAdet = sepet.adet;
            if (secilenLaptopAdet > laptop.stokAdedi)
            {
                MessageBox.Show("Stok Adedinden Fazla Ürün Seçtiniz");
                hataTextbox.Show();
            }
            else if (secilenLaptopAdet != 0)
            {
                listBox1.Items.Add(sepet.adet);
                listBox2.Items.Add(sepet.ad);
                listBox3.Items.Add(laptop.kdvUygula());
                laptop.stokAdedi -= secilenLaptopAdet;

            }

            sepet.sepeteUrunEkle(ledTv);
            secilenTelevizyonAdet = sepet.adet;
            if (secilenTelevizyonAdet > ledTv.stokAdedi)
            {
                MessageBox.Show("Stok Adedinden Fazla Ürün Seçtiniz");
                hataTextbox.Show();
            }
            else if (secilenTelevizyonAdet != 0)
            {
                listBox1.Items.Add(sepet.adet);
                listBox2.Items.Add(sepet.ad);
                listBox3.Items.Add(ledTv.kdvUygula());
                ledTv.stokAdedi -= secilenTelevizyonAdet;

            }

            sepet.sepeteUrunEkle(buzdolabi);
            secilenBuzdolabiAdet = sepet.adet;
            if (secilenBuzdolabiAdet > buzdolabi.stokAdedi)
            {
                MessageBox.Show("Stok Adedinden Fazla Ürün Seçtiniz");
                hataTextbox.Show();
            }
            else if (secilenBuzdolabiAdet != 0)
            {
                listBox1.Items.Add(sepet.adet);
                listBox2.Items.Add(sepet.ad);
                listBox3.Items.Add(buzdolabi.kdvUygula());
                buzdolabi.stokAdedi -= secilenBuzdolabiAdet;
                

            }

            sepet.sepeteUrunEkle(cepTelefonu);
            secilenTelefonAdet = sepet.adet;
            if (secilenTelefonAdet > cepTelefonu.stokAdedi)
            {
                MessageBox.Show("Stok Adedinden Fazla Ürün Seçtiniz");
                hataTextbox.Show();
            }
            else if (secilenTelefonAdet != 0)
            {
                listBox1.Items.Add(sepet.adet);
                listBox2.Items.Add(sepet.ad);
                listBox3.Items.Add(cepTelefonu.kdvUygula());
                cepTelefonu.stokAdedi -= secilenTelefonAdet;

            }

            buzdolabiFiyatLabel.Text = Convert.ToString(buzdolabi.hamFiyat);
            buzdolabiStokLabel.Text = Convert.ToString(buzdolabi.stokAdedi);
            televizyonStokLabel.Text = Convert.ToString(ledTv.stokAdedi);
            televizyonFiyatLabel.Text = Convert.ToString(ledTv.hamFiyat);
            laptopFiyatLabel.Text = Convert.ToString(laptop.hamFiyat);
            laptopStokLabel.Text = Convert.ToString(laptop.stokAdedi);
            telefonFiyatLabel.Text = Convert.ToString(cepTelefonu.hamFiyat);
            telefonStokLabel.Text = Convert.ToString(cepTelefonu.stokAdedi);

            if (secilenTelefonAdet <= cepTelefonu.stokAdedi && secilenBuzdolabiAdet <= buzdolabi.stokAdedi && secilenLaptopAdet <= laptop.stokAdedi && secilenTelevizyonAdet <= ledTv.stokAdedi)
            {
                kdvToplamFiyatLabel.Text = Convert.ToString(sepet.kdvliToplamFiyatHesapla(cepTelefonu, ledTv, buzdolabi, laptop)) + "TL";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hataTextbox.Hide();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            
            laptop.stokAdedi += secilenLaptopAdet;
            cepTelefonu.stokAdedi += secilenTelefonAdet;
            buzdolabi.stokAdedi += secilenBuzdolabiAdet;
            ledTv.stokAdedi += secilenTelevizyonAdet;
            
            hataTextbox.Hide();
            buzdolabiFiyatLabel.Text = Convert.ToString(buzdolabi.hamFiyat);
            buzdolabiStokLabel.Text = Convert.ToString(buzdolabi.stokAdedi);
            televizyonStokLabel.Text = Convert.ToString(ledTv.stokAdedi);
            televizyonFiyatLabel.Text = Convert.ToString(ledTv.hamFiyat);
            laptopFiyatLabel.Text = Convert.ToString(laptop.hamFiyat);
            laptopStokLabel.Text = Convert.ToString(laptop.stokAdedi);
            telefonFiyatLabel.Text = Convert.ToString(cepTelefonu.hamFiyat);
            telefonStokLabel.Text = Convert.ToString(cepTelefonu.stokAdedi);

            kdvToplamFiyatLabel.Text = 0 + " TL";
        }
    }
}
