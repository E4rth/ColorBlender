using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.HEX.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorBlender.Tests.Converters
{
    [TestClass]
    public class HexStringConversionTests
    {
        [TestMethod]
        public void Should_Show_HashTag()
        {
            // Assert
            var input = new HEX("#aabbccdd");

            // Act
            var result = input.ToString(EHEXOutputFormat.HEXAConst, EHashSignFormat.Visible);

            // Arrange
            Assert.AreEqual("#aabbccdd", result);
        }

        [TestMethod]
        public void Should_Hide_HashTag()
        {
            // Assert
            var input = new HEX("#aabbccdd");

            // Act
            var result = input.ToString(EHEXOutputFormat.HEXAConst, EHashSignFormat.Hidden);

            // Arrange
            Assert.AreEqual("aabbccdd", result);
        }

        [TestMethod]
        public void Should_Show_HexAlpha_When_Its_Has_Max_Value()
        {
            // Assert
            var input = new HEX("#aabbccff");

            // Act
            var result = input.ToString(EHEXOutputFormat.HEXAConst);

            // Arrange
            Assert.AreEqual("#aabbccff", result);
        }

        [TestMethod]
        public void Should_Show_AlphaHex_When_Its_Has_Max_Value()
        {
            // Assert
            var input = new HEX("#aabbccff");

            // Act
            var result = input.ToString(EHEXOutputFormat.ConstAHEX);

            // Arrange
            Assert.AreEqual("#ffaabbcc", result);
        }

        [TestMethod]
        public void Should_Show_HexAlpha_When_It_Does_Not_Has_Max_Value()
        {
            // Assert
            var input = new HEX("#aabbccdd");

            // Act
            var result = input.ToString(EHEXOutputFormat.HEXAOpt);

            // Arrange
            Assert.AreEqual("#aabbccdd", result);
        }

        [TestMethod]
        public void Should_Show_AlphaHex_When_It_Does_Not_Has_Max_Value()
        {
            // Assert
            var input = new HEX("#aabbccdd");

            // Act
            var result = input.ToString(EHEXOutputFormat.OptAHEX);

            // Arrange
            Assert.AreEqual("#ddaabbcc", result);
        }

        [TestMethod]
        public void Should_Hide_HexAlpha_When_Its_Has_Max_Value()
        {
            // Assert
            var input = new HEX("#aabbccff");

            // Act
            var result = input.ToString(EHEXOutputFormat.HEXAOpt);

            // Arrange
            Assert.AreEqual("#aabbcc", result);
        }

        [TestMethod]
        public void Should_Hide_AlphaHex_When_Its_Has_Max_Value()
        {
            // Assert
            var input = new HEX("#aabbccff");

            // Act
            var result = input.ToString(EHEXOutputFormat.OptAHEX);

            // Arrange
            Assert.AreEqual("#aabbcc", result);
        }
    }
}
