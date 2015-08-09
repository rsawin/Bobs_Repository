using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpClient.SchoolServiceRef;
using HttpClient.MathServiceRef;

namespace HttpClient
{
    /// <summary>
    /// HttpClient has two Service References: "SchoolServiceRef" and "MathServiceRef", which are colocated in the Lab2Service project
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press <Enter> to start...");
            Console.ReadLine();

            SchoolServiceClient proxy = new SchoolServiceClient(); 

            var newStudent = proxy.AddStudent("A123456", "Smith", "Bill", DateTime.Parse("2/3/1977"), 
                GenderEnum.Male, "Communication", 33f, 3.5f);
            newStudent = proxy.AddStudent("B435345", "Williams", "Bill", DateTime.Parse("1/3/1988"), 
                GenderEnum.Male, "Computer Science", 31f, 2.5f);
            newStudent = proxy.AddStudent("D777666", "Francis", "Jill", DateTime.Parse("8/8/1982"), 
                GenderEnum.Female, "Math", 22f, 3.9f);

            var students = proxy.GetStudents();

            //Write all student record information to the console
            foreach (Student s in students)
            {
                Console.WriteLine(s);
            }

            
            //Math Client Service
            MathSeviceClient mathproxy = new MathSeviceClient();
            double result = mathproxy.Add(12.5, 2.3);
            Console.WriteLine(result);
            Console.WriteLine();

            result = mathproxy.Subtract(9, 3);
            Console.WriteLine(result);
            Console.WriteLine();

            result = mathproxy.Multiply(9, 3);
            Console.WriteLine(result);
            Console.WriteLine();

            result = mathproxy.Divide(9, 3);
            Console.WriteLine(result);
            Console.WriteLine();

            Console.Write("Press <Enter> to quit...");
            Console.ReadLine();
        }
    }
}
