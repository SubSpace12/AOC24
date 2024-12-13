using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Net.Http.Headers;

namespace AdventOfCode.Days
{
	internal class Day11
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day11.txt");



		static List<long> ParseInput(string[] input)
		{
			List<long> result = new List<long>();
			string line = input[0];

			var split = line.Split(' ');
			foreach (string s in split)
			{
				long x;
				if (Int64.TryParse(s, out x))
				{
					result.Add(x);
				}
			}
			return result;
		}

		public object SolvePartOne(string[] input)
		{
			List<long> inputParsed = ParseInput(input);
			for (int i = 0; i < 25; i++)
			{
				bool split = false;
				for (int j = 0; j < inputParsed.Count; j++)
				{
					
					int digitCount = inputParsed[j].ToString().Length;
					if (split) {
						split = false;
						continue;
					}
					
					if (inputParsed[j] == 0)
					{
						inputParsed[j]++;
					}
					else if (digitCount % 2 == 0)
					{
						long left = inputParsed[j] % (long)Math.Pow(10, digitCount / 2);
						long right = inputParsed[j] / (long)Math.Pow(10, digitCount / 2);
						inputParsed[j] = left;
						inputParsed.Insert(j, right);
						split = true;
					} else
					{
						inputParsed[j]*=2024;
					}
					
				}
				
			}
			
			return inputParsed.Count;
		}

		public object SolvePartTwo(string[] input)
		{
			List<long> inputParsed = ParseInput(input);
			Dictionary<long, long> stones = new Dictionary<long, long>();
			foreach (long s in inputParsed)
			{
				stones[s] = 1;
			}
			for (int i = 0; i < 75; i++)
			{
				List<KeyValuePair<long, long>> list = new List<KeyValuePair<long, long>>();
				foreach (KeyValuePair<long, long> unique in stones)
				{
					int digitCount = unique.Key.ToString().Length;
					if (unique.Key == 0)
					{
						
						list.Add(new KeyValuePair<long, long>(1, unique.Value));
						list.Add(new KeyValuePair<long, long>(0, 0));
						
					} else if (digitCount % 2 == 0)
					{
						long left = unique.Key % (long)Math.Pow(10, digitCount / 2);
						long right = unique.Key / (long)Math.Pow(10, digitCount / 2);
						list.Add(new KeyValuePair<long, long>(left, unique.Value)); 
						
							list.Add(new KeyValuePair<long, long>(right, unique.Value));
						
						list.Add(new KeyValuePair<long, long>(unique.Key, 0));
					} else
					{
						long newkey = unique.Key * 2024;
						
							list.Add(new KeyValuePair<long, long>(newkey, unique.Value));
						
						list.Add(new KeyValuePair<long, long>(unique.Key, 0));
					}

					
				}
				
				list = list.GroupBy(kvp => kvp.Key).Select(group => new KeyValuePair<long, long>(group.Key, group.Sum(kvp => kvp.Value))).ToList();

				foreach (KeyValuePair<long, long> print in list)
				{
					stones[print.Key] = print.Value;
					
				}
				List<long> keysToRemove = new List<long>();
				foreach (var kvp in stones)
				{
					
					if (kvp.Value == 0)
					{
						keysToRemove.Add(kvp.Key);
					}
				}	
				foreach (var key in keysToRemove)
				{
					stones.Remove(key);
				}
				
			}

			return stones.Sum(x => x.Value);
		}
	}
}
