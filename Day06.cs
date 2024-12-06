using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using System.Collections.Specialized;

namespace AdventOfCode.Days
{
	internal class Day06
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day06.txt");
		static public List<(int, int)> coords = new List<(int, int)>();

		enum Dir
		{
			Up,
			Down,
			Left,
			Right,
		}

		static public (List<List<char>>, (int, int)) ParseInput(string[] input)
		{
			List<List<char>> output = new List<List<char>>();
			int a = 0;
			int b = 0;
			for (int i = 0; i < input.Length; i++)
			{
				List<char> row = new List<char>();
				for (int j = 0; j < input[i].Length; j++)
				{
					row.Add(input[i][j]);
					if (input[i][j] == '^')
					{
						a = i;
						b = j;
					}
				}
				output.Add(row);
			}

			return (output, (a, b));
		}

		public object SolvePartOne(string[] input)
		{
			int steps = 0;
			Dir d = Dir.Up;
			(List<List<char>> board, (int a, int b)) = ParseInput(input);
			
			while(true)
			{
					
				while (board[a][b] != '#')
				{
					if (board[a][b] != 'X')
					{
						if (board[a][b] != '^')
						{
							coords.Add((a, b));
						}
						board[a][b] = 'X';
						steps++;
					}
					switch (d)
					{
						case Dir.Up:
							a--;
							break;
						case Dir.Right:
							b++;
							break;
						case Dir.Down:
							a++;
							break;
						case Dir.Left:
							b--;
							break;
					}
					if (a < 0 || b < 0 || a >= board.Count || b >= board[0].Count)
					{
							return steps;
					}
						
				}
				switch (d)
				{
					case Dir.Up:
						a++;
						d = Dir.Right;
						b++;
						break;
					case Dir.Right:
						b--;
						d = Dir.Down;
						a++;
						break;
					case Dir.Down:
						a--;
						d = Dir.Left;
						b--;
						break;
					case Dir.Left:
						b++;
						d = Dir.Up;
						a--;
						break;
				}
			}
			return steps;
			
		}


		public bool PrintPlus(List<List<char>> l, int i, int j)
		{
			if (l[i][j] != '+')
			{
				l[i][j] = '+';
				return true;
			} else
			{
				return false;
			}
		}

		

		public object SolvePartTwo(string[] input)
		{
			int steps = 0;
			Dir d = Dir.Up;
			(List<List<char>> board, (int a, int b)) = ParseInput(input);
			foreach ((int first, int second) in coords)
			{
				
				bool noLoop = false;
				List<List<char>> copy = new List<List<char>>();
				foreach (List<char> row in board)
				{
					List<char> copyRow = new List<char>();
					foreach(char c in row)
					{
						copyRow.Add(c);
					}
					copy.Add(copyRow);
				} 
					copy[first][second] = '#';

				

				
				d = Dir.Up;
				int ac = a;
				int bc = b;
				while(!noLoop)
				{
						
					int moves = 0;
					while (copy[ac][bc] != '#')
					{
							
						moves = 0;
						switch (d)
						{
							case Dir.Up:
								ac--;
								break;
							case Dir.Right:
								bc++;
								break;
							case Dir.Down:
								ac++;
								break;
							case Dir.Left:
								bc--;
								break;
						}
						moves++;
						
						if (ac < 0 || bc < 0 || ac >= copy.Count || bc >= copy[0].Count)
						{
							noLoop = true;
							break;
						}
					}
						
					switch (d)
					{
						case Dir.Up:
							ac++;
								
							break;
						case Dir.Right:
							bc--;
								
							break;
						case Dir.Down:
							ac--;
								
							break;
						case Dir.Left:
							bc++;
								
							break;
					}
					if (!PrintPlus(copy, ac, bc) && moves != 0)
					{
							
						
						steps++;
						break;
					}
					switch (d)
					{
						case Dir.Up:
								
							d = Dir.Right;
							bc++;
							break;
						case Dir.Right:
								
							d = Dir.Down;
							ac++;
							break;
						case Dir.Down:
								
							d = Dir.Left;
							bc--;
							break;
						case Dir.Left:
								
							d = Dir.Up;
							ac--;
							break;
					}
				}
				
				
			}
			
			return steps;
		}
	}
}
