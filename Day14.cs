using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode.Days
{
	internal class Day14
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day14.txt");



		static public List<((int, int), (int, int))> ParseInput(string[] input)
		{
			List<((int, int), (int, int))> list = new List<((int, int), (int, int))>();
			foreach (string row in input)
			{
				var w = Regex.Matches(row, @"-?\d+");
				//Console.WriteLine(w[3].ToString());
				int x = Int32.Parse(w[0].ToString());
				int y = Int32.Parse(w[1].ToString());
				int vx = Int32.Parse(w[2].ToString());
				int vy = Int32.Parse(w[3].ToString());

				list.Add(((x, y), (vx, vy)));
			}

			return list;
		}

		public int SolvePartOne(string[] input)
		{
			int tl = 0;
			int tr = 0;
			int bl = 0;
			int br = 0;
			List<((int, int), (int, int))> inputParsed = ParseInput(input);
			Console.WriteLine();
			for (int i = 0; i < inputParsed.Count; i++)
			{
				
				int x = inputParsed[i].Item1.Item1;
				int y = inputParsed[i].Item1.Item2;
				int vx = inputParsed[i].Item2.Item1;
				int vy = inputParsed[i].Item2.Item2;
				x = ((x + (vx * 100)) % 101 + 101) % 101;
				y = ((y + (vy * 100)) % 103 + 103) % 103;
				int halfx = 101 / 2;
				int halfy = 103 / 2;
				if (x < halfx && y < halfy)
				{

					tl++;
				}
				if (x > halfx && y < halfy)
				{
	
					tr++;
				}
				if (x < halfx && y > halfy)
				{

					bl++;
				}
				if (x > halfx && y > halfy)
				{

					br++;
				}
				
			}
			return tl*tr*bl*br;
		}

		public object SolvePartTwo(string[] input)
		{
			int tl = 0;
			int tr = 0;
			int bl = 0;
			int br = 0;
			List<((int, int), (int, int))> inputParsed = ParseInput(input);
			int movements = 224; //first step where the robots start forming shape
			while (true)
			{
				List<(int, int)> coords = new List<(int, int)>();
				
				int sizex = 101;
				int sizey = 103;
				for (int i = 0; i < inputParsed.Count; i++)
				{

					int x = inputParsed[i].Item1.Item1;
					int y = inputParsed[i].Item1.Item2;
					int vx = inputParsed[i].Item2.Item1;
					int vy = inputParsed[i].Item2.Item2;
					x = ((x + (vx * movements)) % sizex + sizex) % sizex;
					y = ((y + (vy * movements)) % sizey + sizey) % sizey;
					coords.Add((x, y));

				}

				for (int i = 0; i < sizey; i++)
				{
					int hashesInARow = 0;
					for (int j = 0; j < sizex; j++)
					{
						
						if (coords.Contains((j, i)))
						{
							hashesInARow++;
							if (hashesInARow > 20)
							{
								return movements;
							}
							
						}
					}
				}
				movements+=101;
			}


			return movements;
		}
	}
}
