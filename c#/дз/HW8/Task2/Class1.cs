using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	public class Square
	{
		private int[][] _square;

		/// <summary>
		/// Создаёт новый квадрат указанного размера
		/// </summary>
		/// <param name="size">Размер квадрата</param>
		public Square(int size)
		{
			_square = new int[size][];
			for (int i = 0; i < size; i++)
			{
				_square[i] = new int[size];
			}
		}

		/// <summary>
		/// Возвращает сумму элементов указанной строки
		/// </summary>
		/// <param name="row">Номер строки</param>
		public int SumRow(int row)
		{
			int sumRow = 0;


			foreach (int item in _square[row])
			{
				sumRow += item;
			}

			return sumRow;
		}

		/// <summary>
		/// Возвращает сумму элементов указанного столбца
		/// </summary>
		/// <param name="col">Номер столбца</param>
		public int SumCol(int col) {

			int sumCol = 0;

			for (int i = 0; i < _square.Length; i++)
			{
				sumCol += _square[i][col];
			}

			return sumCol;
		}

		/// <summary>
		/// Возвращает сумму элементов главной диагонали
		public int SumMainDiag()
		{
			int sumMainDiag = 0;

			for (int i = 0; i < _square.Length; i++)
			{
				sumMainDiag += _square[i][i];
			}

			return sumMainDiag;
		}
		/// Возвращает сумму элементов побочной диагонали
		public int SumOtherDiag() {

			int sumOtherDiag = 0;

			for (int i = 0; i < _square.Length; i++)
			{
				sumOtherDiag += _square[i][_square.Length -1 - i];
			}

			return sumOtherDiag;
		}
		/// <summary>
		/// Возвращает, является ли текущий квадрат магическим
		/// </summary>
		public bool Magic() {
			bool sumAllCols = true;
			bool sumAllRows = true;

			for (int i = 0; i < _square.Length-1; i++)
			{
				if (SumRow(i)!=SumRow(i+1))
				{
					sumAllRows = false;
				}

				if (SumCol(i)!=SumCol(i+1))
				{
					sumAllCols = false;
				}
			}

			if (sumAllCols && sumAllRows && (SumMainDiag()==SumOtherDiag()) && (SumOtherDiag()== SumRow(0)))
			{
				return true;
			}

			return false;
		}
		/// <summary>
		/// Считывает значения элементов квадрата из консоли
		/// </summary>
		public void ReadSquare(string[] lines, int lineIndex)
		{
			for (int row = 0; row < _square.Length; row++)
			{
				string[] line = lines[lineIndex + row]
					.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (line.Length != _square.Length)
					Console.WriteLine($"Ошибка при чтении квадрата: строка должна содержать {_square.Length} значений, а содержит {line.Length}");
				for (int i = 0; i < _square.Length; i++)
					int.TryParse(line[i], out _square[row][i]);
			}
		}
		/// <summary>
		/// Выводит аккуратно отформатированное содержимое квадрата
		/// </summary>
		public void PrintSquare()
		{
			foreach (int[] row in _square)
			{
				foreach (int item in row)
				{
					Console.Write("{0,5}", item);
				}
				Console.WriteLine();
			}
		}
	}
}
