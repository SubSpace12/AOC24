using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Days
{
	internal class Day04
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day04.txt");



		static public List<List<int>> ParseInput(string[] input)
		{
			List<List<int>> list = new List<List<int>>();
			int ver = input[0].Length + 6;
			for (int i = 0; i < 3; i++)
			{
				List<int> pads = new List<int>();
				for (int j = 0; j < ver; j++)
				{
					pads.Add('.');
				}
				list.Add(pads);
			}
			foreach(string s in input)
			{
				List<int> l = new List<int>();
				for (int i = 0; i < 3; i++)
				{
					l.Add('.');
				}
				foreach (char c in s)
				{
					l.Add(c);
				}
				for (int i = 0; i < 3; i++)
				{
					l.Add('.');
				}
				list.Add(l);
			}
			for (int i = 0; i < 3; i++)
			{
				List<int> pads = new List<int>();
				for (int j = 0; j < ver; j++)
				{
					pads.Add('.');
				}
				list.Add(pads);
			}
			
			return list;
		}

		static public int SolvePartOne(string[] input)
		{
			int xmasCount = 0;
			List<List<int>> inputParsed = ParseInput(input);
			for (int i = 0; i < inputParsed.Count; i++)
			{
				for (int j = 0; j < inputParsed[i].Count; j++)
				{
					if (inputParsed[i][j] == 'X')
					{
						
							if (inputParsed[i][j + 1] == 'M' && inputParsed[i][j + 2] == 'A' && inputParsed[i][j + 3] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i][j - 1] == 'M' && inputParsed[i][j - 2] == 'A' && inputParsed[i][j - 3] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i + 1][j] == 'M' && inputParsed[i + 2][j] == 'A' && inputParsed[i + 3][j] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i - 1][j] == 'M' && inputParsed[i - 2][j] == 'A' && inputParsed[i - 3][j] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i - 1][j - 1] == 'M' && inputParsed[i - 2][j - 2] == 'A' && inputParsed[i - 3][j - 3] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i + 1][j + 1] == 'M' && inputParsed[i + 2][j + 2] == 'A' && inputParsed[i + 3][j + 3] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i + 1][j - 1] == 'M' && inputParsed[i + 2][j - 2] == 'A' && inputParsed[i + 3][j - 3] == 'S')
							{
								xmasCount++;
							}
						
							if (inputParsed[i - 1][j + 1] == 'M' && inputParsed[i - 2][j + 2] == 'A' && inputParsed[i - 3][j + 3] == 'S')
							{
								xmasCount++;
							}
							
					}
				}
			}
			return xmasCount;
		}

		public object SolvePartTwo(string[] input)
		{
			int xmasCount = 0;
			List<List<int>> inputParsed = ParseInput(input);
			List<(int, int)> visited =	new List<(int, int)> ();
			for (int i = 0; i < inputParsed.Count; i++)
			{
				for (int j = 0; j < inputParsed[i].Count; j++)
				{
					if (inputParsed[i][j] == 'A')
					{
						try
						{
							if (inputParsed[i - 1][j - 1] == 'M' && inputParsed[i + 1][j + 1] == 'S' && inputParsed[i + 1][j - 1] == 'M' && inputParsed[i - 1][j + 1] == 'S')
							{
								
								xmasCount++;
							}
						} catch (Exception e)
						{

						}	
						try
						{
							if (inputParsed[i - 1][j - 1] == 'S' && inputParsed[i + 1][j + 1] == 'M' && inputParsed[i + 1][j - 1] == 'M' && inputParsed[i - 1][j + 1] == 'S')
							{
								
								xmasCount++;
							}
						} catch (Exception e)
						{

						}	
						try
						{
							if (inputParsed[i - 1][j - 1] == 'M' && inputParsed[i + 1][j + 1] == 'S' && inputParsed[i + 1][j - 1] == 'S' && inputParsed[i - 1][j + 1] == 'M')
							{
								
								xmasCount++;
							}
						} catch (Exception e)
						{

						}	
						try
						{
							if (inputParsed[i - 1][j - 1] == 'S' && inputParsed[i + 1][j + 1] == 'M' && inputParsed[i + 1][j - 1] == 'S' && inputParsed[i - 1][j + 1] == 'M')
							{
								
								xmasCount++;
							}
						} catch (Exception e)
						{

						}	
					} 
				}
			}
			return xmasCount;
		}
	
	}
}