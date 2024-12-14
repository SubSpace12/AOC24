using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AdventOfCode.Days
{
	internal class Day09
	{
		static public string[] input = File.ReadAllLines(@"..\..\Inputs\Day09.txt");



		static public List<int> ParseInput(string[] input)
		{
			List<int> disk = new List<int>();
			foreach (char c in input[0])
			{
				disk.Add(c - '0');
			}
			return disk;
		}

		public long SolvePartOne(string[] input)
		{
			long result = 0;
			List<int> disk = ParseInput(input);
			List<int> diskVis = new List<int>();
			
			int number = 0;
			for (int i = 0; i < disk.Count; i++)
			{
				
				if (i % 2 == 0)
				{
					for (int j = 0; j < disk[i]; j++)
					{
						diskVis.Add(number);
					}
					number++;
				} else
				{
					for (int j = 0; j < disk[i]; j++)
					{
						diskVis.Add(-1);
					}
				}
			}
			int block = 0;
			int check = diskVis.Count;
			
			for (int i = 0; i < check; i++)
			{
				if (diskVis[i] == -2)
				{
					break;
				}
				if (diskVis[i] == -1)
				{
					if (diskVis.GetRange(i, diskVis.Count - i).All(a=> a < 0))
					{
						break;
					} 
					int find = 1;
					int pop;
					while (true)
					{
						pop = diskVis[diskVis.Count - find];
						if (pop != -1 && pop != -2)
						{
							break;
						}
						find++;
					}
					for (int j = 1; j <= find; j++)
					{
						diskVis[diskVis.Count - j] = -2;
					}
					
						diskVis[i] = pop;
				}
				result += i * diskVis[i];
				
			}	
			return result;
		}

		public long SolvePartTwo(string[] input)
		{
			long result = 0;
			List<int> disk = ParseInput(input);
			List<long> diskVis = new List<long>();

			long number = 0;
			for (long i = 0; i < disk.Count; i++)
			{

				if (i % 2 == 0)
				{
					for (long j = 0; j < disk[(int)i]; j++)
					{
						diskVis.Add(number);
					}
					number++;
				}
				else
				{
					for (long j = 0; j < disk[(int)i]; j++)
					{
						diskVis.Add(-1);
					}
				}
			}
			
			long check = diskVis.Count;

			List<(long, long, long)> blocks = new List<(long, long, long)>();
			List<(long, long)> emptyBlocks = new List<(long, long)>();
			long count = 0;
			long current_num = 0;
			long start_index = 0;
			for (long i = 0; i < check; i++)
			{
				if (diskVis[(int)i] != current_num)
				{
					if (current_num == -1)
					{

						emptyBlocks.Add((count, start_index));
					} else
					{
						blocks.Add((current_num, count, start_index));
					}
					start_index = i;
					current_num = diskVis[(int)i];
					count = 0;
				}
				count++;
			}
			if (diskVis[diskVis.Count - 1] == -1)
			{
				emptyBlocks.Add((disk[disk.Count - 1], diskVis.Count - disk[disk.Count - 1]));
			} else
			{
				blocks.Add((diskVis[diskVis.Count - 1], disk[disk.Count - 1], diskVis.Count - disk[disk.Count - 1]));
			}
			blocks.Reverse();
			foreach ((long id, long size, long index) in blocks)
			{
				for (long k = 0; k < emptyBlocks.Count; k++) { 
					if (index > emptyBlocks[(int)k].Item2)
					{
						if (size <= emptyBlocks[(int)k].Item1)
						{

							for (long i = emptyBlocks[(int)k].Item2; i < emptyBlocks[(int)k].Item2 + size; i++)
							{
								diskVis[(int)i] = id;
							}
							for (long i = index; i < index + size; i++)
							{
								diskVis[(int)i] = -1;
							}
							long newIndex = emptyBlocks[(int)k].Item2 + size;
							long newSize = emptyBlocks[(int)k].Item1 - size;
							if (newSize == 0)
							{
								emptyBlocks.RemoveAt((int)k);
							}
							else
							{
								emptyBlocks[(int)k] = (newSize, newIndex);
							}
							

							break;
						}
					}
				}
			}
			for (long i = 0; i < diskVis.Count; i++)
			{
				if (diskVis[(int)i] == -2)
				{
					break;
				}
				if (diskVis[(int)i] != -1)
				{
					result += diskVis[(int)i] * i;
				}
			}

			return result;
		}
	}
}
