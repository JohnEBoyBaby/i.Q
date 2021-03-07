using System;
using System.ComponentModel;

namespace Smart3DWeb
{
	/// <summary>
	/// Structure to define RGB.
	/// </summary>
	public struct RGB
	{
		/// <summary>
		/// Gets an empty RGB structure;
		/// </summary>
		public static readonly RGB Empty = new RGB();

		#region Fields
		private int red;
		private int green;
		private int blue;

		private const int redmin = 0; 
		private const int greenmin = 0; 
		private const int bluemin = 0; 

		private const int redmax = 255; 
		private const int greenmax = 255; 
		private const int bluemax = 255; 

		#endregion

		#region Operators
		public static bool operator ==(RGB item1, RGB item2)
		{
			return (
				item1.Red == item2.Red 
				&& item1.Green == item2.Green 
				&& item1.Blue == item2.Blue
				);
		}

		public static bool operator !=(RGB item1, RGB item2)
		{
			return (
				item1.Red != item2.Red 
				|| item1.Green != item2.Green 
				|| item1.Blue != item2.Blue
				);
		}

		#endregion

		#region Accessors
		[Description("Red component."),]
		public int Red
		{
			get
			{
				return red;
			}
			set
			{
                red = value;
				red = ( red > redMax ) ? redMax : ( (red < redMin) ? redMin : red); 
			}
		}

		[Description("Green component."),]
		public int Green
		{
			get
			{
				return green;
			}
			set
			{
                green =  value;
				green = ( green > greenMax ) ? greenMax : ( (green < greenMin) ? greenMin : green); 
			}
		}

		[Description("Blue component."),]
		public int Blue
		{
			get
			{
				return blue;
			}
			set
			{
                blue = value;
				blue = ( blue > blueMax ) ? blueMax : ( (blue < blueMin) ? blueMin : blue); 
			}
		}

		public static int redMin
		{ 
			get
			{
				return redmin;
			} 
		} 
		public static int greenMin
		{ 
			get
			{
				return greenmin;
		    }
        } 
		public static int blueMin
		{ 
			get
			{
				return bluemin;
			} 
		} 
		public static int redMax
		{ 
			get
			{
				return redmax;
			} 
		} 
		public static int greenMax
		{ 
			get
			{
				return greenmax;
		    }
        } 
		public static int blueMax
		{ 
			get
			{
				return bluemax;
			} 
		} 
		#endregion

		public RGB(int R, int G, int B) 
		{
			red =   (R > redmax  ) ? redmax   : (( R < redmin   ) ? redmin   : R);
			green = (G > greenmax) ? greenmax : (( G < greenmin ) ? greenmin : G);
			blue =  (B > bluemax ) ? bluemax  : (( B < bluemin  ) ? bluemin  : B);
		}

		#region Methods
		public override bool Equals(Object obj) 
		{
			if(obj==null || GetType()!=obj.GetType()) return false;

			return (this == (RGB)obj);
		}

		public override int GetHashCode() 
		{
			return Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode();
		}

		#endregion
	} 
}
