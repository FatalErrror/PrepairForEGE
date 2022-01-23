// From MA

// task 1

// task 2
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepairForEGE
{
    class Program
    {
        const string PATH = @"E:\0Important\Downloads\27-B.txt";



        static void Main(string[] args)
        {
            string inputString = GetInputSting();
            Dictionary<char, int> ans = new Dictionary<char, int>(26);
            for (char i = 'A'; i <= 'Z'; i++) ans.Add(i, 0);

            char r;
            for (int i = 0; i < inputString.Length; i++)
            {
                r = inputString[i];
                if (r == '.') break;
                if (IsEnglish(r))
                {
                    ans[char.ToUpper(r)]++;
                }
            }
            char a = 'A';

            for (char i = 'A'; i <= 'Z'; i++) if (ans[i] > ans[a]) a = i;

            Console.WriteLine($"{a} {ans[a]}");
            Console.ReadKey();
        }

        static bool IsEnglish(char symbol)
        {
            return ('a' <= symbol && symbol <= 'z') || ('A' <= symbol && symbol <= 'Z');
        }

        static string GetInputSting()
        {
            return "It is not a simple task.Yes!";
        }

    }
}

// task 3
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepairForEGE
{
    class Program
    {
        const string PATH = @"E:\0Important\Downloads\27-B.txt";



        static void Main(string[] args)
        {
            string inputString = GetInputSting();
            Dictionary<char, int> ans = new Dictionary<char, int>(26);
            for (char i = 'a'; i <= 'z'; i++) ans.Add(i, 0);

            char r;
            for (int i = 0; i < inputString.Length; i++)
            {
                r = inputString[i];
                if (r == '.') break;
                if (IsEnglish(r))
                {
                    ans[r]++;
                }
            }

            for (char i = 'a'; i <= 'z'; i++) if (ans[i] > 0) Console.WriteLine($"{i}{ans[i]}");

            Console.ReadKey();
        }

        static bool IsEnglish(char symbol)
        {
            return ('a' <= symbol && symbol <= 'z');// || ('A' <= symbol && symbol <= 'Z');
        }

        static string GetInputSting()
        {
            return "fhb5kbfыshfm.";
        }

    }
}

// From ReshuEGE

// Task 27

// 1
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepairForEGE
{
    class Program
    {
        const string PATH = @"E:\0Important\Downloads\27-B.txt";

        static int[] data;
        static List<Interval> intervals;

        static void Main(string[] args)
        {
            Console.WriteLine("Start reading...");

            using (StreamReader reader = new StreamReader(PATH))
            {
                intervals = new List<Interval>(int.Parse(reader.ReadLine()));
                data = new int[intervals.Capacity];
                int read;

                intervals.Add(new Interval(0, -1));

                for (int i = 0; i < intervals.Capacity; i++)
                {
                    read = int.Parse(reader.ReadLine());
                    data[i] = read;
                    if (read > 0 && read % 2 == 1)
                    {
                        intervals.Last().Right = read;
                        intervals.Last().RightIndex = i;
                        intervals.Add(new Interval(read, i));
                    }
                }


                intervals.Last().Right = 0;
                intervals.Last().RightIndex = data.Length;
            }

            Console.WriteLine("Finish reading");
            Console.WriteLine("Start calculating...");

            long tempSum = 0;

            for (int i = 0; i < intervals.Count; i++)
            {
                FillInterval(i);
            }

            Console.WriteLine("Finish calculating");
            Console.WriteLine("Start searching...");
            Console.WriteLine("");
            Console.WriteLine("0.0000000 %");

            long Max = long.MinValue;

            const int N29 = 29;
            uint countdown = 0;

            for (int i = 1; i < intervals.Count - 1; i++)
            {
                tempSum = intervals[i - 1].RightMax;

                for (int j = i; j + N29 < intervals.Count; j += N29)
                {
                    for (int k = j; k < j + N29; k++)
                    {
                        tempSum += intervals[k].Left;
                        tempSum += intervals[k].Full;
                    }


                    if (tempSum + intervals[j + N29].LeftAndLeftMax > Max) Max = tempSum + intervals[j + N29].LeftAndLeftMax;
                }

                if (countdown++ > 1000)
                {
                    Console.CursorTop = Console.CursorTop - 1;
                    Console.WriteLine(((float)(i * 100) / (intervals.Count - 2)) + " %          ");
                    countdown = 0;
                }
            }

            Console.WriteLine("Finish searching");
            Console.WriteLine("Max: " + Max);
            Console.ReadKey();
        }


        static void FillInterval(int inter)
        {
            Interval interval = intervals[inter];
            long tempSum = 0;



            //Full
            for (int i = interval.LeftIndex + 1; i < interval.RightIndex; i++)
            {
                tempSum += data[i];
            }
            interval.Full += tempSum;

            tempSum = 0;

            //Right max
            for (int i = interval.RightIndex - 1; i > interval.LeftIndex; i--)
            {
                tempSum += data[i];
                if (tempSum > interval.RightMax) interval.RightMax = tempSum;
            }

            tempSum = 0;

            //Left max
            for (int i = interval.LeftIndex + 1; i < interval.RightIndex; i++)
            {
                tempSum += data[i];
                if (tempSum > interval.LeftMax) interval.LeftMax = tempSum;
            }

            interval.LeftAndLeftMax += interval.LeftMax;
        }


        class Interval
        {
            public long Left; // |
            public long Right; // |
            public int LeftIndex;
            public int RightIndex;

            public long Full; // ==========
            public long LeftMax; // | ======---
            public long LeftAndLeftMax; // | ======---
            public long RightMax;// --======= |



            public Interval(long start, int startIndex)
            {
                Left = start;
                LeftIndex = startIndex;
                LeftAndLeftMax = start;
                Full = 0;
                LeftMax = 0;
                RightMax = 0;
            }
        }

    }
}







