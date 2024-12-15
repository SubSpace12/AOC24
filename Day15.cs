using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace AdventOfCode.Days
{
	internal class Day15
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day15.txt");



		static public (List<List<char>>, List<char>, (int, int)) ParseInput(string[] input)
		{

			List<List<char>> board = new List<List<char>>();
			List<char> move= new List<char>();
			int x = 0;
			int y = 0;

			string inputs = String.Join("\n", input);
			string[] split = inputs.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

			string[] boardString = split[0].Split('\n');
			for (int i = 0; i < boardString.Length; i++)
			{	
				List<char> row = new List<char>();
				for (int j = 0; j < boardString[i].Length; j++)
				{
					row.Add(boardString[i][j]);
					if (boardString[i][j] == '@')
					{
						x = j;
						y = i;
					}
				}
				board.Add(row);
			}
			string[] moveString = split[1].Split('\n');
			foreach (string line in moveString) 
			{
				foreach(char order in line)
				{
					move.Add(order);
				}
			}
			return (board, move, (x, y));
		}

		public object SolvePartOne(string[] input)
		{
			long result = 0;
			(List<List<char>> board, List<char> moves, (int x, int y)) = ParseInput(input);
			foreach (char move in moves) {
				if (move == '^') {
					for (int i = y-1; i >= 0; i--)
					{
						if (board[i][x] == '#')
						{
							break;
						}
						if (board[i][x] == '.')
						{
							while (i != y)
							{
								board[i][x] = board[i + 1][x];
								i++;
							}
							board[y][x] = '.';
							y--;
							break;
						}
					}
				} else if (move == '>')
				{
					for (int i = x + 1; i < board[0].Count; i++)
					{
						if (board[y][i] == '#')
						{
							break;
						}
						if (board[y][i] == '.')
						{
							while (i != x)
							{
								board[y][i] = board[y][i-1];
								i--;
							}
							board[y][x] = '.';
							x++;
							break;
						}
					}
					
				}
				else if (move == '<')
				{
					for (int i = x - 1; i >= 0; i--)
					{
						if (board[y][i] == '#')
						{
							break;
						}
						if (board[y][i] == '.')
						{
							while (i != x)
							{
								board[y][i] = board[y][i+1];
								i++;
							}
							board[y][x] = '.';
							x--;
							break;
						}
					}
				} else if (move == 'v')
				{
					for (int i = y + 1; i < board.Count; i++)
					{
						if (board[i][x] == '#')
						{
							break;
						}
						if (board[i][x] == '.')
						{
							while (i != y)
							{
								board[i][x] = board[i - 1][x];
								i--;
							}
							board[y][x] = '.';
							y++;
							break;
						}
					}
				}
				
			}
			for (int i = 0; i < board.Count; i++)
			{
				for (int j = 0; j < board[i].Count; j++)
				{
					if (board[i][j] == 'O')
					{
						result += (100 * i) + j;
					}
				}
			}

			return result;
		}
			
		

		public object SolvePartTwo(string[] input)
		{

			return "part 2 answer";
		}
	}
}
