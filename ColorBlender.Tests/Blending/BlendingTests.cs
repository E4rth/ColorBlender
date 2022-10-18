using System.Drawing;
using ColorBlender.Converters.Services;
using ColorBlender.Models.ColorModels.RGB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorBlender.Tests.Blending
{
    [TestClass]
    public class BlendingTests
    {
        private readonly IColorBlenderService _colorBlenderService = new ColorBlenderService();

        #region Separable Blend Modes
        [TestMethod]
        public void Should_Blend_ColorBurn()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.ColorBurn(backdrop, source).ToRgb();
            
            // Arrange
            var expectedResult = new RGB(57, 24, 13, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_ColorDodge()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.ColorDodge(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(117, 44, 24, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Darken()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Darken(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(67, 34, 23, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Difference()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Difference(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(102, 68, 13, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Exclusion()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Exclusion(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(112, 79, 31, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_HardLight()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.HardLight(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(67, 34, 15, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Lighten()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Lighten(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(112, 79, 23, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Multiply()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Multiply(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(62, 29, 14, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Normal()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Normal(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(67, 79, 23, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

       [TestMethod]
        public void Should_Blend_Overlay()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Overlay(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(67, 34, 15, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Screen()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Screen(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(117, 84, 32, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_SoftLight()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.SoftLight(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(89, 34, 15, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Color()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Color(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(55, 60, 10, 0.9);
            Assert.AreEqual(result, expectedResult);
        }
        #endregion

        #region Non-Separeble Blend Modes
        [TestMethod]
        public void Should_Blend_Hue()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Hue(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(57, 64, 13, 0.9);
            Assert.AreEqual(result, expectedResult);
        }

        // Note: Since Hue, Saturation, Color and Luminosity are non-separable blend modes, they will ignore opacity and will provide the resulting color as if it were solid without any alpha transparency.
        [TestMethod]
        public void Should_Blend_Luminosity()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 1);
            var source = new RGB(23, 123, 23, 1);

            // Act
            var result = _colorBlenderService.Luminosity(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(152, 52, 52, 1);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Should_Blend_Saturation()
        {
            // Assert
            var backdrop = new RGB(123, 23, 23, 0.8);
            var source = new RGB(23, 123, 23, 0.5);

            // Act
            var result = _colorBlenderService.Saturation(backdrop, source).ToRgb();

            // Arrange
            var expectedResult = new RGB(112, 34, 23, 0.9);
            Assert.AreEqual(result, expectedResult);
        }
        #endregion
    }
}
