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
		//this class will help to order the data to ascending
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
			List<List<int>>  matrixData = new List<List<int>>(); //part1 fully processed file list
			List<List<int>>  matrixDataPart2 = new List<List<int>>(); // copy of the main input for part2
			List<int> p2Largests = new List<int>(); //Part2 3 largest int's list
			int result = 0;
			//reading from a file from project folder/bin/debug
			try
			{
				StreamReader sr = new StreamReader("data.txt");
				//while stream has lines do the array filling
				while (!sr.EndOfStream)
				{
					List<int> dataChars = new List<int>(); //helper list whitc is contains the line chars
					string line = sr.ReadLine();
					//iterating throw the line char by char and adding it to the dataChars list
					foreach (var chars in line)
					{
						dataChars.Add(chars-'0');
					}
					//adding  data to the matrixData
					matrixData.Add(dataChars);
				}
			}
			//if something went wrong in the try {} part this will throw you an error
			catch (Exception)
			{
				throw;
			}
			//copying the processed data for part 2
			matrixDataPart2 = matrixData;
			//declaring an int for part 2 whitch will be the result for part 2
			int part2result = 0;
			//checking the low points for part 1 by iterating throw the matrix 
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
			//writing out the part 1 result
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
		//low point checker method for part 1, this methode cheking the corrent position for neighbour positions value(up,down,left,rigth)
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
		//checking the borders of the matrix
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
		//calculating the basin's extent for part 2, this is recoursive method call himself as much as it can move between 9 heigh's
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
