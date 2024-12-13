using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Days
{
	internal class Day12
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day12.txt");



		static public List<List<char>> ParseInput(string[] input)
		{
			List<List<char>> list = new List<List<char>>();
			foreach (string line in input)
			{
				List<char> row = new List<char>();
				foreach (char c in line)
				{
					row.Add(c);
				}
				list.Add(row);
			}

			return list;
		}


		public void DFS(List<List<char>> list, int x, int y, List<(int, int)> result, List<(int, int)> visited)
		{
			visited.Add((x, y));
			result.Add((x, y));
			if (x < 0 || x >= list.Count || y < 0 || y >= list[0].Count)
			{
				return;
			}
			if ((x - 1) >= 0 && !visited.Contains((x - 1, y)) && list[x][y] == list[x - 1][y])
			{
				
				DFS(list, x - 1, y, result, visited);
			}
			if ((x + 1) < list.Count && !visited.Contains((x + 1, y)) && list[x][y] == list[x + 1][y])
			{
				
				DFS(list, x + 1, y, result, visited);
			}
			if ((y - 1) >= 0 && !visited.Contains((x, y - 1)) && list[x][y] == list[x][y - 1])
			{
				DFS(list, x, y - 1, result, visited);
			}
			if ((y + 1) < list[0].Count && !visited.Contains((x, y + 1)) && list[x][y] == list[x][y + 1])
			{
				DFS(list, x, y + 1, result, visited);
			}
		}


		public object SolvePartOne(string[] input)
		{
			int result = 0;
			List<(int, int)> visited = new List<(int, int)> ();
			List<List<char>> inputParsed = ParseInput(input);
			for (int i = 0; i < inputParsed.Count; i++)
			{
				for (int j = 0; j < inputParsed[i].Count; j++)
				{
					int perimeter = 0;
					List<(int, int)> plotCoords = new List<(int, int)>();
					if (!visited.Contains((i, j)))
					{
						DFS(inputParsed, i, j, plotCoords, visited);
						foreach ((int a, int b) in plotCoords)
						{
							if (a - 1 < 0)
							{
								perimeter++;
							} else
							{
								if (inputParsed[a][b] != inputParsed[a - 1][b])
								{
									perimeter++;
								}
							}
							if (a + 1 >= inputParsed.Count)
							{
								perimeter++;
							} else
							{
								if (inputParsed[a][b] != inputParsed[a + 1][b])
								{
									perimeter++;
								}
							}
							if (b - 1 < 0)
							{
								perimeter++;
							} else
							{
								if (inputParsed[a][b] != inputParsed[a][b - 1])
								{
									perimeter++;
								}
							}
							if (b + 1 >= inputParsed[0].Count)
							{
								perimeter++;
							} else
							{
								if (inputParsed[a][b] != inputParsed[a][b + 1])
								{
									perimeter++;
								}
							}
							
						}
						result += plotCoords.Count * perimeter;
					}
				}
			}
			return result;
		}

		public object SolvePartTwo(string[] input)
		{

			int result = 0;
			List<(int, int)> visited = new List<(int, int)> ();
			List<List<char>> inputParsed = ParseInput(input);
			for (int i = 0; i < inputParsed.Count; i++)
			{
				for (int j = 0; j < inputParsed[i].Count; j++)
				{
					int perimeter = 0;
					double sidesTotal = 0;
					List<(int, int)> plotCoords = new List<(int, int)>();
					if (!visited.Contains((i, j)))
					{
						DFS(inputParsed, i, j, plotCoords, visited);
						HashSet<(int, int)> topBorder = new HashSet<(int, int)>();
						HashSet<(int, int)> leftBorder = new HashSet<(int, int)>();
						HashSet<(int, int)> bottomBorder = new HashSet<(int, int)>();
						HashSet<(int, int)> rightBorder = new HashSet<(int, int)>();
 						
						foreach ((int x, int y) in plotCoords) { 
 							foreach ((int a, int b) in plotCoords)
							{
								if (a - 1 < 0)
								{
									topBorder.Add((a, b));
								} else
								{
									if (inputParsed[a][b] != inputParsed[a - 1][b])
									{
										topBorder.Add((a, b));
									}
								}
								if (a + 1 >= inputParsed.Count)
								{
									bottomBorder.Add((a, b));
								} else
								{
									if (inputParsed[a][b] != inputParsed[a + 1][b])
									{
										bottomBorder.Add((a, b));
									}
								}
								if (b - 1 < 0)
								{
									leftBorder.Add((a, b));
								} else
								{
									if (inputParsed[a][b] != inputParsed[a][b - 1])
									{
										leftBorder.Add((a, b));
									}
								}
								if (b + 1 >= inputParsed[0].Count)
								{
									rightBorder.Add((a, b));
								} else
								{
									if (inputParsed[a][b] != inputParsed[a][b + 1])
									{
										rightBorder.Add((a, b));
									}
								}
							}
						}
						foreach ((int x, int y) in topBorder)
						{
							 double topsides = 1;
							 var neighbors = new List<(int x, int y)>
							 {   
								(x, y - 1),     
								(x, y + 1),   
							 };

							foreach (var neighbor in neighbors)
							{
								if (topBorder.Contains(neighbor))
								{
									topsides -= 0.5;
								}
								
							}
							sidesTotal += topsides;
						}

						foreach ((int x, int y) in leftBorder)
						{
							 double topsides = 1;
							 var neighbors = new List<(int x, int y)>
							 {
								(x - 1, y),     
								(x + 1, y),     
								
							 };

							foreach (var neighbor in neighbors)
							{
								if (leftBorder.Contains(neighbor))
								{
									topsides -= 0.5;
								}
								
							}

							sidesTotal += topsides;
						}

						foreach ((int x, int y) in bottomBorder)
						{
							 double topsides = 1;
							 var neighbors = new List<(int x, int y)>
							 {
								
								(x, y - 1),     
								(x, y + 1),   
							 };

							foreach (var neighbor in neighbors)
							{
								if (bottomBorder.Contains(neighbor))
								{
									topsides -= 0.5;
								}
								
							}

							sidesTotal += topsides;
						}

						foreach ((int x, int y) in rightBorder)
						{
							 double topsides = 1;
							 var neighbors = new List<(int x, int y)>
							 {
								(x - 1, y),     
								(x + 1, y),     
								  
							 };

							foreach (var neighbor in neighbors)
							{
								if (rightBorder.Contains(neighbor))
								{
									topsides -= 0.5;
								}
								
							}

							sidesTotal += topsides;
						}
						result += plotCoords.Count * (int)sidesTotal;
					}
				}
			}
			return result;
		}
	}
}
