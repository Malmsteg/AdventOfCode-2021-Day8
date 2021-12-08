using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AdventOfCode_2021_Day8
{
    public static class Program
    {
        public static void Main()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"..\..\..\input.txt");
            string path = Path.GetFullPath(file);
            string[] text = File.ReadAllText(path).Replace("\r", "").Split("\n");
            string[] splitted = new string[text.Length*2];
            int result = 0;
            for(int i = 0; i < text.Length; i++){
                string[] temp = text[i].Split(" | ");
                splitted[i*2] = temp[0];
                splitted[(i*2)+1] = temp[1];
            }

            string[] rightSide = new string[splitted.Length*2];
            for(int i = 1; i < splitted.Length; i+=2)
            {
                int k = (i-1) * 2;
                string[] temp = splitted[i].Split(" "); // i = 1 -> 0,1,2,3; i = 3 -> 4,5,6,7; i = 5 -> 8,9,10,11 
                rightSide[k] = temp[0];
                rightSide[k + 1] = temp[1];
                rightSide[k + 2] = temp[2];
                rightSide[k + 3] = temp[3];
            }

            for(int i = 0; i < rightSide.Length; i++){
                if(rightSide[i].Length == 2 || rightSide[i].Length == 3 ||
                rightSide[i].Length == 4 || rightSide[i].Length == 7)
                {
                    result++;
                }
            }
            Console.WriteLine("Part 1: " + result);
          }
    }
}
