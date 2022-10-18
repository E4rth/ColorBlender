using System.Drawing;
using ColorBlender.Converters.Services;
using ColorBlender.Models.ColorModels.HSL;
using ColorBlender.Models.ColorModels.RGB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorBlender.Tests.Converters
{
    [TestClass]
    public class HslConversionTests
    {
        private readonly IColorConverterService _colorConverterService = new ColorConverterService();

        [TestMethod]
        public void Should_Convert_From_Hsl_And_Convert_Back()
        {
            // Assert
            var input = new HSL(126, 63, 65, 1);

            // Act
            var result = _colorConverterService.ToHsl(input);

            // Arrange
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Should_Convert_To_Urgb()
        {
            // Assert
            var input = new HSL(126, 63, 65, 1);

            // Act
            var result = _colorConverterService.ToUrgb(input);

            // Arrange
            Assert.AreEqual(result, new URGB(
                0.4295m,
                0.8705m,
                0.4736000000000000000000000001m,
                1));
        }

        [TestMethod]
        public void Should_Convert_To_Hex()
        {
            // Assert
            var input = new HSL(126, 63, 65, 1);

            // Act
            var result = _colorConverterService.ToHex(input).ToString();

            // Arrange
            Assert.AreEqual(result, "#6ede79");
        }

        [TestMethod]
        public void Should_Convert_To_Rgb()
        {
            // Assert
            var input = new HSL(126, 63, 65, 1);
            
            // Act
            var result = _colorConverterService.ToRgb(input);

            // Arrange
            Assert.AreEqual(result, new RGB(110, 222, 121, 1));
        }

        [TestMethod]
        public void Should_Convert_To_Color()
        {
            // Assert
            var input = new HSL(126, 63, 65, 1);
            
            // Act
            var result = _colorConverterService.ToColor(input);

            // Arrange
            Assert.AreEqual(result, Color.FromArgb(255, 110, 222, 121));
        }
    }
}
