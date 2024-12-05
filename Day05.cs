using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Days
{
	internal class Day05
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day05.txt");



		static public (List<(int, int)>, List<List<int>>) ParseInput(string[] input)
		{
			List<(int, int)> rules = new List<(int, int)>();
			List<List<int>> orders = new List<List<int>>();
			bool pushOrders = true;
			foreach (string line in input)
			{
				if (line.Equals(""))
				{
					pushOrders = false;
				}
				if (pushOrders)
				{
					string[] split = line.Split('|');
					int x, y;
					if (Int32.TryParse(split[0], out x) && Int32.TryParse(split[1], out y)) {
						rules.Add((x, y));
					}
 				} else
				{
					string[] split = line.Split(',');
					List<int> row = new List<int>();
					foreach (string numb in split)
					{
						int x;
						if (Int32.TryParse(numb, out x))
						{

							row.Add(x);
						}
					}

					orders.Add(row);
				}
			}
			return (rules, orders);
		}

		public object SolvePartOne(string[] input)
		{
			(List<(int, int)> rules, List<List<int>> orders) = ParseInput(input);
			int test = 0;
			for (int i = 0; i < orders.Count; i++)
			{
				
				bool order = true;
				for (int j = 0; j < orders[i].Count; j++)
				{
					for (int k = 0; k < rules.Count; k++)
					{
						if (orders[i][j] == rules[k].Item2) {
							if (orders[i].Skip(j + 1).Take(orders[i].Count - j -1).Contains(rules[k].Item1)) {
								order = false;
							}
						}
					}
				}
				if (order)
				{
					if (orders[i].Count > 0)
					{
						test += orders[i][(orders[i].Count)/2];
					}	
				}
			}
			return test;
		}

		public object SolvePartTwo(string[] input)
		{
			
			Random rng = new Random();
			(List<(int, int)> rules, List<List<int>> orders) = ParseInput(input);
			int test = 0;
			for (int i = 0; i < orders.Count; i++)
			{
				
				bool order = false;
				HashSet<string> seenShuffles = new HashSet<string>();
				KeepSwapping:
				

				for (int j = 0; j < orders[i].Count; j++)
				{
					for (int k = 0; k < rules.Count; k++)
					{
						if (orders[i][j] == rules[k].Item2) {
							if (orders[i].Skip(j + 1).Take(orders[i].Count - j -1).Contains(rules[k].Item1)) {
								int index = j;
								while (orders[i][index] != rules[k].Item1)
								{
									index++;
								}
								int temp = orders[i][j];
								orders[i][j] = orders[i][index];
								orders[i][index] = temp;
								order = true;
								goto KeepSwapping;
							}
						}
					}
				}
				if (order)
				{
					if (orders[i].Count > 0)
					{
						test += orders[i][(orders[i].Count)/2];
					}	
				}
			}
			return test;
		}
	}
}
