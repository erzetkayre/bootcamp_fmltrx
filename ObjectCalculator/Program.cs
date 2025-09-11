using ObjectCalculator.PerimeterCalculator;
using ObjectCalculator.AreaCalculator;

namespace ObjectCalculator;

public class Program
{
    static void Main()
    {
        int input;
        do
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("=======  Pilih Jenis Perhitungan  =======");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Hitung Luas");
            Console.WriteLine("2. Hitung Keliling");
            Console.WriteLine("3. Keluar Program\n");

            Console.WriteLine("Masukkan pilihan Anda: ");
            string inputUser = Console.ReadLine();
            input = int.Parse(inputUser);

            switch (input)
            {
                case 1:
                    CalculateAreaOfShape();
                    break;
                case 2:
                    CalculatePerimeterOfShape();
                    break;
                case 3:
                    Console.WriteLine("Program telah berhenti!");
                    break;
                default:
                    Console.WriteLine("Pilihan anda tidak ada, silahkan coba kembali!");
                    break;
            }
        } while (input != 3);

        return;
    }

    static void CalculateAreaOfShape()
    {
        int inputShape;

        Console.WriteLine("========================================");
        Console.WriteLine("======  Pilih Jenis Bidang Datar  ======");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Segitiga");
        Console.WriteLine("2. Persegi");
        Console.WriteLine("3. Persegi Panjang\n");
        Console.WriteLine("Masukkan pilihan Anda: ");
        string chooseShape = Console.ReadLine();
        inputShape = int.Parse(chooseShape);

        var calculator = new Area();
        switch (inputShape)
        {
            case 1:
                Console.WriteLine("=========================================");
                Console.WriteLine("============  Luas Segitiga  ============");
                Console.WriteLine("=========================================\n");

                Console.WriteLine("Masukkan alas segitiga: ");
                string alas = Console.ReadLine();
                int alasInt = int.Parse(alas);

                Console.WriteLine("Masukkan tinggi segitiga: ");
                string tinggi = Console.ReadLine();
                int tinggiInt = int.Parse(tinggi);

                int triangleResult = calculator.Triangle(alasInt, tinggiInt);
                Console.WriteLine($"\nLuas Segitiga Anda adalah {triangleResult}\n");
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                break;

            case 2:
                Console.WriteLine("========================================");
                Console.WriteLine("============  Luas Persegi  ============");
                Console.WriteLine("========================================\n");

                Console.WriteLine("Masukkan panjang sisi persegi: ");
                string sisi = Console.ReadLine();
                int sisiInt = int.Parse(sisi);

                int squareResult = calculator.Square(sisiInt);
                Console.WriteLine($"\nLuas Persegi Anda adalah {squareResult}\n");
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                break;

            case 3:
                Console.WriteLine("========================================");
                Console.WriteLine("========  Luas Persegi Panjang  ========");
                Console.WriteLine("========================================\n");

                Console.WriteLine("Masukkan lebar persegi panjang: ");
                string lebar = Console.ReadLine();
                int lebarInt = int.Parse(lebar);

                Console.WriteLine("Masukkan panjang persegi panjang: ");
                string panjang = Console.ReadLine();
                int panjangInt = int.Parse(panjang);

                int rectangleResult = calculator.Rectangle(panjangInt, lebarInt);
                Console.WriteLine($"\nLuas Persegi Panjang Anda adalah {rectangleResult}\n");
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                break;

            default:
                Console.WriteLine("Pilihan anda tidak ada, silahkan coba kembali!");
                break;
        }
    }

    static void CalculatePerimeterOfShape()
    {
        int inputShape;
        Console.WriteLine("========================================");
        Console.WriteLine("======  Pilih Jenis Bidang Datar  ======");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Segitiga");
        Console.WriteLine("2. Persegi");
        Console.WriteLine("3. Persegi Panjang\n");
        Console.WriteLine("Masukkan pilihan Anda: ");
        string chooseShape = Console.ReadLine();
        inputShape = int.Parse(chooseShape);

        var calculator = new Perimeter();
        switch (inputShape)
        {
            case 1:
                Console.WriteLine("=========================================");
                Console.WriteLine("==========  Keliling Segitiga  ==========");
                Console.WriteLine("=========================================\n");

                Console.WriteLine("Masukkan sisi pertama segitiga: ");
                string sisiSatu = Console.ReadLine();
                int sisiSatuInt = int.Parse(sisiSatu);

                Console.WriteLine("Masukkan sisi kedua segitiga: ");
                string sisiDua = Console.ReadLine();
                int sisiDuaInt = int.Parse(sisiDua);

                Console.WriteLine("Masukkan sisi ketiga segitiga: ");
                string sisiTiga = Console.ReadLine();
                int sisiTigaInt = int.Parse(sisiTiga);

                int triangleResult = calculator.Triangle(sisiSatuInt, sisiDuaInt, sisiTigaInt);
                Console.WriteLine($"\nKeliling Segitiga Anda adalah {triangleResult}\n");
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                break;

            case 2:
                Console.WriteLine("========================================");
                Console.WriteLine("==========  Keliling Persegi  ==========");
                Console.WriteLine("========================================\n");

                Console.WriteLine("Masukkan panjang sisi persegi: ");
                string sisi = Console.ReadLine();
                int sisiInt = int.Parse(sisi);

                int squareResult = calculator.Square(sisiInt);
                Console.WriteLine($"\nKeliling Persegi Anda adalah {squareResult}\n");
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                break;
            case 3:
                Console.WriteLine("========================================");
                Console.WriteLine("======  Keliling Persegi Panjang  ======");
                Console.WriteLine("========================================\n");

                Console.WriteLine("Masukkan lebar persegi panjang: ");
                string lebar = Console.ReadLine();
                int lebarInt = int.Parse(lebar);

                Console.WriteLine("Masukkan panjang persegi panjang: ");
                string panjang = Console.ReadLine();
                int panjangInt = int.Parse(panjang);

                int rectangleResult = calculator.Rectangle(panjangInt, lebarInt);
                Console.WriteLine($"\nKeliling Persegi Panjang Anda adalah {rectangleResult}\n");
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Pilihan anda tidak ada, silahkan coba kembali!");
                break;
        }
    }
}