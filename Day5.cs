using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day5
    {
        //readonly string testPt1 = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 \r\n\r\nmove 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";
        readonly string puzzleInp = "[H]                 [Z]         [J]\r\n[L]     [W] [B]     [G]         [R]\r\n[R]     [G] [S]     [J] [H]     [Q]\r\n[F]     [N] [T] [J] [P] [R]     [F]\r\n[B]     [C] [M] [R] [Q] [F] [G] [P]\r\n[C] [D] [F] [D] [D] [D] [T] [M] [G]\r\n[J] [C] [J] [J] [C] [L] [Z] [V] [B]\r\n[M] [Z] [H] [P] [N] [W] [P] [L] [C]\r\n 1   2   3   4   5   6   7   8   9 \r\n\r\nmove 3 from 2 to 1\r\nmove 8 from 6 to 4\r\nmove 4 from 8 to 2\r\nmove 3 from 1 to 9\r\nmove 1 from 2 to 4\r\nmove 3 from 7 to 5\r\nmove 3 from 9 to 2\r\nmove 3 from 3 to 5\r\nmove 1 from 5 to 1\r\nmove 5 from 1 to 8\r\nmove 2 from 1 to 8\r\nmove 3 from 7 to 3\r\nmove 1 from 8 to 9\r\nmove 6 from 9 to 8\r\nmove 3 from 8 to 7\r\nmove 7 from 8 to 9\r\nmove 2 from 5 to 9\r\nmove 2 from 2 to 9\r\nmove 3 from 3 to 7\r\nmove 2 from 8 to 3\r\nmove 7 from 4 to 8\r\nmove 3 from 4 to 1\r\nmove 4 from 8 to 6\r\nmove 4 from 6 to 1\r\nmove 8 from 1 to 2\r\nmove 1 from 1 to 4\r\nmove 3 from 5 to 1\r\nmove 8 from 9 to 8\r\nmove 4 from 3 to 1\r\nmove 5 from 5 to 3\r\nmove 2 from 7 to 1\r\nmove 1 from 7 to 4\r\nmove 1 from 7 to 2\r\nmove 3 from 3 to 5\r\nmove 3 from 9 to 1\r\nmove 9 from 8 to 1\r\nmove 2 from 9 to 7\r\nmove 1 from 8 to 5\r\nmove 4 from 5 to 3\r\nmove 1 from 3 to 4\r\nmove 1 from 9 to 6\r\nmove 1 from 6 to 9\r\nmove 7 from 4 to 9\r\nmove 1 from 7 to 3\r\nmove 1 from 8 to 2\r\nmove 8 from 2 to 1\r\nmove 4 from 3 to 5\r\nmove 2 from 9 to 6\r\nmove 2 from 6 to 2\r\nmove 2 from 4 to 9\r\nmove 8 from 9 to 2\r\nmove 3 from 7 to 9\r\nmove 1 from 3 to 5\r\nmove 2 from 3 to 8\r\nmove 9 from 2 to 1\r\nmove 1 from 8 to 7\r\nmove 4 from 2 to 9\r\nmove 4 from 5 to 6\r\nmove 1 from 8 to 9\r\nmove 27 from 1 to 2\r\nmove 1 from 6 to 4\r\nmove 3 from 6 to 4\r\nmove 7 from 9 to 8\r\nmove 4 from 4 to 1\r\nmove 9 from 2 to 6\r\nmove 2 from 1 to 9\r\nmove 6 from 1 to 3\r\nmove 1 from 5 to 3\r\nmove 3 from 3 to 5\r\nmove 3 from 5 to 3\r\nmove 3 from 3 to 1\r\nmove 4 from 6 to 7\r\nmove 3 from 9 to 2\r\nmove 1 from 6 to 4\r\nmove 4 from 3 to 5\r\nmove 3 from 6 to 5\r\nmove 1 from 6 to 2\r\nmove 15 from 2 to 3\r\nmove 5 from 5 to 9\r\nmove 13 from 3 to 9\r\nmove 2 from 5 to 7\r\nmove 1 from 4 to 2\r\nmove 3 from 3 to 7\r\nmove 11 from 2 to 7\r\nmove 7 from 9 to 5\r\nmove 3 from 5 to 7\r\nmove 6 from 8 to 9\r\nmove 4 from 1 to 2\r\nmove 6 from 1 to 6\r\nmove 3 from 5 to 1\r\nmove 1 from 8 to 2\r\nmove 4 from 2 to 9\r\nmove 1 from 5 to 7\r\nmove 6 from 7 to 6\r\nmove 18 from 7 to 5\r\nmove 1 from 7 to 1\r\nmove 8 from 9 to 5\r\nmove 1 from 2 to 6\r\nmove 15 from 5 to 6\r\nmove 6 from 5 to 3\r\nmove 4 from 3 to 6\r\nmove 26 from 6 to 5\r\nmove 2 from 1 to 7\r\nmove 4 from 5 to 9\r\nmove 8 from 5 to 7\r\nmove 3 from 7 to 9\r\nmove 14 from 9 to 8\r\nmove 7 from 5 to 2\r\nmove 4 from 2 to 1\r\nmove 5 from 1 to 9\r\nmove 12 from 5 to 3\r\nmove 5 from 8 to 5\r\nmove 14 from 3 to 2\r\nmove 1 from 5 to 2\r\nmove 10 from 2 to 6\r\nmove 7 from 9 to 6\r\nmove 6 from 8 to 6\r\nmove 1 from 2 to 7\r\nmove 2 from 9 to 7\r\nmove 2 from 8 to 6\r\nmove 6 from 2 to 7\r\nmove 1 from 1 to 8\r\nmove 15 from 6 to 2\r\nmove 1 from 6 to 9\r\nmove 1 from 5 to 9\r\nmove 1 from 9 to 6\r\nmove 2 from 2 to 4\r\nmove 3 from 9 to 5\r\nmove 5 from 5 to 3\r\nmove 3 from 3 to 6\r\nmove 6 from 2 to 7\r\nmove 1 from 5 to 9\r\nmove 8 from 6 to 9\r\nmove 2 from 6 to 7\r\nmove 3 from 2 to 4\r\nmove 9 from 6 to 7\r\nmove 17 from 7 to 5\r\nmove 1 from 8 to 4\r\nmove 7 from 9 to 3\r\nmove 12 from 5 to 8\r\nmove 3 from 5 to 2\r\nmove 4 from 7 to 8\r\nmove 2 from 5 to 7\r\nmove 1 from 7 to 9\r\nmove 8 from 3 to 7\r\nmove 17 from 7 to 5\r\nmove 3 from 2 to 5\r\nmove 1 from 3 to 6\r\nmove 10 from 5 to 4\r\nmove 5 from 2 to 7\r\nmove 1 from 4 to 2\r\nmove 3 from 9 to 8\r\nmove 7 from 7 to 2\r\nmove 5 from 5 to 1\r\nmove 14 from 4 to 9\r\nmove 3 from 9 to 8\r\nmove 1 from 6 to 9\r\nmove 2 from 1 to 4\r\nmove 2 from 8 to 5\r\nmove 16 from 8 to 6\r\nmove 1 from 6 to 2\r\nmove 11 from 9 to 2\r\nmove 2 from 7 to 5\r\nmove 1 from 1 to 6\r\nmove 11 from 2 to 9\r\nmove 4 from 2 to 8\r\nmove 9 from 5 to 3\r\nmove 1 from 4 to 2\r\nmove 2 from 1 to 8\r\nmove 1 from 2 to 9\r\nmove 2 from 4 to 3\r\nmove 8 from 6 to 9\r\nmove 16 from 9 to 3\r\nmove 16 from 3 to 2\r\nmove 17 from 2 to 6\r\nmove 1 from 9 to 3\r\nmove 1 from 2 to 5\r\nmove 1 from 9 to 4\r\nmove 3 from 2 to 8\r\nmove 1 from 9 to 1\r\nmove 1 from 9 to 6\r\nmove 7 from 3 to 1\r\nmove 5 from 3 to 5\r\nmove 3 from 8 to 3\r\nmove 2 from 3 to 4\r\nmove 6 from 8 to 4\r\nmove 7 from 6 to 4\r\nmove 3 from 6 to 7\r\nmove 3 from 8 to 9\r\nmove 3 from 5 to 2\r\nmove 3 from 1 to 3\r\nmove 1 from 4 to 8\r\nmove 3 from 5 to 1\r\nmove 13 from 4 to 7\r\nmove 14 from 6 to 7\r\nmove 6 from 1 to 9\r\nmove 3 from 9 to 6\r\nmove 1 from 8 to 7\r\nmove 1 from 8 to 7\r\nmove 20 from 7 to 3\r\nmove 1 from 8 to 9\r\nmove 1 from 1 to 9\r\nmove 1 from 1 to 5\r\nmove 1 from 4 to 6\r\nmove 14 from 3 to 9\r\nmove 1 from 2 to 6\r\nmove 3 from 7 to 6\r\nmove 6 from 3 to 2\r\nmove 1 from 3 to 8\r\nmove 2 from 7 to 3\r\nmove 7 from 6 to 3\r\nmove 12 from 3 to 1\r\nmove 1 from 8 to 2\r\nmove 1 from 4 to 9\r\nmove 1 from 5 to 6\r\nmove 1 from 6 to 4\r\nmove 1 from 4 to 2\r\nmove 2 from 2 to 3\r\nmove 16 from 9 to 7\r\nmove 3 from 6 to 7\r\nmove 6 from 9 to 4\r\nmove 4 from 4 to 7\r\nmove 6 from 1 to 8\r\nmove 2 from 3 to 6\r\nmove 3 from 1 to 9\r\nmove 3 from 2 to 3\r\nmove 3 from 3 to 8\r\nmove 5 from 2 to 8\r\nmove 2 from 7 to 8\r\nmove 3 from 1 to 5\r\nmove 1 from 4 to 3\r\nmove 2 from 9 to 8\r\nmove 1 from 6 to 8\r\nmove 2 from 9 to 1\r\nmove 15 from 7 to 1\r\nmove 1 from 6 to 5\r\nmove 10 from 1 to 5\r\nmove 1 from 4 to 1\r\nmove 2 from 1 to 6\r\nmove 9 from 7 to 8\r\nmove 27 from 8 to 3\r\nmove 1 from 6 to 1\r\nmove 1 from 8 to 5\r\nmove 5 from 5 to 6\r\nmove 12 from 3 to 1\r\nmove 3 from 7 to 1\r\nmove 7 from 5 to 1\r\nmove 1 from 6 to 4\r\nmove 3 from 6 to 9\r\nmove 1 from 4 to 2\r\nmove 2 from 6 to 5\r\nmove 1 from 7 to 6\r\nmove 1 from 9 to 2\r\nmove 2 from 5 to 6\r\nmove 2 from 6 to 5\r\nmove 3 from 1 to 3\r\nmove 19 from 3 to 1\r\nmove 2 from 2 to 9\r\nmove 42 from 1 to 7\r\nmove 4 from 9 to 7\r\nmove 1 from 6 to 8\r\nmove 1 from 8 to 5\r\nmove 2 from 1 to 9\r\nmove 3 from 5 to 7\r\nmove 27 from 7 to 4\r\nmove 1 from 1 to 4\r\nmove 3 from 9 to 2\r\nmove 18 from 4 to 9\r\nmove 2 from 5 to 3\r\nmove 1 from 7 to 1\r\nmove 2 from 3 to 4\r\nmove 8 from 7 to 5\r\nmove 15 from 9 to 3\r\nmove 1 from 9 to 7\r\nmove 3 from 7 to 2\r\nmove 2 from 7 to 2\r\nmove 2 from 5 to 3\r\nmove 1 from 1 to 5\r\nmove 1 from 9 to 1\r\nmove 1 from 3 to 1\r\nmove 1 from 4 to 3\r\nmove 8 from 7 to 3\r\nmove 8 from 2 to 4\r\nmove 1 from 9 to 6\r\nmove 23 from 3 to 9\r\nmove 1 from 9 to 6\r\nmove 2 from 6 to 8\r\nmove 1 from 8 to 6\r\nmove 1 from 5 to 3\r\nmove 7 from 4 to 8\r\nmove 7 from 5 to 7\r\nmove 2 from 8 to 3\r\nmove 1 from 1 to 8\r\nmove 3 from 7 to 4\r\nmove 5 from 4 to 3\r\nmove 1 from 1 to 8\r\nmove 3 from 3 to 1\r\nmove 8 from 9 to 7\r\nmove 3 from 8 to 4\r\nmove 1 from 6 to 2\r\nmove 5 from 8 to 7\r\nmove 6 from 3 to 1\r\nmove 1 from 2 to 9\r\nmove 7 from 7 to 9\r\nmove 4 from 1 to 9\r\nmove 2 from 4 to 2\r\nmove 1 from 4 to 9\r\nmove 1 from 1 to 6\r\nmove 8 from 4 to 8\r\nmove 4 from 1 to 5\r\nmove 3 from 5 to 2\r\nmove 2 from 2 to 5\r\nmove 2 from 5 to 6\r\nmove 1 from 3 to 7\r\nmove 2 from 6 to 4\r\nmove 1 from 5 to 7\r\nmove 1 from 6 to 9\r\nmove 1 from 4 to 1\r\nmove 6 from 9 to 2\r\nmove 8 from 9 to 7\r\nmove 4 from 7 to 3\r\nmove 4 from 8 to 3\r\nmove 3 from 8 to 3\r\nmove 8 from 3 to 5\r\nmove 1 from 1 to 7\r\nmove 11 from 9 to 7\r\nmove 5 from 2 to 7\r\nmove 1 from 8 to 1\r\nmove 3 from 2 to 3\r\nmove 1 from 1 to 4\r\nmove 1 from 2 to 5\r\nmove 20 from 7 to 8\r\nmove 7 from 7 to 9\r\nmove 4 from 4 to 7\r\nmove 3 from 9 to 4\r\nmove 5 from 7 to 4\r\nmove 7 from 4 to 7\r\nmove 4 from 9 to 2\r\nmove 1 from 4 to 3\r\nmove 4 from 3 to 5\r\nmove 2 from 5 to 8\r\nmove 4 from 5 to 2\r\nmove 5 from 2 to 6\r\nmove 2 from 6 to 3\r\nmove 22 from 8 to 5\r\nmove 13 from 7 to 9\r\nmove 11 from 9 to 3\r\nmove 2 from 6 to 8\r\nmove 7 from 3 to 1\r\nmove 18 from 5 to 2\r\nmove 1 from 6 to 4\r\nmove 1 from 4 to 9\r\nmove 2 from 8 to 5\r\nmove 2 from 9 to 1\r\nmove 9 from 3 to 1\r\nmove 4 from 5 to 6\r\nmove 2 from 6 to 7\r\nmove 3 from 9 to 5\r\nmove 10 from 5 to 8\r\nmove 6 from 8 to 7\r\nmove 3 from 8 to 1\r\nmove 6 from 2 to 3\r\nmove 1 from 9 to 6\r\nmove 5 from 3 to 4\r\nmove 4 from 1 to 4\r\nmove 17 from 1 to 5\r\nmove 12 from 2 to 7\r\nmove 1 from 3 to 6\r\nmove 16 from 5 to 8\r\nmove 3 from 5 to 6\r\nmove 9 from 8 to 3\r\nmove 8 from 8 to 4\r\nmove 7 from 4 to 1\r\nmove 5 from 1 to 4\r\nmove 4 from 3 to 7\r\nmove 14 from 7 to 3\r\nmove 6 from 4 to 8\r\nmove 9 from 7 to 4\r\nmove 5 from 6 to 1\r\nmove 1 from 7 to 1\r\nmove 1 from 6 to 7\r\nmove 16 from 4 to 5\r\nmove 1 from 4 to 2\r\nmove 1 from 7 to 5\r\nmove 2 from 1 to 7\r\nmove 2 from 7 to 4\r\nmove 4 from 1 to 6\r\nmove 13 from 5 to 6\r\nmove 5 from 6 to 3\r\nmove 22 from 3 to 2\r\nmove 1 from 4 to 7\r\nmove 4 from 5 to 4\r\nmove 1 from 7 to 6\r\nmove 5 from 8 to 5\r\nmove 2 from 3 to 1\r\nmove 13 from 6 to 1\r\nmove 6 from 1 to 4\r\nmove 1 from 8 to 1\r\nmove 6 from 1 to 4\r\nmove 1 from 5 to 4\r\nmove 7 from 4 to 7\r\nmove 3 from 1 to 5\r\nmove 2 from 5 to 7\r\nmove 5 from 5 to 1\r\nmove 8 from 7 to 4\r\nmove 1 from 6 to 4\r\nmove 1 from 7 to 4\r\nmove 9 from 2 to 7\r\nmove 8 from 7 to 6\r\nmove 5 from 6 to 4\r\nmove 1 from 7 to 4\r\nmove 2 from 4 to 9\r\nmove 2 from 6 to 1\r\nmove 8 from 2 to 6\r\nmove 9 from 1 to 8\r\nmove 9 from 6 to 2\r\nmove 1 from 1 to 8\r\nmove 6 from 8 to 4\r\nmove 2 from 9 to 7\r\nmove 2 from 7 to 9\r\nmove 15 from 2 to 8\r\nmove 18 from 4 to 2\r\nmove 14 from 4 to 5\r\nmove 10 from 2 to 4\r\nmove 9 from 2 to 6\r\nmove 1 from 9 to 3\r\nmove 1 from 3 to 1\r\nmove 6 from 5 to 8\r\nmove 3 from 4 to 9\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 6\r\nmove 3 from 9 to 7\r\nmove 22 from 8 to 6\r\nmove 1 from 8 to 9\r\nmove 2 from 1 to 5\r\nmove 5 from 5 to 4\r\nmove 2 from 5 to 8\r\nmove 2 from 8 to 7\r\nmove 1 from 9 to 7\r\nmove 1 from 5 to 8\r\nmove 1 from 9 to 8\r\nmove 15 from 6 to 4\r\nmove 2 from 5 to 2\r\nmove 11 from 4 to 6\r\nmove 5 from 4 to 1\r\nmove 5 from 4 to 2\r\nmove 2 from 1 to 5\r\nmove 6 from 2 to 8\r\nmove 11 from 6 to 3\r\nmove 12 from 6 to 8\r\nmove 1 from 3 to 9\r\nmove 3 from 3 to 2\r\nmove 6 from 4 to 2\r\nmove 2 from 5 to 8\r\nmove 5 from 7 to 2\r\nmove 11 from 8 to 4\r\nmove 1 from 7 to 4\r\nmove 1 from 9 to 6\r\nmove 7 from 2 to 1\r\nmove 3 from 6 to 5\r\nmove 2 from 5 to 3\r\nmove 1 from 5 to 9\r\nmove 3 from 4 to 9\r\nmove 4 from 9 to 1\r\nmove 4 from 3 to 6\r\nmove 3 from 4 to 8\r\nmove 3 from 8 to 9\r\nmove 2 from 8 to 2\r\nmove 9 from 8 to 7\r\nmove 2 from 3 to 1\r\nmove 2 from 3 to 2\r\nmove 1 from 3 to 6\r\nmove 2 from 9 to 1\r\nmove 8 from 7 to 5\r\nmove 7 from 2 to 7\r\nmove 2 from 8 to 9\r\nmove 4 from 6 to 5\r\nmove 13 from 1 to 5\r\nmove 4 from 1 to 8\r\nmove 3 from 9 to 3\r\nmove 12 from 5 to 9\r\nmove 3 from 8 to 9\r\nmove 1 from 8 to 4\r\nmove 3 from 2 to 7\r\nmove 3 from 3 to 7\r\nmove 1 from 9 to 2\r\nmove 4 from 6 to 4\r\nmove 6 from 5 to 6\r\nmove 2 from 7 to 3\r\nmove 2 from 2 to 1\r\nmove 5 from 6 to 5\r\nmove 1 from 1 to 7\r\nmove 9 from 5 to 4\r\nmove 10 from 9 to 6\r\nmove 1 from 2 to 6\r\nmove 12 from 7 to 6\r\nmove 1 from 7 to 4\r\nmove 23 from 6 to 1\r\nmove 10 from 4 to 3\r\nmove 16 from 1 to 5\r\nmove 5 from 1 to 2\r\nmove 6 from 3 to 7\r\nmove 5 from 4 to 8";
        
        public string Part1()
        {
            Dictionary<int, List<char>> stacks = new();
            string answer = "";

            //split input into crates and moves
            string crates = puzzleInp.Split("\r\n\r\n")[0];
            string moves = puzzleInp.Split("\r\n\r\n")[1];

            //add the stackNumm and lists to the dictionary
            for (int i = 1; i < 10; i++)
                stacks.Add(i, new List<char>());

            //split the string of all crates into lines to be read in
            foreach (string line in crates.Split("\r\n")) 
            {
                //loop through each char in the line
                for (int r= 0; r < line.Length; r++) 
                {
                    //if the char is a letter record the index of the char. add 3 then divide this by 4 to calculate the stack number
                    if (Regex.IsMatch(line[r].ToString(), "[A-Z]"))
                    {
                        int stackNum = (r+3)/4;
                        stacks[stackNum].Add(line[r]);
                    }
                }
            }

            //get the moves into a list
            List<string> movesList = new();
            foreach (string moveStr in moves.Split("\r\n")) { movesList.Add(moveStr.Trim()); }

            foreach (string move in movesList)
            {
                //get info out of move line
                int cratesToMove = int.Parse(move.Split(' ')[1]);
                int origin = int.Parse(move.Split(' ')[3]);
                int destination = int.Parse(move.Split(' ')[5]);

                //do the move
                for (int m = 0; m < cratesToMove; m++) 
                {
                    stacks[destination].Insert(0, stacks[origin][0]);
                    stacks[origin].RemoveAt(0);
                }
            }

            //get the top crate at each stack
            for (int a = 1; a< 10; a++ )            
                answer += stacks[a][0].ToString();            

            return answer;
        }

        public string Part2()
        {
            Dictionary<int, List<char>> stacks = new();
            string answer = "";

            //split input into crates and moves
            string crates = puzzleInp.Split("\r\n\r\n")[0];
            string moves = puzzleInp.Split("\r\n\r\n")[1];

            //add the stackNumm and lists to the dictionary
            for (int i = 1; i < 10; i++)
                stacks.Add(i, new List<char>());

            //split the string of all crates into lines to be read in
            foreach (string line in crates.Split("\r\n"))
            {
                //loop through each char in the line
                for (int r = 0; r < line.Length; r++)
                {
                    //if the char is a letter record the index of the char. add 3 then divide this by 4 to calculate the stack number
                    if (Regex.IsMatch(line[r].ToString(), "[A-Z]"))
                    {
                        int stackNum = (r + 3) / 4;
                        stacks[stackNum].Add(line[r]);
                    }
                }
            }

            //get the moves into a list
            List<string> movesList = new();
            foreach (string moveStr in moves.Split("\r\n")) { movesList.Add(moveStr.Trim()); }

            foreach (string move in movesList)
            {
                //get info out of move line
                int cratesToMove = int.Parse(move.Split(' ')[1]);
                int origin = int.Parse(move.Split(' ')[3]);
                int destination = int.Parse(move.Split(' ')[5]);

                //do the move - part 2 meant that stacks moved in same order rather than one at a time
                if (cratesToMove == 1 )                
                    for (int m = 0; m < cratesToMove; m++)
                    {
                        stacks[destination].Insert(0, stacks[origin][0]);
                        stacks[origin].RemoveAt(0);
                    }
                
                else                
                    for (int n = cratesToMove - 1; n >= 0; n--)
                    {
                        stacks[destination].Insert(0, stacks[origin][n]);
                        stacks[origin].RemoveAt(n);
                    }              
            }

            //get the top crate at each stack
            for (int a = 1; a < 10; a++)
                answer += stacks[a][0].ToString();

            return answer;
        }
    }
}
