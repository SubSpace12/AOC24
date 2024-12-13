using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
	internal class Day13
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day13.txt");



		static public List<(int[,], (int, int))> ParseInput(string[] input)
		{
			List<(int[,], (int, int))> result = new List<(int[,], (int, int))>();
			
			string inputs = String.Join("\n", input);
			string[] split = inputs.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach(string s in split)
			{
				int[,] numbers = { {0, 0 }, { 0, 0} };
				string[] lines = s.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
				var w1 = Regex.Matches(lines[0].ToString(), @"\d+");
				numbers[0, 0] = Int32.Parse(w1[0].ToString());
				numbers[0, 1] = Int32.Parse(w1[1].ToString());
				var w2 = Regex.Matches(lines[1].ToString(), @"\d+");
				numbers[1, 0] = Int32.Parse(w2[0].ToString());
				numbers[1, 1] = Int32.Parse(w2[1].ToString());
				var r = Regex.Matches(lines[2].ToString(), @"\d+");
				int x = Int32.Parse(r[0].ToString());
				int y = Int32.Parse(r[1].ToString());
				result.Add((numbers, (x, y)));
			}
			
			return result;
		}

		public long SolvePartOne(string[] input)
		{
			long result = 0;
			List<(int[,], (int, int))> inputParsed = ParseInput(input);
			foreach ((int[,] matrix, (int x, int y)) in inputParsed)
			{
				int determinant = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
				
				double a11 = (double)matrix[1, 1]/determinant;
				double a12 = -((double)matrix[1, 0]/determinant);
				double a21 = -((double)matrix[0, 1]/(double)determinant);
				double a22 = (double)matrix[0, 0]/determinant;
				
				
				double resultX = (a11*x + a12*y);
				double resultY = (a21*x + a22*y);
				


				double sum = 3 * resultX + resultY;
				if (sum > 0 && resultX <= 100 && resultY <= 100)
				{
					
					if (Math.Round(sum, 10).ToString("R").Equals(Math.Round(sum).ToString()))
					{
						
				
						result += (long)Math.Round(sum, 10);
					}
				}
				
				
			}
			return result;
		}

		public object SolvePartTwo(string[] input)
		{

			long result = 0;
			List<(int[,], (int, int))> inputParsed = ParseInput(input);
			foreach ((int[,] matrix, (int x, int y)) in inputParsed)
			{
				int determinant = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
				
				double a11 = (double)matrix[1, 1]/determinant;
				double a12 = -((double)matrix[1, 0]/determinant);
				double a21 = -((double)matrix[0, 1]/(double)determinant);
				double a22 = (double)matrix[0, 0]/determinant;
				long xp = 10000000000000 + x;
				long yp = 10000000000000 + y;
				
				double resultX = (a11 * xp + a12 * yp);
				double resultY = (a21 * xp + a22 * yp);
				
				
				


				double sum = 3 * resultX + resultY;
				
				
				Console.WriteLine(sum.ToString("R"));
				
				
				if (sum > 0)
				{
					if (Math.Abs(Math.Round(sum) - sum) <= 0.0003)
					{
						sum = Math.Round(sum);
						Console.WriteLine(sum.ToString("R"));
						result += (long)Math.Round(sum, 4);
					}
				}
				Console.WriteLine();
				
				
			}
			return result;
		}
	}
}
