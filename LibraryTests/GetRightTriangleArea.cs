using System;

using Library;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
	/// <summary>
	/// Модульные тесты для проверки метода <see cref="CalcAreaService.GetRightTriangleArea"/>
	/// </summary>
	[TestClass]
	public class GetRightTriangleArea
	{
		/// <summary>
		/// Дельта, используемая для сравнения чисел с плавающей запятой.
		/// </summary>
		private const double _delta = 1E-12;

		#region Normal method execution

		[TestMethod]
		[TestCategory("Normal")]
		public void NormalExecution()
		{
			double s;
			s = CalcAreaService.GetRightTriangleArea(3, 4);
			Assert.AreEqual(s, 6, _delta);
			s = CalcAreaService.GetRightTriangleArea(4, 3);
			Assert.AreEqual(s, 6, _delta);
		}

		[TestMethod]
		[TestCategory("Normal")]
		public void BigTriangle()
		{
			var s = CalcAreaService.GetRightTriangleArea(3E20, 4E20);
			Assert.AreEqual(s, 6E40, _delta);
		}

		[TestMethod]
		[TestCategory("Normal")]
		public void BigButNarrowTriangle()
		{
			var s = CalcAreaService.GetRightTriangleArea(3E-250, 4E250);
			Assert.AreEqual(s, 6, _delta);
		}

		#endregion

		#region Проверки потери вырожденных треугольников

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroCathetus1()
		{
			var s = CalcAreaService.GetRightTriangleArea(0, 4);
			Assert.AreEqual(s, 0, _delta);
		}

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroCathetus2()
		{
			var s = CalcAreaService.GetRightTriangleArea(4, 0);
			Assert.AreEqual(s, 0, _delta);
		}

		#endregion

		#region Проверки работы с отрицательными значениями длин сторон

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeCathetus1()
		{
			CalcAreaService.GetRightTriangleArea(-3, 4);
		}

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeCathetus2()
		{
			CalcAreaService.GetRightTriangleArea(3, -4);
		}

		#endregion
	}
}
