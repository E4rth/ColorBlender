using System.Drawing;
using ColorBlender.Converters.Services;
using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.HEX.Enums;
using ColorBlender.Models.ColorModels.HSL;
using ColorBlender.Models.ColorModels.RGB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorBlender.Tests.Converters
{
    [TestClass]
    public class HexConversionTests
    {
        private readonly IColorConverterService _colorConverterService = new ColorConverterService();

        [TestMethod]
        public void Should_Convert_From_Hex_And_Convert_Back()
        {
            // Assert
            var input = new HEX("#6fde7b");

            // Act
            var result = _colorConverterService.ToHex(input);
            
            // Arrange
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Should_Convert_To_Urgb()
        {
            // Assert
            var input = new HEX("#6fde7b");

            // Act
            var result = _colorConverterService.ToUrgb(input);

            // Arrange
            Assert.AreEqual(result, new URGB(
                0.4352941176470588235294117647m,
                0.8705882352941176470588235294m,
                0.4823529411764705882352941176m,
                1));
        }

        [TestMethod]
        public void Should_Convert_To_Rgb()
        {
            // Assert
            var input = new HEX("#6fde7b");

            // Act
            var result = _colorConverterService.ToRgb(input);

            // Arrange
            Assert.AreEqual(result, new RGB(111, 222, 123, 1));
        }

        [TestMethod]
        public void Should_Convert_To_Hsl()
        {
            // Assert
            var input = new HEX("#6fde7b");

            // Act
            var result = _colorConverterService.ToHsl(input);

            // Arrange
            Assert.AreEqual(result, new HSL(126, 63, 65, 1));
        }

        [TestMethod]
        public void Should_Convert_To_Color()
        {
            // Assert
            var input = new HEX("#6fde7b");

            // Act
            var result = _colorConverterService.ToColor(input);

            // Arrange
            Assert.AreEqual(result, Color.FromArgb(255, 111, 222, 123));
        }
    }
}
