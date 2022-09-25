using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoke_Basin
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				StreamReader sr = new StreamReader("data.txt");
				string line = sr.ReadLine();
				Int64.Parse(line);
				sr.re
			}
			catch (Exception)
			{
				throw;
			}
			
			int input = int.Parse(Console.ReadLine());
			int[,] matrixData = new int[input,0];
			for (int i = 0; i < matrixData.GetLength(0); i++) {
				for (int j = 0; j < matrixData.GetLength(1); j++)
				{
					Console.Write(matrixData[i, j]);
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}
	}
}
