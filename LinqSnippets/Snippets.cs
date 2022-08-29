using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars = //lista de cadena de texto
            {
                "Audi A5",
                "VW Golf",
                "VW California",
                "Audi A3",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };
            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is audi (SELECT AUDIs)
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        //Numbers Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Each Number multiplied by 3
            //take all numbers, but 9
            //Order numbers by ascending value
            var processedNumberList =
                numbers
                    .Select(num => num * 3) //{3,6,9, etc}
                    .Where(num => num != 9) //all but the 9
                    .OrderBy(num => num); //at the end, we order ascending
        }

        public static void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //1. First of all elements
            var first = textList.First();

            //2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or default
            var firstOrDefault = textList.FirstOrDefault(text => text.Contains("z")); // "" or first element that contains "z"

            // 5. Last element that contains "z" or default
            var lastOrDefault = textList.LastOrDefault(text => text.Contains("z")); // "" or last element that contains "z"

            // 6. Single Values
            var uniqueText = textList.Single();
            var uniqueorDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4,8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }

        static public void MultipleSelect()
        {
            string[] myOpinions =
            {
                "Opinion 1, text1",
                "Opinion 2, text2",
                "Opinion 3, text3"
            };
            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martín",
                            Email = "martin@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "Pepe@gmail.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "Juanjo@gmail.com",
                            Salary = 2000
                        }
                    }
                },

                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "martin@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "María",
                            Email = "María@gmail.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "Marta@gmail.com",
                            Salary = 4000
                        }
                    }
                }
            };
            //Obtain all employees of all Enterprises
            var EmployeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any list is empty
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprises=>enterprises.Employees.Any());

            // All enterprises at least employees with at least 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000=
                enterprises.Any(enterprises =>
                    enterprises.Employees.Any(employee => employee.Salary >= 1000));
        }


    }
}