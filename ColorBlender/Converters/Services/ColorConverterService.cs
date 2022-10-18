﻿using ColorBlender.Converters.Factories;
using ColorBlender.Converters.Models;
using ColorBlender.Models.ColorModels;
using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.HSL;
using ColorBlender.Models.ColorModels.RGB;
using Color = System.Drawing.Color;

namespace ColorBlender.Converters.Services
{
    /// <summary>
    /// Represents the converter between any <see cref="IColorModel"/> or <see cref="Color"/> types.
    /// </summary>
    public class ColorConverterService : IColorConverterService
    {
        private readonly IColorConverterFactory _converterFactory = new ColorConverterFactory();

        public URGB ToUrgb(IColorModel colorModel, bool roundOutput = false, int decimals = 3)
        {
            var urgb = _converterFactory.GetColorConverter(colorModel.GetType()).ToURGB(colorModel);
            return (URGB)_converterFactory.GetColorConverter<URGB>().ToColorModel(urgb, roundOutput, decimals);
        }

        public URGB ToUrgb(Color colorModel, bool roundOutput = false, int decimals = 3) 
        {
            var urgb = _converterFactory.GetColorConverter(colorModel.GetType()).ToURGB(colorModel);
            return (URGB)_converterFactory.GetColorConverter<URGB>().ToColorModel(urgb, roundOutput, decimals);
        }

        public RGB ToRgb(IColorModel colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = _converterFactory.GetColorConverter(colorModel.GetType()).ToURGB(colorModel);
            return (RGB) _converterFactory.GetColorConverter<RGB>().ToColorModel(urgb, roundOutput, decimals);
        }

        public RGB ToRgb(Color colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = new ColorConverter().ToURGB(colorModel);
            return (RGB) _converterFactory.GetColorConverter<RGB>().ToColorModel(urgb, roundOutput, decimals);
        }

        public HSL ToHsl(IColorModel colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = _converterFactory.GetColorConverter(colorModel.GetType()).ToURGB(colorModel);
            return (HSL) _converterFactory.GetColorConverter<HSL>().ToColorModel(urgb, roundOutput, decimals);
        }

        public HSL ToHsl(Color colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = new ColorConverter().ToURGB(colorModel);
            return (HSL) _converterFactory.GetColorConverter<HSL>().ToColorModel(urgb, roundOutput, decimals);
        }

        public HEX ToHex(IColorModel colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = _converterFactory.GetColorConverter(colorModel.GetType()).ToURGB(colorModel);
            return (HEX) _converterFactory.GetColorConverter<HEX>().ToColorModel(urgb, roundOutput, decimals);
        }

        public HEX ToHex(Color colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = new ColorConverter().ToURGB(colorModel);
            return (HEX) _converterFactory.GetColorConverter<HEX>().ToColorModel(urgb, roundOutput, decimals);
        }

        public Color ToColor(IColorModel colorModel, bool roundOutput = true, int decimals = 0)
        {
            var urgb = _converterFactory.GetColorConverter(colorModel.GetType()).ToURGB(colorModel);
            return (Color) _converterFactory.GetColorConverter(typeof(Color)).ToColorModel(urgb, roundOutput, decimals);
        }
    }
}
