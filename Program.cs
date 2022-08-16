using System;

namespace dotnet
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Kisi> kisiler = new List<Kisi>();
            kisiler.Add(new Kisi("arif", "celik", 5551114422));
            kisiler.Add(new Kisi("bruce", "wayne", 9999999999));
            kisiler.Add(new Kisi("dwight", "schrute", 555236578));
            kisiler.Add(new Kisi("finn", "mertens", 7851254632));
            kisiler.Add(new Kisi("tom", "hardy", 7852632120));

            int secim;

            do
            {
                Console.WriteLine("\nlütfen yapmak istediğiniz işlemi seçiniz\n");
                Console.WriteLine("1 ) yeni numara kaydet");
                Console.WriteLine("2 ) numara sil");
                Console.WriteLine("3 ) numara güncelle");
                Console.WriteLine("4 ) rehberi listele");
                Console.WriteLine("5 ) rehberde arama yap");
                Console.WriteLine("9 ) çıkış\n");
            adım:
                Console.Write("seçiminiz : ");
                int.TryParse(Console.ReadLine(), out secim);

                switch (secim)
                {
                    case 1:
                        kisiler.ekle();
                        break;
                    case 2:
                        kisiler.sil();
                        break;
                    case 3:
                        kisiler.guncelle();
                        break;
                    case 4:
                        kisiler.listele();
                        break;
                    case 5:
                        kisiler.araVeListele();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("lütfen geçerli bir seçim yapınız.");
                        goto adım;
                }

            } while (secim != 9);
        }
    }
}
