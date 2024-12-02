using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Days
{
	internal class Day02
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day02.txt");



		static public List<List<int>> ParseInput(string[] input)
		{
			List<List<int>> list = new List<List<int>>();
			for (int i = 0; i < input.Length; i++)
			{
				list.Add(new List<int>());
				var split = input[i].Split(' ');
				for (int j = 0; j < split.Length; j++)
				{
					int x = 0;
					if (Int32.TryParse(split[j], out x))
					{
						list[i].Add(x);
					}
				}
			}

			return list;
		}

		public bool IsSafe(List<int> row)
		{
				for (int i = 0; i < row.Count - 1; i++)
				{
				
					if (Math.Abs(row[i] - row[i + 1]) < 1 || Math.Abs(row[i] - row[i + 1]) > 3)
					{
						return false;
					}
						
						if (row[i] < row[i + 1] && row[0] > row[1])
						{
							
							return false;
						} else if (row[i] > row[i + 1] && row[0] < row[1])
						{
							
							return false;
						}
				}

				return true;
		}

		public int SolvePartOne(string[] input)
		{
			int result = 0;
			List<List<int>> inputParsed = ParseInput(input);
			foreach (List<int> row in inputParsed)
			{
				if (IsSafe(row))
				{	
					result++;
				}
			}
			return result;
		}


		public int SolvePartTwo(string[] input)
		{
			int result = 0;
			List<List<int>> inputParsed = ParseInput(input);
			foreach (List<int> row in inputParsed)
			{
				
				if (IsSafe(row))
				{	
					result++;
				} else
				{
					for (int i = 0; i < row.Count; i++)
					{
						List<int> removed = new List<int>(row);
						removed.RemoveAt(i);
						if (IsSafe(removed))
						{
							result++;
							break;
						}
					}
				}

			} 	
			return result;
		}
	}
}
