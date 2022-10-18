using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.HEX.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorBlender.Tests.Parsers
{
    [TestClass]
    public class HexStringParserTests
    {
        [TestMethod]
        [DataRow("#aabbccdd")]
        [DataRow("aabbccdd")]
        public void Should_Parse_HexA(string value)
        {
            // Act
            var hexA = new HEX(value, EHEXFormat.HEXA);

            // Arrange
            Assert.AreEqual(hexA, new HEX("aa", "bb", "cc", "dd"));
        }

        [TestMethod]
        [DataRow("#ddaabbcc")]
        [DataRow("ddaabbcc")]
        public void Should_Parse_AHex(string value)
        {
            // Act
            var hexA = new HEX(value, EHEXFormat.AHEX);

            // Arrange
            Assert.AreEqual(hexA, new HEX("aa", "bb", "cc", "dd"));
        }

        [TestMethod]
        [DataRow("#abc")]
        [DataRow("abc")]
        public void Should_Parse_Short_Hex(string value)
        {
            // Act
            var hexA = new HEX(value);

            // Arrange
            Assert.AreEqual(hexA, new HEX("aa", "bb", "cc", "ff"));
        }

        [TestMethod]
        [DataRow("#aabbcc")]
        [DataRow("aabbcc")]
        public void Should_Parse_Hex_Without_Alpha(string value)
        {
            // Act
            var hexA = new HEX(value);

            // Arrange
            Assert.AreEqual(hexA, new HEX("aa", "bb", "cc", "ff"));
        }


    }
}