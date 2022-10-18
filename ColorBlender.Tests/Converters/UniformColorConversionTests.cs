using System.Drawing;
using ColorBlender.Converters.Models;
using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.HSL;
using ColorBlender.Models.ColorModels.RGB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorBlender.Tests.Converters
{
    [TestClass]
    public class UniformColorConversionTests
    {
        [TestMethod]
        public void Should_Convert_To_Rgb()
        {
            // Assert
            var input = new URGB(
                0.4352941176470588235294117647m,
                0.4823529411764705882352941176m,
                0.9058823529411764705882352941m,
                1);

            // Act
            var result = new UniformColor(input).ToRgb();

            // Arrange
            Assert.AreEqual(result, new RGB(111, 123, 231, 1));
        }

        [TestMethod]
        public void Should_Convert_To_Hex()
        {
            // Assert
            var input = new URGB(
                0.4352941176470588235294117647m,
                0.4823529411764705882352941176m,
                0.9058823529411764705882352941m,
                1);

            // Act
            var result = new UniformColor(input).ToHex();

            // Arrange
            Assert.AreEqual(result, new HEX("6f", "7b", "e7", "ff"));
        }

        [TestMethod]
        public void Should_Convert_To_Hsl()
        {
            // Assert
            var input = new URGB(
                0.4352941176470588235294117647m,
                0.4823529411764705882352941176m,
                0.9058823529411764705882352941m,
                1);

            // Act
            var result = new UniformColor(input).ToHsl();

            // Arrange
            Assert.AreEqual(result, new HSL(234, 71, 67, 1));
        }

        [TestMethod]
        public void Should_Convert_To_Urgb()
        {
            // Assert
            var input = new URGB(
                0.4352941176470588235294117647m,
                0.4823529411764705882352941176m,
                0.9058823529411764705882352941m,
                1);

            // Act
            var result = new UniformColor(input).ToUrgb(false);

            // Arrange
            Assert.AreEqual(result, input);
        }

        [TestMethod]
        public void Should_Convert_To_Color()
        {
            // Assert
            var input = new URGB(
                0.4352941176470588235294117647m,
                0.4823529411764705882352941176m,
                0.9058823529411764705882352941m,
                1);

            // Act
            var result = new UniformColor(input).ToColor();

            // Arrange
            Assert.AreEqual(result, Color.FromArgb(255, 111, 123, 231));
        }
    }
}
