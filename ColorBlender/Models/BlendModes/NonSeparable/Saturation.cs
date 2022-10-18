using ColorBlender.Models.ColorModels.RGB;

namespace ColorBlender.Models.BlendModes.NonSeparable
{
    /// <summary>
    /// Represents the <see href="https://www.w3.org/TR/compositing-1/#blendingsaturation">Saturation</see> blend mode.
    /// </summary>
    public class Saturation : INonSeparableBlendMode
    {
        private readonly NonSeparableHelpers _nonSeparableHelpers = new NonSeparableHelpers();

        public URGB Blend(URGB backdrop, URGB source) => _nonSeparableHelpers.SetLuminosity(
                _nonSeparableHelpers.SetSaturation(backdrop, _nonSeparableHelpers.GetSaturation(source)),
                _nonSeparableHelpers.GetLuminosity(backdrop));
    }
}
