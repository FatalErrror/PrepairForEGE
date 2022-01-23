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


        static Month[] months = new Month[12];

        static void Main(string[] args)
        {
            string[] inputString = GetInputSting().Split('\n');

            for (int i = 0; i < months.Length; i++)
            {

            }





            Console.ReadKey();
        }

        class Month
        {
            public int Count = 0;
            public float SrTemp = 0;

            public void AddDay(float temp)
            {
                Count++;
                SrTemp += temp;
            }

            public float GetSr() => SrTemp/Count;

        }

        static void()

        static string GetInputSting()
        {
            return "01.01 -10\n02.01 -9\n01.02 -8";
        }

    }
}
