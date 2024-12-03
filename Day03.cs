using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
	internal class Day03
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day03.txt");



		static public List<string> ParseInput(string[] input)
		{
			List<string> output = new List<string> ();
			var pattern = @"mul\(\d+,\d+\)|do\(\)|don't\(\)";
			foreach (string line in input)
			{
				
				var matches = Regex.Matches(line, pattern);
				
				foreach (var match in matches)
				{
					output.Add(match.ToString());
				}
			}
			

			return output;
		}

		public int SolvePartOne(string[] input)
		{
			int result = 0;
			List<string> list = ParseInput(input);
			foreach (string match in list)
			{
				var numbers = Regex.Matches(match.ToString(), @"\d+");
				int left = 0;
				int right = 0;
				
				if (numbers.Count != 0)
				{
					if (Int32.TryParse(numbers[0].ToString(), out left) && Int32.TryParse(numbers[1].ToString(), out right)) {
					result += left * right;
					} 
				}
			}
			return result;
		}

		public object SolvePartTwo(string[] input)
		{
			List<string> list = ParseInput(input);
			int result = 0;
			bool mulSwitch = true;
			foreach (string match in list)
			{
				if (match.Equals("do()"))
				{
					mulSwitch = true;
				} 
				else if (match.Equals("don't()"))
				{
					mulSwitch = false;
				} 
				else
				{
					var numbers = Regex.Matches(match.ToString(), @"\d+");
					int left = 0;
					int right = 0;
					if (numbers != null && Int32.TryParse(numbers[0].ToString(), out left) && Int32.TryParse(numbers[1].ToString(), out right) && mulSwitch) {
						
						result += left * right;
					} 
				}			
			}
			return result;
		}
	}
}
