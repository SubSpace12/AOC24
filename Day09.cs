using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AdventOfCode.Days
{
	internal class Day09
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day09.txt");



		static public List<int> ParseInput(string[] input)
		{
			List<int> disk = new List<int>();
			foreach (char c in input[0])
			{
				disk.Add(c - '0');
			}

			return disk;
		}

		public object SolvePartOne(string[] input)
		{
			long result = 0;
			List<int> disk = ParseInput(input);
			List<int> diskVis = new List<int>();
			
			int number = 0;
			for (int i = 0; i < disk.Count; i++)
			{
				
				if (i % 2 == 0)
				{
					for (int j = 0; j < disk[i]; j++)
					{
						diskVis.Add(number);
					}
					number++;
				} else
				{
					for (int j = 0; j < disk[i]; j++)
					{
						diskVis.Add(-1);
					}
				}
			}
			int block = 0;
			int check = diskVis.Count;
			
			for (int i = 0; i < check; i++)
			{
				if (diskVis[i] == -2)
				{
					break;
				}
				if (diskVis[i] == -1)
				{
					if (diskVis.GetRange(i, diskVis.Count - i).All(a=> a < 0))
					{
						break;
					} 
					int find = 1;
					int pop;
					while (true)
					{
						pop = diskVis[diskVis.Count - find];
						if (pop != -1 && pop != -2)
						{
							break;
						}
						find++;
					}
					for (int j = 1; j <= find; j++)
					{
						diskVis[diskVis.Count - j] = -2;
					}
					
						diskVis[i] = pop;
				}
				result += i * diskVis[i];
				
			}	
			return result;
		}

		public object SolvePartTwo(string[] input)
		{
			return "TODO";
		}
	}
}
