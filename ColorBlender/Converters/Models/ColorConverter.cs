using System;
using System.Drawing;
using ColorBlender.Models.ColorModels.RGB;

namespace ColorBlender.Converters.Models
{
    /// <summary>
    /// The converter between <see cref="Color"/> and <see cref="URGB"/> types.
    /// </summary>
    public class ColorConverter : IColorConverter
    {
        public URGB ToURGB(object colorModel)
        {
            return new URGB
            {
                R = ((Color) colorModel).R / 255m,
                G = ((Color) colorModel).G / 255m,
                B = ((Color) colorModel).B / 255m,
                A = ((Color) colorModel).A / 255m
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

            return Color.FromArgb(Convert.ToInt32(a), Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
        }
    }
}
