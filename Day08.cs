using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace AdventOfCode.Days
{
	internal class Day08
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day08.txt");



		static public (List<List<char>>, Dictionary<char, List<(int, int)>>) ParseInput(string[] input)
		{
			List<List<char>> list = new List<List<char>>();
			Dictionary<char, List<(int, int)>> coords = new Dictionary<char, List<(int, int)>>();

			for (int i = 0; i < input.Length; i++)
			{
				List<char> row = new List<char>();
				
				for (int j = 0; j < input[i].Length; j++)
				{
					
					row.Add(input[i][j]);
					if (input[i][j] != '.')
					{
						if (coords.ContainsKey(input[i][j])) {
							coords[input[i][j]].Add((i, j));
						} else
						{
							coords.Add(input[i][j], new List<(int, int)>() { (i, j) });
						}
					}
				}
				list.Add(row);
			}
			
			return (list, coords);
		}

		static List<((int x1, int y1), (int x2, int y2))> GetLines(List<(int x, int y)> points)
		{
			var lines = new List<((int x1, int y1), (int x2, int y2))>();
			for (int i = 0; i < points.Count; i++)
			{
				for (int j = i + 1; j < points.Count; j++)
				{
					var point1 = points[i];
					var point2 = points[j];
					lines.Add(((point1.x, point1.y), (point2.x, point2.y)));
				}
			}

			return lines;
		}

		public object SolvePartOne(string[] input)
		{
			List<(int, int)> antinodeLocations = new List<(int, int)>();
			int count = 0;
			(List<List<char>> board, Dictionary<char, List<(int, int)>> coords) = ParseInput(input);
			foreach (KeyValuePair<char, List<(int, int)>> entry in coords) {
				 List<((int x1, int y1), (int x2, int y2))> lines = GetLines(entry.Value);
				
				for (int i = 0; i < lines.Count; i++)
				{
					
					int x = lines[i].Item2.y2 - lines[i].Item1.y1;
					int y = lines[i].Item2.x2 - lines[i].Item1.x1;
					double newx1 = lines[i].Item1.y1 - x;
					double newy1 = lines[i].Item1.x1 - y;

					double newx2 = lines[i].Item2.y2 + x;
					double newy2 = lines[i].Item2.x2 + y;

					try
					{
						if (board[(int)newy1][(int)newx1] == '.')
						{
							board[(int)newy1][(int)newx1] = '#';
						}
						if (!antinodeLocations.Contains(((int)newy1, (int)newx1)))
						{
							antinodeLocations.Add(((int)newy1, (int)newx1));
							count++;
						}
						
							
					} catch { }
					try
					{
						if (board[(int)newy2][(int)newx2] == '.')
						{
							board[(int)newy2][(int)newx2] = '#';
						}
						if (!antinodeLocations.Contains(((int)newy2, (int)newx2)))
						{
							antinodeLocations.Add(((int)newy2, (int)newx2));
							count++;
						}
					} catch { }
				}
				
			}

			return count;
		}

		public object SolvePartTwo(string[] input)
		{

			List<(int, int)> antinodeLocations = new List<(int, int)>();
			int count = 0;
			(List<List<char>> board, Dictionary<char, List<(int, int)>> coords) = ParseInput(input);
			foreach (KeyValuePair<char, List<(int, int)>> entry in coords) {
				 List<((int x1, int y1), (int x2, int y2))> lines = GetLines(entry.Value);

				for (int i = 0; i < lines.Count; i++)
				{
					
					int x = lines[i].Item2.y2 - lines[i].Item1.y1;
					int y = lines[i].Item2.x2 - lines[i].Item1.x1;
					try
					{
						double newx1 = lines[i].Item1.y1;
						double newy1 = lines[i].Item1.x1;

						
						while(true)
						{
							newx1 -= x;
							newy1 -= y;
							
							if (board[(int)newy1][(int)newx1] == '.')
							{
								board[(int)newy1][(int)newx1] = '#';
							}
							if (!antinodeLocations.Contains(((int)newy1, (int)newx1)))
							{
								antinodeLocations.Add(((int)newy1, (int)newx1));
								count++;
							}

							
						}
					} catch { }
					try
					{
						double newx2 = lines[i].Item2.y2;
						double newy2 = lines[i].Item2.x2;
						while(true)
						{
							newx2 += x;
							newy2 += y;
							if (board[(int)newy2][(int)newx2] == '.')
							{
								board[(int)newy2][(int)newx2] = '#';
							}
							if (!antinodeLocations.Contains(((int)newy2, (int)newx2)))
							{
								antinodeLocations.Add(((int)newy2, (int)newx2));
								count++;
							}
						}
					} catch { }
					if (!antinodeLocations.Contains((lines[i].Item1.y1, lines[i].Item1.x1)))
					{
						antinodeLocations.Add((lines[i].Item1.y1, lines[i].Item1.x1));
						count++;
					}
					if (!antinodeLocations.Contains((lines[i].Item2.y2, lines[i].Item2.x2)))
					{
						antinodeLocations.Add((lines[i].Item2.y2, lines[i].Item2.x2));
						count++;
					}
				}
				
			}
			
			return count;
		}
	}
}
