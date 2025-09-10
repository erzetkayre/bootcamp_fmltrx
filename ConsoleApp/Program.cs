using System.Diagnostics.CodeAnalysis;

namespace SyntaxPractice
{
    public class Program
    {
        // Main Program
        public static void Main()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("==== C# SYNTAX FUNDAMENTALS DEMONSTRATION =====");
            Console.WriteLine("===============================================\n");

            DemoIdentifiers();
            InputNumberAndCondition();
        }

        // Methods 
        private static void DemoIdentifiers()
        {
            Console.WriteLine("1. IDENTIFIERS AND KEYWORDS\n");

            // Uji Coba camelCase
            int EmployeeAge = 27;
            string EmployeeName = "John Doe";
            bool isEmployee = true;
            double EmplyeeScore = 93.23;

            Console.WriteLine($"Nama {EmployeeName}, usia {EmployeeAge}, hasil ujian {EmplyeeScore}");
            Console.WriteLine($"Apakah Karyawan? {isEmployee}");

            // Uji Coba Penulisan PascalCase
            var calculatorApp = new SimpleCalculator();
            int addNumber = calculatorApp.AddNumbers(5, 8);
            int multiplyNumber = calculatorApp.MultiplyNumbers(5, 8);
            Console.WriteLine($"Hasil 5 ditambah dengan 8 adalah {addNumber}, hasil 5 dikali 8 adalah {multiplyNumber}");

            // Demo Excape Sequence
            string usingBackslash = "Demo Excape Sequence using (\\) = C:\\Users\\alif\\AppData";
            string usingSymbol = @" and using (@) AppData = C:\Users\alif\AppData";
            Console.WriteLine(usingBackslash + usingSymbol);
            Console.WriteLine("===============================================\n");
        }

        // Input User and Condition
        private static void InputNumberAndCondition()
        {
            Console.WriteLine("Masukkan Angka Pertama:");
            string inputUser = Console.ReadLine();
            Console.WriteLine("Masukkan Angka Kedua:");
            string inputUser2 = Console.ReadLine();

            int valueInt1 = int.Parse(inputUser);
            int valueInt2 = int.Parse(inputUser2);


            var calculatorApp = new SimpleCalculator();
            int addition = calculatorApp.AddNumbers(valueInt1, valueInt2);
            int subtraction = calculatorApp.SubtractNumbers(valueInt1, valueInt2);
            int multiply = calculatorApp.MultiplyNumbers(valueInt1, valueInt2);
            int division = calculatorApp.DivisionNumbers(valueInt1, valueInt2);

            // Check Condition
            if (valueInt1 == valueInt2)
                Console.WriteLine("\nNilai kedua input sama\n");
            else if (valueInt1 < valueInt2)
            {
                Console.WriteLine("\nNilai kedua input tidak sama");
                Console.WriteLine("Nilai input 1 lebih kecil dari input 2\n");
            }
            else
            {
                Console.WriteLine("\nNilai kedua input tidak sama");
                Console.WriteLine("Nilai input 1 lebih besar dari input 2\n");
            }

            Console.WriteLine($"Input user: {valueInt1} dan {valueInt2}, hasil pertambahan: {addition}, hasil pengurangan: {subtraction}, hasil perkalian: {multiply}, hasil pembagian: {division}");
            Console.WriteLine("===============================================\n");
        }

        public class SimpleCalculator()
        {
            public int AddNumbers(int a, int b)
            {
                int result = a + b;
                return result;
            }
            public int MultiplyNumbers(int a, int b)
            {
                int result = a * b;
                return result;
            }
            public int SubtractNumbers(int a, int b)
            {
                int result = a - b;
                return result;
            }
            public int DivisionNumbers(int a, int b)
            {
                int result = a / b;
                return result;
            }
        }
    }
}