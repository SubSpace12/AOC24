using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AdventOfCode.Days
{
	internal class Day01
	{
		//for commit purposes
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day01.txt");

		static (int[] LeftList, int[] RightList) ParseInput(string[] input)
		{
			int[] tab1 = new int[input.Length];
			int[] tab2 = new int[input.Length];
			int i = 0;
			foreach (string line in input)
			{
				string[] twoNumbers = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
				int first = 0;
				int second = 0;
				if (Int32.TryParse(twoNumbers[0], out first) && Int32.TryParse(twoNumbers[1], out second)) {
					tab1[i] = first;
					tab2[i] = second;
				}
				i++;
			}
			
			return (tab1, tab2);
		}

		public object SolvePartOne(string[] input)
		{
			int result = 0;
			var lists = ParseInput(input);
			Array.Sort(lists.LeftList);
			Array.Sort(lists.RightList);
			for (int i = 0; i < input.Length; i++)
			{
				result += Math.Abs(lists.LeftList[i] - lists.RightList[i]);
			}
			return result;
		}

		public int SolvePartTwo(string[] input)
		{
			var lists = ParseInput(input);
			int result = 0;
			foreach (int n in lists.LeftList)
			{
				int similarityScore = 0;
				foreach (int m in lists.RightList)
				{
					if (n == m)
					{
						similarityScore += m;
					}
				}
				result += similarityScore;
			}
			return result;
		}

	}
}
