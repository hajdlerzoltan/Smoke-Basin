using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoke_Basin
{
	internal class Program
	{
		public class Ascending : IComparer<int> {
			public bool Compare(int a, int b)
			{
				return a >= b;
			}

			int IComparer<int>.Compare(int x, int y)
			{
				throw new NotImplementedException();
			}
		}
		static void Main(string[] args)
		{
			List<List<int>>  matrixData = new List<List<int>>();
			List<List<int>>  matrixDataPart2 = new List<List<int>>();
			List<int> p2Largests = new List<int>();
			int result = 0;
			try
			{
				StreamReader sr = new StreamReader("data.txt");
				while (!sr.EndOfStream)
				{
					List<int> dataChars = new List<int>();
					string line = sr.ReadLine();
					foreach (var chars in line)
					{
						dataChars.Add(chars-'0');
					}
					matrixData.Add(dataChars);
				}
			}
			catch (Exception)
			{
				throw;
			}
			matrixDataPart2 = matrixData;
			int part2result = 0;
			for (int i = 0; i < matrixData.Count; i++)
			{
				for (int j = 0; j < matrixData[0].Count; j++)
				{
					if (isLowPoint(ref matrixData, i, j))
					{
						result += matrixData[i][j]+1;
					}
				}
			}
			Console.WriteLine(result);
			for (int i = 0; i < matrixData.Count; i++)
			{
				for (int j = 0; j < matrixData[0].Count; j++)
				{
					int current = 0;
					Part2(ref matrixDataPart2, i, j, ref current);
					part2result = Math.Max(part2result, current);
					p2Largests.Add(current);
				}
			}
			p2Largests.Sort((a, b) => b.CompareTo(a));
			int p2result = p2Largests[0] * p2Largests[1] * p2Largests[2];
			Console.WriteLine(p2result);
			Console.ReadKey();
			
		}
		public static bool isLowPoint(ref List<List<int>> heigthMap, int row,int col) {
			int currVal = heigthMap[row][col];
			if (row -1 >= 0 && heigthMap[row - 1][col]<= currVal)
			{
				return false;
			}
			if (row + 1 < heigthMap.Count && heigthMap[row + 1][col] <= currVal)
			{
				return false;
			}
			if (col - 1 >= 0 && heigthMap[row][col - 1] <= currVal)
			{
				return false;
			}
			if (col + 1 < heigthMap.Count && heigthMap[row][col + 1] <= currVal)
			{
				return false;
			}
			return true;
		}
		public static bool boundCheck(ref List<List<int>> heigthMap, int row, int col) {
			if (row >= 0 && row < heigthMap.Count && col >= 0 && col < heigthMap[0].Count)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static void Part2(ref List<List<int>> heigthMap,int row, int col, ref int count)
		{
			if (!boundCheck(ref heigthMap, row,col))
			{
				return;
			}
			if (heigthMap[row][col] == 9)
			{
				return;
			}
			count++;
			heigthMap[row][col] = 9;
			Part2(ref heigthMap, row - 1, col, ref count);
			Part2(ref heigthMap, row + 1, col, ref count);
			Part2(ref heigthMap, row , col - 1, ref count);
			Part2(ref heigthMap, row , col + 1, ref count);
		}
	}
}
