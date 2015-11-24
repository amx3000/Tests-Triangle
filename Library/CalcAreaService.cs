using System;

using Library.Properties;

namespace Library
{
	public class CalcAreaService
	{
		/// <summary>
		/// Метод возвращает площадь треугольника, с заданными длинами сторон.
		/// </summary>
		/// <param name="a">длина стороны a</param>
		/// <param name="b">длина стороны b</param>
		/// <param name="c">длина стороны c</param>
		/// <returns>площадь треугольника</returns>
		/// <remarks>Для расчета площади треугольника используется формула Герона.</remarks>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Исключение выдается, если длина какой-либо стороны отрицательная, либо превышает сумму длин двух других сторон.
		/// </exception>
		public static double GetTriangleArea(double a, double b, double c)
		{
			if (a < 0)
				throw new ArgumentOutOfRangeException("a", Resources.ErrorNegativeTriangleSideLength);

			if (b < 0)
				throw new ArgumentOutOfRangeException("b", Resources.ErrorNegativeTriangleSideLength);

			if (c < 0)
				throw new ArgumentOutOfRangeException("c", Resources.ErrorNegativeTriangleSideLength);

			if (a == 0d || b == 0d || c == 0d)
				return 0d;

			// полупериметр
			var p = (a + b + c) / 2;

			if (a > p)
				throw new ArgumentOutOfRangeException("a", Resources.ErrorTriangleSideLengthTooLong);

			if (b > p)
				throw new ArgumentOutOfRangeException("b", Resources.ErrorTriangleSideLengthTooLong);

			if (c > p)
				throw new ArgumentOutOfRangeException("c", Resources.ErrorTriangleSideLengthTooLong);

			return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}

		/// <summary>
		/// Метод возвращает площадь прямоугольного треугольника, с заданными длинами катетов.
		/// </summary>
		/// <param name="cathetus1">длина первого катета</param>
		/// <param name="cathetus2">длина второго катета</param>
		/// <returns>площадь треугольника</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Исключение выдается, если длина одного из катетов отрицательная.
		/// </exception>
		public static double GetRightTriangleArea(double cathetus1, double cathetus2)
		{
			if (cathetus1 < 0)
				throw new ArgumentOutOfRangeException("cathetus1", Resources.ErrorNegativeCathetusLength);

			if (cathetus2 < 0)
				throw new ArgumentOutOfRangeException("cathetus2", Resources.ErrorNegativeCathetusLength);

			if (cathetus1 == 0d || cathetus2 == 0d)
				return 0d;

			return cathetus1 * cathetus2 / 2;
		}

		/// <summary>
		/// Метод возвращает площадь прямоугольного треугольника, с заданными длинами гипотенузы и одного катета.
		/// </summary>
		/// <param name="cathetus">длина первого катета</param>
		/// <param name="hypotenuse">длина второго катета</param>
		/// <returns>площадь треугольника</returns>
		/// <remarks>Для расчета площади треугольника используется формула Герона.</remarks>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Исключение выдается, если длина гипотенузы или катета отрицательная, либо длина катета больше или равна длине гипотенузы.
		/// </exception>
		public static double GetRightTriangleAreaWithHypotenuse(double hypotenuse, double cathetus)
		{
			if (cathetus < 0)
				throw new ArgumentOutOfRangeException("cathetus", Resources.ErrorNegativeCathetusLength);

			if (hypotenuse < 0)
				throw new ArgumentOutOfRangeException("hypotenuse", Resources.ErrorNegativeHypotenuseLength);

			if (cathetus == 0d || hypotenuse == 0d)
				return 0d;

			if (hypotenuse <= cathetus)
				throw new ArgumentOutOfRangeException("hypotenuse", Resources.ErrorHypotenuseShorterThanCathetus);

			var cathetus2 = Math.Sqrt(hypotenuse * hypotenuse - cathetus * cathetus);
			return cathetus * cathetus2 / 2;
		}
	}
}
