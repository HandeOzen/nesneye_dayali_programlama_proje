/****************************************************************************
**                        SAKARYA ÜNİVERSİTESİ
**            BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**              BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                NESNEYE DAYALI PROGRAMLAMA DERSİ
**                    2019-2020 BAHAR DÖNEMİ
**
**           PROJE NUMARASI.........: 01
**           ÖĞRENCİ ADI............:HANDE ÖZEN
**           ÖĞRENCİ NUMARASI.......:B181200048
**           DERSİN ALINDIĞI GRUP...: A
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ndp_Odev3
{
    class Buzdolabi : Urun
    {
        string icHacim;
        string enerjiSinifi;
        

        public Buzdolabi(string ad,string marka,string model,string ozellik,double hamFiyat,int secilenAdet,string icHacim,string enerjiSinifi)
        {
            this.ad=ad;
            this.marka=marka;
            this.model=model;
            this.ozellik=ozellik;
            this.hamFiyat=hamFiyat;
            this.secilenAdet = secilenAdet;    
            this.icHacim=icHacim;
            this.enerjiSinifi=enerjiSinifi;
        }
        public double kdvUygula()
        {
            return hamFiyat * 1.05 * secilenAdet;
        }
    }
}
