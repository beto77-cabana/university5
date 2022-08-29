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
            string[] cars =     //lista de cadena de texto
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
    }
}