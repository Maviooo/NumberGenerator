using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGenerator
{
    class Class1
    {
        public void Wiadomosc()
        {
            System.Windows.Forms.MessageBox.Show("Class 1!");
        }
        public void Generacja(decimal pocz, decimal kon, decimal skok, bool zera, bool dodzera, int dodzeraw, bool pre, string pref, bool suf, string suff)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Liczby.txt",false))
            {
                int zeraW = 0;
                if (zera)
                {
                    
                    
                    decimal max = pocz;
                    for(decimal i =pocz;i<=kon;i+=skok)
                    {
                        if (i > max)
                            max = i;
                    }
               
                    while (max >= 10)
                    {
                        max /= 10;
                        zeraW++;
                    }
                }

                for (; pocz <= kon; pocz += skok)
                {
                    string temp = pocz.ToString();
                    if (zera) /// ZERA WIADOCE
                    {
                        if(dodzera)
                        {
                            temp = temp.PadLeft(zeraW+1+dodzeraw, '0');
                        }
                        else
                            temp = temp.PadLeft(zeraW+1, '0');
                    }
                    if(pre)
                    {
                        temp = pref + temp;
                    }
                    if(suf)
                    {
                        temp = temp + suff;
                    }




                    file.WriteLine(temp);
                }
            }
        }
        public void Gneracja_dzielona(decimal pocz, decimal kon, decimal skok, bool zera, bool dodzera, int dodzeraw, bool pre, string pref, bool suf, string suff, bool wplikow, decimal pliki, bool wrecordow, decimal recordy)
        {

            string sciezka = "Out/Liczby_";
            decimal ilosc = ((kon - pocz) / skok )+1;
            double wynik = Convert.ToDouble(ilosc / recordy);



            if (wrecordow)
            {
                decimal znacznik = pocz;
                int licznik = 0;
                int iloscplikow = 1;
                while (ilosc > recordy)           ///  ile zrobic plikow -- iloscplikow
                {
                    ilosc -= recordy;
                    iloscplikow++;
                }
                int t_iloscplikow = iloscplikow;
                int zerapliki = 1;
                while (t_iloscplikow >= 10)        /// ile zer wiodacych -- zerapliki
                {
                    zerapliki++;
                    t_iloscplikow /= 10;
                }

                DirectoryInfo directory = Directory.CreateDirectory("Out");

                for (int indx = 1; indx <= iloscplikow; indx++)
                {
                    licznik = 0;
                    sciezka = "Out/Liczby_";
                    sciezka += (indx.ToString()).PadLeft(zerapliki, '0') + ".txt";
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(sciezka, false))
                    {
                        int zeraW = 0;
                        if (zera)
                        {


                            decimal max = pocz;
                            for (decimal i = pocz; i <= kon; i += skok)
                            {
                                if (i > max)
                                    max = i;
                            }

                            while (max >= 10)
                            {
                                max /= 10;
                                zeraW++;
                            }
                        }
                        pocz = znacznik;
                        for (; pocz <= kon; pocz += skok)
                        {
                            string temp = pocz.ToString();
                            if (zera) /// ZERA WIADOCE
                            {
                                if (dodzera)
                                {
                                    temp = temp.PadLeft(zeraW + 1 + dodzeraw, '0');
                                }
                                else
                                    temp = temp.PadLeft(zeraW + 1, '0');
                            }
                            if (pre)
                            {
                                temp = pref + temp;
                            }
                            if (suf)
                            {
                                temp = temp + suff;
                            }

                            file.WriteLine(temp);


                            znacznik += skok;
                            licznik++;
                            if (licznik >= recordy)
                                break;
                        }
                    }
                }
            }
            if (wplikow)
            {
                decimal znacznik = pocz;
                int licznik = 0;
                int iloscplikow = decimal.ToInt32(pliki);
                int iloscrec = decimal.ToInt32(((kon - pocz) / skok) + 1);
                int iloscWpliku =1;
                while(iloscrec>iloscplikow)
                {
                    iloscrec -= iloscplikow;
                    iloscWpliku++;
                }
                recordy = iloscWpliku;
                int t_iloscplikow = iloscplikow;
                int zerapliki = 1;
                while (t_iloscplikow >= 10)        /// ile zer wiodacych -- zerapliki
                {
                    zerapliki++;
                        t_iloscplikow /= 10;
                }

                DirectoryInfo directory = Directory.CreateDirectory("Out");

                for (int indx = 1; indx <= iloscplikow; indx++)
                {
                    licznik = 0;
                    sciezka = "Out/Liczby_";
                    sciezka += (indx.ToString()).PadLeft(zerapliki, '0') + ".txt";
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(sciezka, false))
                    {
                         int zeraW = 0;
                         if (zera)
                         {


                             decimal max = pocz;
                             for (decimal i = pocz; i <= kon; i += skok)
                             {
                                 if (i > max)
                                     max = i;
                             }

                             while (max >= 10)
                             {
                                 max /= 10;
                                 zeraW++;
                             }
                         }
                         pocz = znacznik;
                         for (; pocz <= kon; pocz += skok)
                         {
                             string temp = pocz.ToString();
                             if (zera) /// ZERA WIADOCE
                             {
                                 if (dodzera)
                                 {
                                     temp = temp.PadLeft(zeraW + 1 + dodzeraw, '0');
                                 }
                                 else
                                     temp = temp.PadLeft(zeraW + 1, '0');
                             }
                             if (pre)
                             {
                                 temp = pref + temp;
                             }
                             if (suf)
                             {
                                 temp = temp + suff;
                             }

                             file.WriteLine(temp);


                             znacznik += skok;
                             licznik++;
                             if (licznik >= recordy)
                                 break;
                            }
                        }
                    }
            }
        }
        public string[] Generacja_Str(decimal pocz, decimal kon, decimal skok, bool zera, bool dodzera, int dodzeraw, bool pre, string pref, bool suf, string suff)
        {
            string[] wyniki = new string[6];
            int zeraW = 0;
            int iloscrecordow = Decimal.ToInt32(((kon - pocz) / skok) + 1);
            if (zera)
            {


                decimal max = pocz;
                for (decimal i = pocz; i <= kon; i += skok)
                {
                    if (i > max)
                        max = i;
                }

                while (max >= 10)
                {
                    max /= 10;
                    zeraW++;
                }
            }
            string temp;
            int j = 0;
            for (decimal i=pocz; i <= kon; i += skok)
            {
                temp = i.ToString();
                if (zera) /// ZERA WIADOCE
                {
                    if (dodzera)
                    {
                        temp = temp.PadLeft(zeraW + 1 + dodzeraw, '0');
                    }
                    else
                        temp = temp.PadLeft(zeraW + 1, '0');
                }
                if (pre)
                {
                    temp = pref + temp;
                }
                if (suf)
                {
                    temp = temp + suff;
                }

                wyniki[j] = temp;
                j++;
                if (j >= 3)
                    break;
                
            }
            j = 5;
            for (decimal i=(pocz+(iloscrecordow-1)*skok); i <= kon; i -= skok)
            {
                temp = i.ToString();
                if (zera) /// ZERA WIADOCE
                {
                    if (dodzera)
                    {
                        temp = temp.PadLeft(zeraW + 1 + dodzeraw, '0');
                    }
                    else
                        temp = temp.PadLeft(zeraW + 1, '0');
                }
                if (pre)
                {
                    temp = pref + temp;
                }
                if (suf)
                {
                    temp = temp + suff;
                }

                wyniki[j] = temp;
                j--;
                if (j <3)
                    break;

            }
            return wyniki;
        }

    }
}
