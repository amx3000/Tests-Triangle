using System;

using Library;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
	/// <summary>
	/// Модульные тесты для проверки метода <see cref="CalcAreaService.GetRightTriangleAreaWithHypotenuseWithHypotenuse"/>
	/// </summary>
	[TestClass]
	public class GetRightTriangleAreaWithHypotenuseWithHypotenuses
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
			s = CalcAreaService.GetRightTriangleAreaWithHypotenuse(5, 3);
			Assert.AreEqual(s, 6, _delta);
			s = CalcAreaService.GetRightTriangleAreaWithHypotenuse(5, 4);
			Assert.AreEqual(s, 6, _delta);
		}

		[TestMethod]
		[TestCategory("Normal")]
		public void BigTriangle()
		{
			double s;
			s = CalcAreaService.GetRightTriangleAreaWithHypotenuse(5E20, 3E20);
			Assert.AreEqual(s, 6E40, _delta);
			s = CalcAreaService.GetRightTriangleAreaWithHypotenuse(5E20, 4E20);
			Assert.AreEqual(s, 6E40, _delta);
		}

		#endregion

		#region Проверки вырожденных треугольников

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroHypotenuse()
		{
			var s = CalcAreaService.GetRightTriangleAreaWithHypotenuse(0, 4);
			Assert.AreEqual(s, 0, _delta);
		}

		[TestMethod]
		[TestCategory("Zero")]
		public void ZeroCathetus()
		{
			var s = CalcAreaService.GetRightTriangleAreaWithHypotenuse(5, 0);
			Assert.AreEqual(s, 0, _delta);
		}

		#endregion

		#region Проверки работы с отрицательными значениями длин сторон

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeHypotenuse()
		{
			CalcAreaService.GetRightTriangleAreaWithHypotenuse(-5, 3);
		}

		[TestMethod]
		[TestCategory("Exceptions.Negative")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NegativeCathetus()
		{
			CalcAreaService.GetRightTriangleAreaWithHypotenuse(5, -3);
		}

		#endregion

		#region Проверки со слишком длинными сторонами

		[TestMethod]
		[TestCategory("Exceptions.ExtraLength")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ExtraCathetus()
		{
			CalcAreaService.GetRightTriangleAreaWithHypotenuse(5, 10);
		}

		#endregion
	}
}
