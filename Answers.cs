using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Days;
using System.Diagnostics;
using System.Reflection;

class Program
{
	static void Main(string[] args)
	{
		Assembly assembly = Assembly.GetExecutingAssembly();
		var types = assembly.GetTypes()
			.Where(t => t.Namespace == "AdventOfCode.Days" && t.Name.StartsWith("Day")).OrderBy(t => t.Name);
		int i = 1;
		foreach (var type in types)
		{

			Console.WriteLine($"DAY {i}");
			var instance = Activator.CreateInstance(type);

			var part1 = type.GetMethod("SolvePartOne");
			var part2 = type.GetMethod("SolvePartTwo");

			var field = type.GetField("input");
			if (part1 != null && part2 != null && field != null)
			{
				object fieldValue = field.GetValue(instance);
				Stopwatch s1 = Stopwatch.StartNew();
				var value1 = part1.Invoke(instance, new object[] {fieldValue});
				s1.Stop();
				Stopwatch s2 = Stopwatch.StartNew();
				var value2 = part2.Invoke(instance, new object[] {fieldValue});
				s2.Stop();
				if (value1 != null && value2 != null)
				{
					Console.WriteLine($"Part 1 - {value1}");
					Console.WriteLine($"Part 1 runtime - {s1.ElapsedMilliseconds}ms");
					Console.WriteLine($"Part 2 - {value2}");
					Console.WriteLine($"Part 2 runtime - {s2.ElapsedMilliseconds}ms");
					Console.WriteLine();
				}
			}
			i++;
		}
		Console.ReadLine();
	}
	
}