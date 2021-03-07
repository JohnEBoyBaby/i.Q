using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Smart3DWeb
{
    public class Drawing
    {
        public void Brightness(ref System.Windows.Media.Imaging.WriteableBitmap writeableBitmap,
                                   System.Double brightnessAdjustment)
        {
            System.Int32 numberOfPixels;
            System.Int32 pixelNumber;
            System.Int32 color;
            System.Int32 alpha;
            System.Int32 red;
            System.Int32 green;
            System.Int32 blue;
            Smart3DWeb.RGB rgb;
            Smart3DWeb.HSB hsb;

            numberOfPixels = writeableBitmap.Pixels.Length;

            for (pixelNumber = 0;
                 pixelNumber < numberOfPixels;
                 pixelNumber++)
            {
                color = writeableBitmap.Pixels[pixelNumber];

                blue = (color & 0xFF); color >>= 8;
                green = (color & 0xFF); color >>= 8;
                red = (color & 0xFF); color >>= 8;
                alpha = (color & 0xFF); color >>= 8;

                hsb = RGBtoHSB(red,
                               green,
                               blue);

                hsb.Brightness += brightnessAdjustment;
                rgb = HSBtoRGB(hsb);

                writeableBitmap.Pixels[pixelNumber] = alpha << 24 |
                                                      rgb.Red << 16 |
                                                      rgb.Green << 8 |
                                                      rgb.Blue;
            }
        }

        public HSB RGBtoHSB(System.Int32 red,
                            System.Int32 green,
                            System.Int32 blue)
        {
            System.Double r = ((System.Double)red / 255.0);
            System.Double g = ((System.Double)green / 255.0);
            System.Double b = ((System.Double)blue / 255.0);

            System.Double max = System.Math.Max(r, System.Math.Max(g, b));
            System.Double min = System.Math.Min(r, System.Math.Min(g, b));

            System.Double h = 0.0;
            System.Double s = 0.0;

            if (max == r && g >= b)
            {
                if (max - min == 0)
                {
                    h = 0.0;
                }
                else
                {
                    h = 60 * (g - b) / (max - min);
                }
            }
            else if (max == r && g < b)
            {
                h = 60 * (g - b) / (max - min) + 360;
            }
            else if (max == g)
            {
                h = 60 * (b - r) / (max - min) + 120;
            }
            else if (max == b)
            {
                h = 60 * (r - g) / (max - min) + 240;
            }

            if (max != 0)
            {
                s = (1.0 - ((System.Double)min / (System.Double)max));
            }

            return new HSB(h, s, (System.Double)max);
        }

        public RGB HSBtoRGB(HSB hsb)
        {
            System.Double r = 0.0;
            System.Double g = 0.0;
            System.Double b = 0.0;

            if (hsb.Saturation == 0)
            {
                r = hsb.Brightness;
                g = hsb.Brightness;
                b = hsb.Brightness;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                System.Double sectorPos = hsb.Hue / 60.0;
                System.Int32 sectorNumber = (System.Int32)(System.Math.Floor(sectorPos));

                // get the fractional part of the sector
                System.Double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                System.Double p = hsb.Brightness * (1.0 - hsb.Saturation);
                System.Double q = hsb.Brightness * (1.0 - (hsb.Saturation * fractionalSector));
                System.Double t = hsb.Brightness * (1.0 - (hsb.Saturation * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = hsb.Brightness;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = hsb.Brightness;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = hsb.Brightness;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = hsb.Brightness;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = hsb.Brightness;
                        break;
                    case 5:
                        r = hsb.Brightness;
                        g = p;
                        b = q;
                        break;
                }
            }
            return new RGB(Convert.ToInt32(System.Double.Parse(System.String.Format("{0:0.00}", r * 255.0))),
                           Convert.ToInt32(System.Double.Parse(System.String.Format("{0:0.00}", g * 255.0))),
                           Convert.ToInt32(System.Double.Parse(System.String.Format("{0:0.00}", b * 255.0))));
        }
    }
}
