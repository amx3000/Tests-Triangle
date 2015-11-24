using System;

using Library;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
	/// <summary>
	/// Модульные тесты для проверки метода <see cref="CalcAreaService.GetTriangleArea"/>
	/// </summary>
	[TestClass]
	public class GetTriangleArea
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
			s = CalcAreaService.GetTriangleArea(3, 4, 5);
			Assert.AreEqual(s, 6, _delta);
			s = CalcAreaService.GetTriangleArea(4, 5, 3);
			Assert.AreEqual(s, 6, _delta);
			s = CalcAreaService.GetTriangleArea(4, 3, 5);
			Assert.AreEqual(s, 6, _delta);
		}

		[TestMethod]
		[TestCategory("Normal")]
		public void EquilateralTriangle()
		{
			var s = CalcAreaService.GetTriangleArea(7, 7, 7);
			Assert.AreEqual(s, 7 * 7 * Math.Sqrt(3) / 4, _delta);

			s = CalcAreaService.GetTriangleArea(3E20, 4E20, 5E20);
			Assert.AreEqual(s, 6E40, _delta);
		}

		[TestMethod]
		[TestCategory("Normal")]
		public void BigTriangle()
		{
			var s = CalcAreaService.GetTriangleArea(3E20, 4E20, 5E20);
			Assert.AreEqual(s, 6E40, _delta);
		}

		#endregion

		#region Проверки вырожденных треугольников

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroSideA()
		{
			var s = CalcAreaService.GetTriangleArea(0, 4, 5);
			Assert.AreEqual(s, 0, _delta);
		}

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroSideB()
		{
			var s = CalcAreaService.GetTriangleArea(4, 0, 5);
			Assert.AreEqual(s, 0, _delta);
		}

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroSideC()
		{
			var s = CalcAreaService.GetTriangleArea(4, 5, 0);
			Assert.AreEqual(s, 0, _delta);
		}

		#endregion

		#region Проверки работы с отрицательными значениями длин сторон

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeSideA()
		{
			CalcAreaService.GetTriangleArea(-3, 4, 5);
		}

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeSideB()
		{
			CalcAreaService.GetTriangleArea(3, -4, 5);
		}

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeSideC()
		{
			CalcAreaService.GetTriangleArea(3, 4, -5);
		}

		#endregion

		#region Проверки со слишком длинными сторонами

		[TestMethod]
		[TestCategory("Exceptions.ExtraLength")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ExtraSideA()
		{
			CalcAreaService.GetTriangleArea(10, 4, 5);
		}

		[TestMethod]
		[TestCategory("Exceptions.ExtraLength")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ExtraSideB()
		{
			CalcAreaService.GetTriangleArea(3, 10, 5);
		}

		[TestMethod]
		[TestCategory("Exceptions.ExtraLength")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ExtraSideC()
		{
			CalcAreaService.GetTriangleArea(3, 4, 10);
		}

		#endregion
	}
}
