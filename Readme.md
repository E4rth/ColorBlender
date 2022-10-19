# Color Blender

[![Version on NuGet](https://img.shields.io/nuget/v/E4rth.ColorBlender?style=flat-square)](https://www.nuget.org/packages/E4rth.ColorBlender/)

>Blends colors with various blend modes in C#

This is a Color Blending library that implements all the blending modes introduced in the [W3C Compositing and Blending spec](https://www.w3.org/TR/compositing-1/).

## Table of Content

- [Features](#features)
   + [Blend Modes](#blend-modes)
   + [Color types](#color-types)
   + [Converter](#converter)
- [Blending](#blending)
   + [Usage](#usage)
   + [Notes](#notes)
- [Download](#download)
- [Thanks](#thanks)
- [Creative Society](#creative-society)

## Features
### Blend Modes
This library provides an implementation for all blend modes listed in the W3C document, such as:

* `Normal`
* `Multiply`
* `Screen`
* `Overlay`
* `Darken`
* `Lighten`
* `Color Dodge`
* `Color Burn` 
* `Hard Light`
* `Soft Light`
* `Difference`
* `Exclusion`
* `Hue`
* `Color`
* `Luminosity`
* `Saturation`

### Color types
 Build-in support for commonly used color types: **Unit Rgb, Rgb, Hsl, Hex** and **Color** from *Sytem.Drawing* assembly.

 #### Unit Rgb

 It is a higher precision form of `RGB` color that uses `decimal` values.</br>
 All the inner blending calculations are performed in this form of a color.</br>
 The `Red`, `Green`, `Blue` and `Alpha` channels are represented by a fractional value between 0 and 1.

 #### RGB

 The `Red`, `Green` and `Blue` channels are represented by a fractional value between 0 and 255.<br/>
 The `Alpha` channel is represented by a fractional value between 0 and 1.

 #### Color

 Default Color Struct from **System.Drawing** assembly

 #### HSL

 The `Hue` channel is represented by a fractional value between 0 and 360.<br/>
 The `Saturation` and `Luminosity` channels are represented by a fractional value between 0 and 100.<br/>
 The `Alpha` channel is represented by a fractional value between 0 and 1.

 #### HEX

 The `Red`, `Green`, `Blue` and `Alpha` channels are represented by a hexadecimal form of a `String` between "00" and "ff".<br/>
 Class constructor supports any form of a Hex color, such as it's short form `#rgb`, and full forms with <b>leading</b> or <b>trailing</b> Alpha channel (`#aarrggbb` and `#rrggbbaa`) with an optional `#` sign.<br/>
 The Hex Object also can be represented as a `String` with all the forms described above.

 <details>
  <summary>Example</summary>

   ```c#
   using ColorBlender;

   static void Main(string[] args)
   {
       var hex        = new HEX("#bbccdd");
       var anotherHex = new HEX("bbccdd");
       var ahex       = new HEX("#aabbccdd", EHEXFormat.AHEX);
       var hexa       = new HEX("#bbccddaa", EHEXFormat.HEXA);
       var shortHex   = new HEX("#abc");
       var userHex    = new HEX("bb", "cc", "dd", "aa");

       var resultHexAOpt   = hex.ToString(EHEXOutputFormat.HEXAOpt,   EHashSignFormat.Visible); // Result: "#bbccdd"
       var resultOptAHex   = hex.ToString(EHEXOutputFormat.OptAHEX,   EHashSignFormat.Hidden);  // Result: "bbccdd"
       var resultHexAConst = hex.ToString(EHEXOutputFormat.HEXAConst, EHashSignFormat.Visible); // Result: "#bbccddff"
       var resultConstAHex = hex.ToString(EHEXOutputFormat.ConstAHEX, EHashSignFormat.Hidden);  // Result: "ffbbccdd"
   }
   ```
   </details>

### Converter
 Built-in converter for all the color types described above, with an optional output rounding.

 <details>
 <summary>Usage</summary>

 ```c#
 using ColorBlender;

 private readonly IColorConverterService _colorConverterService = new ColorConverterService();

 static void Main(string[] args)
 {
    var rgb = new RGB(211, 107, 184, 0.94);

    // Conversion
    var resultRgb   = _colorConverterService.ToRgb(rgb);   // Result: new RGB(211, 107, 184, 0.94);
    var resultHex   = _colorConverterService.ToHex(rgb);   // Result: new HEX("d3", "6b", "b8", "ef")
    var resultHsl   = _colorConverterService.ToHsl(rgb);   // Result: new HSL(315, 54, 62, 0.94)
    var resultColor = _colorConverterService.ToColor(rgb); // Result: new Color(211, 107, 184, 240) *;

    // Conversion with rounding (Input Color, Rounding, Number of decimal places in the return value)
    var resultUrgb  = _colorConverterService.ToURgb(rgb, true, 5); // Result: new URGB(0.82645, 0.41961, 0.72157, 0.94);
 }
 ```

  `*` This is not a proper way to create a system color. It is used here in this form only to display the result.
 </details>

## Blending
Create an instance of the `ColorBlenderService` and use it blend your colors.<br/>
The result of the blending will be returned as an Object of a `Uniform Color` type, that can be further represented as any color type you want. See the example bellow.

 <div align="center">
 <img src="https://raw.githubusercontent.com/E4rth/ColorBlender/master/Art/Example.jpg" alt="Example"/>
 </div>

### Usage
```c#
using ColorBlender;

private readonly IColorBlenderService _colorBlenderService = new ColorBlenderService();

static void Main(string[] args)
{
    var background = new RGB(105, 151, 206, 0.8);
    var foreground = new RGB(247, 92, 177, 0.7);

    RGB   resultRgb   = _colorBlenderService.Normal(background, foreground).ToRgb();   // Result: new RGB(211, 107, 184, 0.94);
    HEX   resultHex   = _colorBlenderService.Normal(background, foreground).ToHex();   // Result: new HEX("d3", "6b", "b8", "ef");
    HSL   resultHsl   = _colorBlenderService.Normal(background, foreground).ToHsl();   // Result: new HSL(315, 54, 62, 0.94);
    Color resultColor = _colorBlenderService.Normal(background, foreground).ToColor(); // Result: new Color(211, 107, 184, 240) *;
    // Rounding the output value to 5 decimal places in the return value.
    URGB  resultURgb  = _colorBlenderService.Normal(background, foreground).ToUrgb(true, 5); // Result: new URGB(0.82645, 0.41986, 0.72315, 0.94);
}
```
 `*` This is not a proper way to create a system color. It is used here in this form only to display the result.

 ### Notes
 * Powered by .NET Standart 2.0

 * <b>Adobe Photoshop</b> uses slightly different algoritm and rounding to perform color blending, which means that you won't get an identical result.

 * Might be bugs. Please submit an issue if you find one.

## Download
Get the library from [NuGet](https://www.nuget.org/packages/E4rth.ColorBlender/) [![Version on NuGet](https://img.shields.io/nuget/v/E4rth.ColorBlender?style=flat-square)](https://www.nuget.org/packages/E4rth.ColorBlender/)

## Thanks
Many thanks to:
 * [Florian Reuschel](https://github.com/loilo) and his [color-blend](https://github.com/loilo/color-blend) JavaScript library for insperation.
 * [Artyom Gritsuk](https://github.com/iamartyom) and his [ColorHelper](https://github.com/iamartyom/ColorHelper) C# color converter library. I have been messing around with HSL conversion for a long time until I peeked into his code.
 * [FlatIcon](https://www.flaticon.com/free-icon/rgb_1157899?term=color%20wheel&related_id=1157899) for package icon.

 ## Creative Society

 <div align="center">
 <img src="https://creativesociety.com/themes/tv/assets/images/cs-logos/allatra-ornament.jpg" alt="creative society logo" width="200"/>

 <b>We support [Creative Society](https://creativesociety.com/)</b>
 </div>

 <b>Creative Society</b> is a worldwide project of all humanity and it concerns everyone. 

 ### Project objectives
 * To create conditions for building a creative society on the whole planet by peaceful means.
 * To ask people all over the world whether they want to live in a creative society, and how they envisage it.
 * To provide a platform for a global, international, open discussion of the concept and model of the creative society in all spheres of human life.
 * To find new ways to unite the entire humanity and create conditions for the active participation of every person in the life of society, regardless of social status, religion or nationality.

 Join [us](https://creativesociety.com/) today!
