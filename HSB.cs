using System;
using System.ComponentModel;

namespace Smart3DWeb
{
	/// <summary>
	/// Structure to define HSB.
	/// </summary>
	public struct HSB
	{
		/// <summary>
		/// Gets an empty HSB structure;
		/// </summary>
		public static readonly HSB Empty = new HSB();

		#region Fields
		private double hue;
		private double saturation;
		private double brightness;

		private const double huemin = 0.0;
		private const double saturationmin = 0.0;
		private const double brightnessmin = 0.0;

		private const double huemax = 360.0;
		private const double saturationmax = 1.0;
		private const double brightnessmax = 1.0;

		#endregion

		#region Operators
		public static bool operator ==(HSB item1, HSB item2)
		{
			return (
				item1.Hue == item2.Hue 
				&& item1.Saturation == item2.Saturation 
				&& item1.Brightness == item2.Brightness
				);
		}

		public static bool operator !=(HSB item1, HSB item2)
		{
			return (
				item1.Hue != item2.Hue 
				|| item1.Saturation != item2.Saturation 
				|| item1.Brightness != item2.Brightness
				);
		}

		#endregion

		#region Accessors
		/// <summary>
		/// Gets or sets the hue component.
		/// </summary>
		[Description("Hue component"),]
		public double Hue 
		{ 
			get
			{
				return hue;
			} 
			set
			{ 
                hue = value;
				hue = ( hue > hueMax ) ? hueMax : ( (hue < hueMin) ? hueMin : hue); 
			} 
		} 

		/// <summary>
		/// Gets or sets saturation component.
		/// </summary>
		[Description("Saturation component"),]
		public double Saturation 
		{ 
			get
			{
				return saturation;
			} 
			set
			{ 
                saturation = value;
				saturation = ( saturation > saturationMax ) ? saturationMax : ( (saturation < saturationMin) ? saturationMin : saturation); 
			} 
		} 

		/// <summary>
		/// Gets or sets the brightness component.
		/// </summary>
		[Description("Brightness component"),]
		public double Brightness 
		{ 
			get
			{
				return brightness;
			} 
			set
			{ 
                brightness = value;
				brightness = ( brightness > brightnessMax ) ? brightnessMax : ( (brightness < brightnessMin) ? brightnessMin : brightness); 
			} 
		}

		public static double hueMin
		{ 
			get
			{
				return huemin;
			} 
		} 
		public static double saturationMin
		{ 
			get
			{
				return saturationmin;
		    }
        } 
		public static double brightnessMin
		{ 
			get
			{
				return brightnessmin;
			} 
		} 
		public static double hueMax
		{ 
			get
			{
				return huemax;
			} 
		} 
		public static double saturationMax
		{ 
			get
			{
				return saturationmax;
		    }
        } 
		public static double brightnessMax
		{ 
			get
			{
				return brightnessmax;
			} 
        }
		#endregion

		/// <summary>
		/// Creates an instance of a HSB structure.
		/// </summary>
		/// <param name="h">Hue value.</param>
		/// <param name="s">Saturation value.</param>
		/// <param name="b">Brightness value.</param>
		public HSB(double h, double s, double b) 
		{
			hue        =   (h > huemax         ) ? huemax        : (( h < huemin        ) ? huemin        : h);
			saturation =   (s > saturationmax  ) ? saturationmax : (( s < saturationmin ) ? saturationmin : s);
			brightness =   (b > brightnessmax  ) ? brightnessmax : (( b < brightnessmin ) ? brightnessmin : b);
		}

		#region Methods
		public override bool Equals(Object obj) 
		{
			if(obj==null || GetType()!=obj.GetType()) return false;

			return (this == (HSB)obj);
		}

		public override int GetHashCode() 
		{
			return Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Brightness.GetHashCode();
		}

		#endregion
	}
}
