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
                string[] temp = splitted[i].Split(" ");
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

            // Part 2
            int part2Res = 0;
            for(int i = 0; i < splitted.Length; i+=2)
            {
                List<string> leftSide = splitted[i].Split(" ").ToList();
                List<string> rightList = splitted[i+1].Split(" ").ToList();
                for(int j = 0; j < rightList.Count; j++)
                {
                    char[] c = rightList[j].ToArray();
                    Array.Sort(c);
                    rightList[j] = new string(c);
                }
                Dictionary<int,string> solver = new();
                for( int j = 0; j < leftSide.Count; j++)
                {
                    if(leftSide[j].Length == 2){
                        solver[1] = leftSide[j];
                    }
                    if(leftSide[j].Length == 3){
                        solver[7] = leftSide[j];
                    }
                    if(leftSide[j].Length == 4){
                        solver[4] = leftSide[j];
                    }
                    if(leftSide[j].Length == 7){
                        solver[8] = leftSide[j];
                    }
                }

                for(int j = 0; j < leftSide.Count; j++)
                {
                    if(leftSide[j].Length==5)
                    {
                        //3
                        if(leftSide[j].Contains(solver[1][0])
                        && leftSide[j].Contains(solver[1][1]))
                        {
                            solver[3] = leftSide[j];
                            break;
                        }
                    }
                }
                //2 & 5
                for(int j = 0; j < leftSide.Count; j++)
                {
                    if(leftSide[j].Length == 5)
                    {
                        int count = 0;
                        for(int k = 0; k < 4; k++){
                            if(leftSide[j].Contains(solver[4][k]))
                            {
                                count++;
                            }
                        }
                        //2
                        if(count == 2)
                        {
                            solver[2] = leftSide[j];
                        }
                        //5
                        else if(count == 3 && !leftSide[j].Equals(solver[3]))
                        {
                            solver[5] = leftSide[j];
                        }
                    }
                }
                // 0, 6 && 9
                for(int p = 0; p < leftSide.Count; p++)
                {
                    if(leftSide[p].Length == 6)
                    {
                        //6
                        if
                        (
                            !leftSide[p].Contains(solver[1][0])
                            || !leftSide[p].Contains(solver[1][1])
                        )
                        {
                            solver[6] = leftSide[p];
                        }
                        //0
                        else if
                        (
                            !leftSide[p].Contains(solver[4][0])
                            || !leftSide[p].Contains(solver[4][1])
                            || !leftSide[p].Contains(solver[4][2])
                            || !leftSide[p].Contains(solver[4][3])
                        )
                        {
                            solver[0] = leftSide[p];
                        }
                        //9
                        else
                        {
                            solver[9] = leftSide[p];
                        }
                    }
                }
                for(int j = 0; j < solver.Count; j++)
                {
                    char[] c = solver[j].ToArray();
                    Array.Sort(c);
                    solver[j] = new string(c);
                }
                string res = "";
                foreach(string item in rightList)
                {
                    for(int j = 0; j < solver.Count; j++)
                    {
                        if(item.Equals(solver[j]))
                        {
                            res+=j.ToString();
                            break;
                        }
                    }
                }
                if(!string.IsNullOrEmpty(res))
                {
                    part2Res+= Convert.ToInt32(res);
                }
            }
            Console.WriteLine(part2Res);
        }
    }
}
