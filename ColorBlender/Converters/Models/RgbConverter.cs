using System;
using ColorBlender.Models.ColorModels.RGB;

namespace ColorBlender.Converters.Models
{
    /// <summary>
    /// The converter between <see cref="RGB"/> and <see cref="URGB"/> types.
    /// </summary>
    public class RgbConverter : IColorConverter
    {
        public URGB ToURGB(object colorModel)
        {
            return new URGB
            {
                R = (decimal) ((RGB) colorModel).R / 255m,
                G = (decimal) ((RGB) colorModel).G / 255m,
                B = (decimal) ((RGB) colorModel).B / 255m,
                A = (decimal) ((RGB) colorModel).A
            };
        }

        public object ToColorModel(URGB colorModel, bool roundOutput, int decimals)
        {
            var r = colorModel.R * 255;
            var g = colorModel.G * 255;
            var b = colorModel.B * 255;
            var a = colorModel.A;

            if (roundOutput)
            {
                r = Math.Round(r, decimals);
                g = Math.Round(g, decimals);
                b = Math.Round(b, decimals);
            }

            return new RGB
            {
                R = (double) r,
                G = (double) g,
                B = (double) b,
                A = (double) a
            };
        }
    }
}
