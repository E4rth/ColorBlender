using System;
using System.Collections.Generic;
using System.Drawing;
using ColorBlender.Converters.Models;
using ColorBlender.Models.ColorModels;
using ColorBlender.Models.ColorModels.HEX;
using ColorBlender.Models.ColorModels.HSL;
using ColorBlender.Models.ColorModels.RGB;

namespace ColorBlender.Converters.Factories
{
    /// <summary>
    /// Represents a Factory for creating color converters based on the provided color type.
    /// </summary>
    public class ColorConverterFactory : IColorConverterFactory
    {
        private readonly Dictionary<Type, Type> _converters = new Dictionary<Type, Type>
    {
        { typeof(Color), typeof(ColorConverter)   },
        { typeof(HEX),   typeof(HexConverter)     },
        { typeof(HSL),   typeof(HslConverter)     },
        { typeof(RGB),   typeof(RgbConverter)     },
        { typeof(URGB),  typeof(UnitRgbConverter) }
    };

        public IColorConverter GetColorConverter<T>() where T : IColorModel, new() => (IColorConverter) Activator.CreateInstance(_converters[typeof(T)]);

        public IColorConverter GetColorConverter(Type type) => (IColorConverter) Activator.CreateInstance(_converters[type]);
    }
}
