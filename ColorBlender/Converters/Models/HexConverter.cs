using System;
using System.Globalization;
using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.RGB;

namespace ColorBlender.Converters.Models
{
    /// <summary>
    /// The converter between <see cref="HEX"/> and <see cref="URGB"/> types.
    /// </summary>
    public class HexConverter : IColorConverter
    {
        public URGB ToURGB(object colorModel)
        {
            return new URGB
            {
                R = byte.Parse(((HEX) colorModel).R, NumberStyles.HexNumber) / 255m,
                G = byte.Parse(((HEX) colorModel).G, NumberStyles.HexNumber) / 255m,
                B = byte.Parse(((HEX) colorModel).B, NumberStyles.HexNumber) / 255m,
                A = byte.Parse(((HEX) colorModel).A, NumberStyles.HexNumber) / 255m
            };
        }

        public object ToColorModel(URGB colorModel, bool roundOutput, int decimals)
        {
            var r = colorModel.R * 255;
            var g = colorModel.G * 255;
            var b = colorModel.B * 255;
            var a = colorModel.A * 255;

            if (roundOutput)
            {
                r = Math.Round(r, decimals);
                g = Math.Round(g, decimals);
                b = Math.Round(b, decimals);
            }

            return new HEX
            {
                R = Convert.ToString((int) r, 16),
                G = Convert.ToString((int) g, 16),
                B = Convert.ToString((int) b, 16),
                A = Convert.ToString((int) a, 16)
            };
        }
    }
}
