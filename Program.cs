using System;

namespace Odev_01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Direkt metotları Main fonksiyonunda çağırmak yerine bütün hesaplamaları
             AlanHesaplayici class'ının içinde aldık
             * Burada sadece döngü oluşturarak sonsuza kadar programın çalışmasını, try catch içine alarak
             hataların önlenmesini ve kullanıcıdan değer alarak programın çalışmasını sağladık
             (Aldığımız değerler sadece kullanıcının yapmak istediği işlem (Kare Alan Hesaplama vs.))
             (Geri kalan bütün değerler (kenar uzunlukları vs.) direkt olarak metotların içinde alınıyor.)
            */


            while (true) // Sonsuza kadar hesaplama yapılabilmesi için while(true) yazdık
            {
                try // Hata alınca programın çökmemesi için try{} catch(){} oluşturduk
                {
                    string islem = "";
                    Console.Write("(1) Kare Alanı Hesaplama\n(2) Dikdörtgen Alanı Hesaplama\n(3) Çember Alanı Hesaplama\n(q) Çıkış\nİşlem Seçiniz: ");

                    islem = Console.ReadLine(); // kullanıcının seçtiği islem değerini aldık

                    if (islem == "q" || islem == "Q")
                    {
                        // Eğer alınan değer q veya Q ise döngüyü kır (programdan çık)
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;
                    }

                    new AlanHesaplayici(islem); // AlanHesaplayici class'ını direkt olarak çağırdık
                    // AlanHesaplayici a = new AlanHesaplayici(islem) yapmak yerine direkt new AlanHesaplayici(islem) yaptık
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message); // Eğer program çökerse hatanın ne olduğu ekrana yazdırılır ve programın çökmesi engellenir
                }
            }
        }
    }

    class AlanHesaplayici
    {
        public AlanHesaplayici(string islem) // Class çağırıldığı anda string bir değer alınmasını sağladık
        {
            if (islem == "1")
            {
                // Constructor metodumuza islem değeri 1 gelmişse KareAlanHesapla metodunu çağır
                KareAlanHesapla();
            }
            else if (islem == "2")
            {
                // Constructor metodumuza islem değeri 2 gelmişse DikdortgenAlanHesapla metodunu çağır
                DikdortgenAlanHesapla();
            }
            else if (islem == "3")
            {
                // Constructor metodumuza islem değeri 3 gelmişse CemberAlanHesapla metodunu çağır
                CemberAlanHesapla();
            }
            else
            {
                Console.WriteLine("Yanlış İşlem Seçtiniz!");
            }
        }

        void KareAlanHesapla()
        {
            // Kare Alanı = kenar*kenar (kenarın karesi)

            double kenar, sonuc;

            Console.Write("\nKarenin bir kenarının uzunluğunu giriniz: ");
            kenar = Convert.ToDouble(Console.ReadLine()); // Kullanıcıdan kenar değerini aldık

            sonuc = kenar * kenar; // Kullanıcıdan alınan kenar değerini oluşturduğumuz sonuç değişkenine hesaplayarak eşitledik

            Console.WriteLine("\nKarenin Alanı: " + sonuc + "\n"); // Ekrana karenin alanını yazdırdık
        }
        void DikdortgenAlanHesapla()
        {
            // Dikdörtgen Alanı = kısaKenar * uzunKenar

            double kKenar, uKenar, sonuc;

            Console.Write("\nDikdörtgenin kısa kenarının uzunluğunu giriniz: ");
            kKenar = Convert.ToDouble(Console.ReadLine()); // Kullanıcıdan kısa kenar değerini aldık
            
            Console.Write("Dikdörtgenin uzun kenarının uzunluğunu giriniz: ");
            uKenar = Convert.ToDouble(Console.ReadLine()); // Kullanıcıdan uzun kenar değerini aldık

            sonuc = kKenar * uKenar; // Kullanıcıdan alınan kenar değerlerini oluşturduğumuz sonuç değişkenine hesaplayarak eşitledik

            Console.WriteLine("\nDikdörtgenin Alanı: " + sonuc + "\n");

        }
        void CemberAlanHesapla()
        {
            // Çember Alanı: pi * yarıçap

            double yaricap, sonuc;

            Console.Write("\nÇemberin yarıçapının uzunluğunu giriniz: ");
            yaricap = Convert.ToDouble(Console.ReadLine()); // Kullanıcıdan yarıçap değişkenini aldık

            sonuc = MathF.PI * yaricap; // Kullanıcıdan alınan yarıçap değerini
            // MathF.pi sınıfından pi değerini alarak çarptık ve sonuç değişkenine eşitledik.

            Console.WriteLine("\nÇemberin Alanı: " + sonuc + "\n");
        }
    }

}
