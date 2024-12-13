using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Days
{
	internal class Day07
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day07.txt");


		static public List<(long, List<int>)> ParseInput(string[] input)
		{
			List<(long, List<int>)> list = new List<(long, List<int>)>();
			foreach(string line in input)
			{
				List<int> ints = new List<int>();
				string[] split = line.Split(':');

				long result = Int64.Parse(split[0]);
				string[] numbers = split[1].Split(' ');
				foreach (string number in numbers)
				{
					if (number.Length > 0)
					{
						int n = Int32.Parse(number.Trim());
						ints.Add(n);
					}
				}
				list.Add((result, ints));
			}

			return list;
		}

		

		static List<string> GenerateCombinations(char[] options, int n)
		{
			List<string> results = new List<string>();
			GenerateCombination(options, "", n, results);
			return results;
		}

		static void GenerateCombination(char[] options, string current, int n, List<string> output)
		{
			if (current.Length == n)
			{
				output.Add(current);
				return;
			}
			foreach(char c in options)
			{
				GenerateCombination(options, current + c, n, output);
			}
		}

		public long SolvePartOne(string[] input)
		{
			long output = 0;
			List<(long, List<int>)> inputParsed = ParseInput(input);
			foreach((long result, List<int> numbers) in inputParsed)
			{
				
				char[] operations = {'+', '*'};
				List<string> test = GenerateCombinations(operations, numbers.Count - 1);
				foreach (string combination in test)
				{
					long check = numbers[0];

					for (int i = 1; i < numbers.Count; i++)
					{
						if (combination[i - 1] == '+')
						{
							check += numbers[i];
							
						} else if (combination[i - 1] == '*')
						{
							
							check *= numbers[i];
						}
					}
					if (check == result)
					{
						
						output += result;
						break;
					}
				}
			}
			return output;
		}

		public object SolvePartTwo(string[] input)
		{

			long output = 0;
			List<(long, List<int>)> inputParsed = ParseInput(input);
			foreach((long result, List<int> numbers) in inputParsed)
			{
				
				char[] operations = {'+', '*', '|'};
				List<string> test = GenerateCombinations(operations, numbers.Count - 1);
				foreach (string combination in test)
				{
					long check = numbers[0];

					for (int i = 1; i < numbers.Count; i++)
					{
						if (combination[i - 1] == '+')
						{
							check += numbers[i];
							
						} else if (combination[i - 1] == '*')
						{
							
							check *= numbers[i];
						} else if (combination[i - 1] == '|')
						{
							int size = (int)Math.Pow(10, numbers[i].ToString().Length);
							check *= size;
							check += numbers[i];
						}
					}
					if (check == result)
					{
						
						output += result;
						break;
					}
				}
			}
			return output;
		}
	}
}
