using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        public static void BasicLinQ()
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
        public static void LinqNumbers()
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
            var firstOrDefault =
                textList.FirstOrDefault(text =>
                    text.Contains("z")); // "" or first element that contains "z"

            // 5. Last element that contains "z" or default
            var lastOrDefault =
                textList.LastOrDefault(text =>
                    text.Contains("z")); // "" or last element that contains "z"

            // 6. Single Values  (evitar q haya elem repetidos)
            var uniqueText = textList.Single();
            var uniqueorDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4,8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }

        public static void MultipleSelect()
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
            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises at least employees with at least 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => employee.Salary >= 1000));
        }

        //Multiple Colecciones

        public static void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                join secondElement in secondList
                    on element equals secondElement
                select new { element, secondElement };

            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
            );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                join secondElement in secondList
                    on element equals secondElement
                    into temporalList
                from temporalElement in temporalList.DefaultIfEmpty()
                where element != temporalElement
                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                join element in firstList
                    on secondElement equals element
                    into temporalList
                from temporalElement in temporalList.DefaultIfEmpty()
                where secondElement != temporalElement
                select new { Element = secondElement };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        //Saltar elementos a la hora de la busqueda para hacer una busqueda mas avanzada o paginado
        public static void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            };
            // SKIP
            var skipTwoFirstValues = myList.Skip(2); //{3,4,5,6,7,8,9,10}
            var skipLastTwoValues = myList.SkipLast(2); // {1,2,3,4,5,6,7,8}
            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); //{4,5,6,7,8}

            // TAKE
            var takeFirstTwoValues = myList.Take(2); //{1,2}
            var takeLastTwoValues = myList.TakeLast(2); //{9,10}
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); //{1,2,3}
        }

        //Paging with Skip and Take
        public static IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber,
            int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables (declarar variables dentro de las consultas)
        public static void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var aboveAverage = from number in numbers
                let average = numbers.Average()
                let nSquared = Math.Pow(number, 2)
                where nSquared > average
                select number;
            Console.WriteLine("Average:{0}", numbers.Average());
            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Number:{0} Square:{1}", number, Math.Pow(number, 2));
            }
        }

        // ZIP
        public static void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };
            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number
                + "=" + word);
            //{"1=one", "2=two", "3=three",...}
        }

        // Repeat & Range
        public static void repeatRangeLinq()
        {
            // Generate Collection from 1 -1000 --> RANGE
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}
        }

        public static void studentLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                },
            };

            var certifiedStudents = from student in classRoom
                where student.Certified
                select student;
            var notCertifiedStudents = from student in classRoom
                where student.Certified == false
                select student;
            var approvedStudentsNames = from student in classRoom
                where student.Grade >= 50 && student.Certified == true
                select student.Name;
        }

        // ALL
        public static void AllLinq()
        {
            var numbers = new List<int>() { 1,2,3,4,5};
            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true
            bool allAreBigerOrEqual = numbers.All(x => x >= 2); //false

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); //true
        }
        //agregate
        public static void AgregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);
            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 4 => 7
            // etc

            string[] words = { "hello", "my", "name", "is", "Martin" };
            string greeting = words.Aggregate((prevSum, current) => prevSum + current);

            //"", "hello," =>hello,
            //"hello,", "my" => hello,my
            //"hello, my", "name" =>hello, my name
        }

        //Distinct
        public static void distinctValues()
        {
            int[] numbers = { 1,2,3,4,5,6,4,3,2,1};
            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        //GroupBy
        public static void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 ,6, 7, 8,9};

            //Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);
            //We will have two groups:
            //1. The group that doesnt fit the condition (add numbers)
            //2. The group that fits the condition (even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value);//1,3,5,7,9 ...2,4,6,8 (first the odds and then the even)
                }
            }
            //other example
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                },
            };
            //agrupacion por los que estan certificados y los que no

            var certifiedQuery = classRoom.GroupBy(student => student.Certified);

            //We obtain two groups
            //1. Not certified Students
            //2. Certified Students

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("---------------{0}------------------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);//1,3,5,7,9 ...2,4,6,8 (first the odds and then the even)
                }
            }

        }

        public static void relationLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first Post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first comment ",
                            Content = "My Content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment ",
                            Content = "My other contet"
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second Post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other comment ",
                            Content = "My New Content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other new comment ",
                            Content = "My new contet"
                        }
                    }
                }
            };
            // sacar los comentarios de un post
            var commentsContent = posts.SelectMany(post => post.Comments,
                (post, comment) => new { PostId = post, CommentContent = comment.Content });
        }
    }
}