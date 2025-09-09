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
            Console.WriteLine($"Hasil 5 ditambah dengan 8 adalah {addNumber}, hasil 5 dikali 8 adalah {multiplyNumber}\n");

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
        }
    }
}