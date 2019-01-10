using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading;

//========================================================================================
//                              Portfolio generator
//                                    Ver 0.0
//========================================================================================
// This code is a satellite for Sampler. Been compiled it generates a portfolio for
// testing Sampler. It's less awful than Sampler, but this fact is as true as small is
// it's total length.
//========================================================================================

namespace PortfolioGen
{
    public class Generator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Today);
            
            var stringFactor1 = new List<string>(); // It represents loan type
            var stringFactor2 = new List<string>(); // It represents client type
            var intFactor1 = new List<int>(); // It represents loan amount
            var doubleFactor1 = new List<double>(); // It represents loan percent
            var dtFactor1 = new List<DateTime>(); // It represents loan creation date
            
            stringFactor1.Add("Mortgage");
            stringFactor1.Add("Auto loan");
            stringFactor1.Add("Consumer loan");
            stringFactor1.Add("Credit card");
            stringFactor1.Add("Microcredit");
            
            stringFactor2.Add("Street");
            stringFactor2.Add("Salary");
            stringFactor2.Add("VIP");
            stringFactor2.Add("Employees");
            
            dtFactor1.AddRange(Enumerable.Range(0, 12).Select(el => Convert.ToDateTime("01/06/2015").AddMonths(el)));

            /*foreach (var dt in dtFactor1)
            {
                Console.WriteLine(dt);
            } // */ // test
            
            var randGen = new Random();
            var counter = 1;
            
            using (var output = new StreamWriter(@"Generated_portfolio_with_flag.csv"))
            {
                output.WriteLine("row_key;string_factor_1;string_factor_2;int_factor_1;double_factor_1;dt_factor_1;target_flag");
                
                for (var i = 0; i < 500; i++)
                {
                    foreach (var sf1 in stringFactor1)
                    {
                        foreach (var sf2 in stringFactor2)
                        {
                            foreach (var dt in dtFactor1)
                            {
                                var if1 = 0;
                                double df1 = 0;
                                var flag = 0;

                                switch (sf1)
                                {
                                    case "Mortgage":
                                        if1 = randGen.Next(100, 1000)*10000;
                                        df1 = (double) randGen.Next(100, 150) / 10;
                                        break;
                                    case "Auto loan":
                                        if1 = randGen.Next(300, 3000)*1000;
                                        df1 = (double) randGen.Next(60, 120) / 10;
                                        break;
                                    case "Microcredit":
                                        if1 = randGen.Next(50, 500)*100;
                                        df1 = (double) randGen.Next(300, 500) / 10;
                                        break;
                                    default:
                                        if1 = randGen.Next(10, 1000)*1000;
                                        df1 = (double) randGen.Next(150, 250) / 10;
                                        break;
                                }

                                if (sf2 == "Salary") flag = randGen.NextDouble() < 0.05 ? 1 : 0;
                                else if (sf1 == "Microcredit") flag = randGen.NextDouble() < 0.75 ? 1 : 0;
                                else flag = randGen.NextDouble() < 0.1 ? 1 : 0;

                                output.WriteLine(counter + ";" +
                                                 sf1 + ";" +
                                                 sf2 + ";" +
                                                 if1 + ";" +
                                                 df1 + ";" +
                                                 dt + ";" +
                                                 flag);

                                counter += 1;
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine("Finished!");
            Console.ReadKey();
        }
    }
}