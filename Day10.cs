using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Days
{
	internal class Day10
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day10.txt");



		static public List<List<int>> ParseInput(string[] input)
		{
			List<List<int>> list = new List<List<int>>();
			foreach(string line in input)
			{
				List<int> row = new List<int>();
				foreach(char c in line)
				{
					int x;
					if (Int32.TryParse(c.ToString(), out x))
					{
						row.Add(x);
					}
				}
				list.Add(row);
			}

			return list;
		}

		public void TrailheadCount(List<List<int>> list, int x, int y, List<(int, int)> result, List<(int, int)> visited, bool part1)
		{
			if (part1)
			{
				visited.Add((x, y));
			}
			if (x < 0 || x >= list.Count || y < 0 || y >= list[0].Count)
			{
				return;
			}
			if (list[x][y] == 9)
			{

				result.Add((x, y));
			}
			if ((x - 1) >= 0 && !visited.Contains((x - 1, y)) && list[x][y] - list[x - 1][y] == -1)
			{
				
				TrailheadCount(list, x - 1, y, result, visited, part1);
			}
			if ((x + 1) < list.Count && !visited.Contains((x + 1, y)) && list[x][y] - list[x + 1][y] == -1)
			{
				
				TrailheadCount(list, x + 1, y, result, visited, part1);
			}
			if ((y - 1) >= 0 && !visited.Contains((x, y - 1)) && list[x][y] - list[x][y - 1] == -1)
			{
				TrailheadCount(list, x, y - 1, result, visited, part1);
			}
			if ((y + 1) < list[0].Count && !visited.Contains((x, y + 1)) && list[x][y] - list[x][y + 1] == -1)
			{
				
				TrailheadCount(list, x, y + 1, result, visited, part1);
			}
		}
		
		public object SolvePartOne(string[] input)
		{
			List<(int, int)> coords = new List<(int, int)> ();
			List<List<int>> inputParsed = ParseInput(input);
			for (int i = 0; i < inputParsed.Count; i++)
			{
				for (int j = 0; j < inputParsed[i].Count; j++)
				{
					List<(int, int)> visited = new List<(int, int)>();
					if (inputParsed[i][j] == 0)
					{
						TrailheadCount(inputParsed, i, j, coords, visited, true);
						
					}
				}
			}


			return coords.Count;
		}

		public object SolvePartTwo(string[] input)
		{

			List<(int, int)> coords = new List<(int, int)> ();
			List<List<int>> inputParsed = ParseInput(input);
			for (int i = 0; i < inputParsed.Count; i++)
			{
				for (int j = 0; j < inputParsed[i].Count; j++)
				{
					List<(int, int)> visited = new List<(int, int)>();
					if (inputParsed[i][j] == 0)
					{
						TrailheadCount(inputParsed, i, j, coords, visited, false);
						
					}
				}
			}


			return coords.Count;
		}
	}
}
