using System;
using UnityEngine;

namespace Game
{
	public class ColorSchema
	{
		public enum Schemas
		{
			DARK_GREEN,
			LIGHT_STEEL,
			LIGHT_YELLOW,
			LIGHT_BABY_BLUE
		}

		Color background;
		Color circle;
		Color lineCrossing;
		Color lineClear;
		Color font;
		Color timer;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:AssemblyCSharp.ColorSchema"/> class.
		/// </summary>
		/// <param name="schema">Colorschema to be used. This defines all colors in game.</param>
		/// <param name="lineColorCoding">Decides if the lines uses colorcoding</param>
		public ColorSchema(Schemas schema, bool lineColorCoding)
		{
			if (schema == Schemas.LIGHT_YELLOW)
			{
				background = new Color(254, 252, 227, 100); // HEX = #FEFCE3
				circle = new Color(95, 95, 95, 100);     // HEX = #5F5F5F
				font = new Color(0, 0, 0, 100);          // HEX = #000000
				timer = new Color(151, 151, 151, 100); // HEX = #979797

				// Defining color-coding for lines:
				if (lineColorCoding)
				{
					lineClear = new Color(123,255,144, 57);  // HEX = #7BFF72
					lineCrossing = new Color(255, 88, 88, 57);   // HEX = #FF5858
				}
				else
				{
					lineClear = new Color(95, 95, 95, 100);  // HEX = #5F5F5F
					lineCrossing = new Color(95, 95, 95, 100);   // HEX = #5F5F5F
				}
					
			}
			else if (schema == Schemas.DARK_GREEN)
			{
				background = new Color(42, 71, 78, 100);    // HEX = #29474E
				circle = new Color(255, 252, 231, 100);   // HEX = #FFFDE8
				font = new Color(255, 252, 231, 100); // HEX = #FFFCE7  w
				timer = new Color(255, 252, 231, 100); // HEX = #FFFCE7

				// Defining color-coding for lines:
				if (lineColorCoding)
				{
					lineClear = new Color(185, 255, 180, 57);  // HEX = #B9FFB4
					lineCrossing = new Color(255, 172, 172, 57);   // HEX = #FFACAC
				}
				else
				{
					lineClear = new Color(255, 255, 255, 57);  // HEX = #FFFFFF
					lineCrossing = new Color(255, 255, 255, 57);  // HEX = #FFFFFF
				}
			}
			else if (schema == Schemas.LIGHT_STEEL)
			{
				// Using default colors. 
				background = new Color(244, 244, 244, 100); // HEX = #F4F4F4
				circle = new Color(95, 95, 95, 100);    // HEX = #5F5F5F
				font = new Color(0, 0, 0, 100);       // HEX = #000000
				timer = new Color(151, 151, 151, 100); // HEX = #979797
													   // Defining color-coding for lines:
				if (lineColorCoding)
				{
					lineClear = new Color(123, 255, 144, 57);  // HEX = #7BFF72
					lineCrossing = new Color(255, 88, 88, 57);   // HEX = #FF5858
				}
				else
				{
					lineClear = new Color(95, 95, 95, 100);  // HEX = #5F5F5F
					lineCrossing = new Color(95, 95, 95, 100);   // HEX = #5F5F5F
				}
			}
			else if (schema == Schemas.LIGHT_BABY_BLUE)
			{
				// Using default colors. 
				background = new Color(243, 255, 251, 100); // HEX = #F4FFFC
				circle = new Color(95, 95, 95, 100);    // HEX = #5F5F5F
				font = new Color(0, 0, 0, 100);       // HEX = #000000
				timer = new Color(151, 151, 151, 100); // HEX = #979797

				// Defining color-coding for lines:
				if (lineColorCoding)
				{
					lineClear = new Color(123, 255, 144, 57);  // HEX = #7BFF72
					lineCrossing = new Color(255, 88, 88, 57);   // HEX = #FF5858
				}
				else
				{
					lineClear = new Color(95, 95, 95, 100);  // HEX = #5F5F5F
					lineCrossing = new Color(95, 95, 95, 100);   // HEX = #5F5F5F
				}
			}
			else
			{
				background = new Color(243, 255, 251, 100); // HEX = #F4FFFC
				circle = new Color(95, 95, 95, 100);    // HEX = #5F5F5F
				font = new Color(0, 0, 0, 100);       // HEX = #000000
				timer = new Color(151, 151, 151, 100); // HEX = #979797

				// Defining color-coding for lines:
				if (lineColorCoding)
				{
					lineClear = new Color(123, 255, 144, 57);  // HEX = #7BFF72
					lineCrossing = new Color(255, 88, 88, 57);   // HEX = #FF5858
				}
				else
				{
					lineClear = new Color(95, 95, 95, 100);  // HEX = #5F5F5F
					lineCrossing = new Color(95, 95, 95, 100);   // HEX = #5F5F5F
				}
			}

			background.r /= 255.0f; 
			background.g /= 255.0f;
			background.b /= 255.0f;
			background.a /= 100.0f;

			circle.r /= 255.0f;
			circle.g /= 255.0f;
			circle.b /= 255.0f;
			circle.a /= 100.0f;

			lineClear.r /= 255.0f;
			lineClear.g /= 255.0f;
			lineClear.b /= 255.0f;
			lineClear.a /= 100.0f;

			lineCrossing.r /= 255.0f;
			lineCrossing.g /= 255.0f;
			lineCrossing.b /= 255.0f;
			lineCrossing.a /= 100.0f;

			font.r /= 255.0f;
			font.g /= 255.0f;
			font.b /= 255.0f;
			font.a /= 100.0f;

			timer.r /= 255.0f;
			timer.g /= 255.0f;
			timer.b /= 255.0f;
			timer.a /= 100.0f;
		}

		/// <summary>
		/// Gets the background color.
		/// </summary>
		/// <value>The background color.</value>
		public Color Background
		{
			get
			{
				return background;
			}
		}

		/// <summary>
		/// Gets the circle color.
		/// </summary>
		/// <value>The circle color.</value>
		public Color Circle
		{
			get
			{
				return circle;
			}
		}
		 /// <summary>
		 /// Gets the line crossing color. Used when a line
		/// is crossing another line.
		 /// </summary>
		 /// <value>The line crossing color.</value>
		public Color LineCrossing
		{
			get
			{
				return lineCrossing;
			}
		}

		/// <summary>
		/// Gets the line clear color. Used when the line is not crossing 
		/// any other line.
		/// </summary>
		/// <value>The line clear color.</value>
		public Color LineClear
		{
			get
			{
				return lineClear;
			}
		}

		/// <summary>
		/// Gets the font color.
		/// </summary>
		/// <value>The font color.</value>
		public Color Font
		{
			get
			{
				return font;
			}
		}

		/// <summary>
		/// Gets the timer color.
		/// </summary>
		/// <value>The timer color.</value>
		public Color Timer
		{
			get
			{
				return timer;
			}
		}
	}
}
