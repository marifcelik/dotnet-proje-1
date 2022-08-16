namespace dotnet
{
    public static class Islemler
    {
        public static void ekle(this List<Kisi> kisiler)
        {
            Console.WriteLine("\nkişi ekleme\n");
            Console.Write("adı : ");
            string ad = Console.ReadLine();
            Console.Write("soyadı : ");
            string soyad = Console.ReadLine();
        tekrar:
            Console.Write("numara : ");
            bool parsing = long.TryParse(Console.ReadLine(), out long numara);
            if (!parsing)
            {
                Console.WriteLine("lütfen geçerli bir numara giriniz");
                goto tekrar;
            }

            kisiler.Add(new Kisi(ad, soyad, numara));
            Console.WriteLine("\nişlem tamamlandı\n");
        }

        public static void sil(this List<Kisi> kisiler)
        {
        Ara:
            int index = ara(kisiler, "lütfen silmek istediğiniz kişinin bilgisini giriniz (ad / soyad) : ");
            if (index < 0)
            {
                Console.WriteLine("\nböyle bir kişi bulunmadı, ne yapmak istersiniz ?");
                Console.WriteLine("1) yeniden ara");
                Console.WriteLine("2) vazgeç");
                Console.Write("seçiminiz : ");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        goto Ara;
                    case 2:
                        Console.WriteLine("vazgeçildi\n");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0}", kisiler[index].ToString());
                Console.Write("kişi rehberden silinmek üzere, onaylıyor musunuz ? (y/n) : ");
                string secim = Console.ReadLine().ToLower();
                if (secim == "y")
                {
                    kisiler.RemoveAt(index);
                    Console.WriteLine("işlem başarılı\n");
                }
                else
                {
                    Console.WriteLine("vazgeçildi\n");
                }

            }
        }

        public static void guncelle(this List<Kisi> kisiler)
        {
        Ara:
            int index = ara(kisiler, "lütfen güncellemek istediğiniz kişinin bilgisini giriniz (ad / soyad) : ");
            if (index < 0)
            {
                Console.WriteLine("\nböyle bir kişi bulunmadı, ne yapmak istersiniz ?");
                Console.WriteLine("1) yeniden ara");
                Console.WriteLine("2) vazgeç");
                Console.Write("seçiminiz : ");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        goto Ara;
                    case 2:
                        Console.WriteLine("vazgeçildi\n");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                string yeniAd, yeniSoyad;
                long yeniNum;
                Console.WriteLine("{0}", kisiler[index].ToString());

                Console.Write("ad (d:{0}) :", kisiler[index].Ad);
                yeniAd = Console.ReadLine();
                yeniAd = yeniAd == "" ? kisiler[index].Ad : yeniAd;

                Console.Write("soyad (d:{0}) :", kisiler[index].Soyad);
                yeniSoyad = Console.ReadLine();
                yeniSoyad = yeniSoyad == "" ? kisiler[index].Soyad : yeniSoyad;

            Tekrar:
                Console.Write("numara (d:{0}) :", kisiler[index].Numara);
                var kontrol = Console.ReadLine();
                if (kontrol != "")
                {
                    while (!long.TryParse(Console.ReadLine(), out yeniNum))
                    {
                        Console.WriteLine("geçerli bir numara giriniz");
                        goto Tekrar;
                    }
                }
                else
                    yeniNum = kisiler[index].Numara;

                kisiler[index] = new Kisi(yeniAd, yeniSoyad, yeniNum);

                Console.WriteLine("işlem başarılı\n");
            }
        }

        public static void listele(this List<Kisi> kisiler)
        {
            int i = 1;
            Console.WriteLine();
            foreach (var kisi in kisiler)
            {
                Console.WriteLine("*** " + i++ + " ***");
                Console.WriteLine("ad : {0}", kisi.Ad);
                Console.WriteLine("soyad : {0}", kisi.Soyad);
                Console.WriteLine("numara : {0}", kisi.Numara);
            }
            Console.WriteLine("\nişlem tamamlandı\n");
        }

        public static void araVeListele(this List<Kisi> kisiler)
        {
            Console.Write("\narama yapmak istediğiniz bilgiyi giriniz (ad, soyad veya numara) : ");
            string aranacakKelime = Console.ReadLine();

            List<Kisi> bulunanlar = kisiler.FindAll(s => s.Ad == aranacakKelime);
            bulunanlar.AddRange(kisiler.FindAll(s => s.Soyad == aranacakKelime));
            if (long.TryParse(aranacakKelime, out long aranacakNumara))
                bulunanlar.AddRange(kisiler.FindAll(s => s.Numara == aranacakNumara));

            int i = 1;
            Console.WriteLine("\narama sonuçlarınız\n");
            foreach (Kisi kisi in bulunanlar)
            {
                Console.WriteLine("*** " + i++ + " ***");
                Console.WriteLine("ad : {0}", kisi.Ad);
                Console.WriteLine("soyad : {0}", kisi.Soyad);
                Console.WriteLine("numara : {0}", kisi.Numara);
            }
            Console.WriteLine("\nişlem tamamlandı");
        }

        public static int ara(List<Kisi> kisiler, string msg)
        {
            int index;
            Console.Write(msg);
            string aranacakKelime = Console.ReadLine();

            if (long.TryParse(aranacakKelime, out long num))
                index = kisiler.BinarySearch(new Kisi() { Numara = num }, new KisiComparerAd());
            else
            {
                kisiler.Sort(new KisiComparerAd());
                index = kisiler.BinarySearch(new Kisi() { Ad = aranacakKelime }, new KisiComparerAd());
                if (index < 0)
                {
                    kisiler.Sort(new KisiComparerSoyad());
                    index = kisiler.BinarySearch(new Kisi() { Soyad = aranacakKelime }, new KisiComparerSoyad());
                }
            }

            return index;
        }
    }
}
