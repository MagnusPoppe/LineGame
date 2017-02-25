using System;
using UnityEngine;

namespace Game
{
	public class Line
	{
		// Distance to compensate for the bad precision of floats.
		const float MINIMIUM_TRESHOLD = 0.1f;

		float s; 
		float m;

		float a;
		float b;
		float c;

		float x1, y1, x2, y2; 

		/// <summary>
		/// Initializes a new instance of the <see cref="T:AssemblyCSharp.Line"/> class.
		/// </summary>
		/// <param name="pkt1">Pkt1.</param>
		/// <param name="pkt2">Pkt2.</param>
		public Line(Vector2 pkt1, Vector2 pkt2)
		{
			// We have to have the right order for the
			// pkt in order to use intersect method.
			if (pkt1.x < pkt2.x)
			{
				this.x1 = pkt1.x;
				this.y1 = pkt1.y;
				this.x2 = pkt2.x;
				this.y2 = pkt2.y;
			}
			else
			{ 
				this.x2 = pkt1.x;
				this.y2 = pkt1.y;
				this.x1 = pkt2.x;
				this.y1 = pkt2.y;
			}

			// Calculating lines.
			this.a = (y2 - y1);
			this.b = (x1 - x2);
			this.c = a * x1 + b * y1;

			this.s = (y2 / y1) / (x2 - x1);
			this.m = (s * x1) + y1;
		}

		/// <summary>
		/// Gets the y using the formula f( x ) = s*x+m
		/// </summary>
		/// <returns>The y.</returns>
		/// <param name="x">The x coordinate.</param>
		public float f(float x)
		{
			return (s * x) + m;
		}

		/// <summary>
		/// Returns S in the formula f( x ) = s*x+m
		/// </summary>
		public float S()
		{
			return s;
		}

		/// <summary>
		/// Returns m in the formula f( x ) = s*x+m
		/// </summary>
		public float M()
		{
			return m;
		}

		public Vector2 Intersect(Line o)
		{
			float delta = a * o.b - o.a * b;

			if (delta == 0)
			{
				return Vector2.zero;
			}

			// Calculating the X and Y values:
			float x = (o.b * c - b * o.c) / delta;
			float y = (a * o.c - o.a * c) / delta;

			// Testing if the point is inside a piece of line:
			if (!( Mathf.Min(x1, x2) + MINIMIUM_TRESHOLD < x && x < Mathf.Max(x1, x2) - MINIMIUM_TRESHOLD))
					return Vector2.zero;

			// Testing if the point is inside a piece of the other line:
			if (!(Mathf.Min(o.x1, o.x2) + MINIMIUM_TRESHOLD < x && x < Mathf.Max(o.x1, o.x2) - MINIMIUM_TRESHOLD ))
				return Vector2.zero;

			// Testing if the point is inside a piece of line:
			if (!(Mathf.Min(y1, y2) + MINIMIUM_TRESHOLD < y && y < Mathf.Max(y1, y2) - MINIMIUM_TRESHOLD))
				return Vector2.zero;

			// Testing if the point is inside a piece of the other line:
			if (!(Mathf.Min(o.y1, o.y2) + MINIMIUM_TRESHOLD < y && y < Mathf.Max(o.y1, o.y2) - MINIMIUM_TRESHOLD))
				return Vector2.zero;

			// Testing if the intersection is too close to the two edges.

			
			return new Vector2(x, y);	
		}

		/// <summary>
		/// Findes an intersection between to lines if possible.
		/// </summary>
		/// <param name="other">Other.</param>
		//public Vector2 Intersect(Line other)
		//{
		//	double lhs = s - other.S();
		//	double rhs = other.M() - m;

		//	// Checking if a intersection can be calculated:
		//	if (lhs == 0)
		//	{
		//		return Vector2.zero;
		//	}


		//	// Calculating exact intersection for X axis:
		//	float x = (float)(rhs / lhs);

		//	// Testing if the point is inside a piece of line:
		//	if (x < Mathf.Min(x1, x2) || Mathf.Max(x1, x2) < x)
		//		return Vector2.zero;

		//	// Testing if the point is inside a piece of the other line:
		//	if (x < Mathf.Min(other.x1, other.x2) || Mathf.Max(other.x1, other.x2) < x)
		//		return Vector2.zero;


		//	float y = f(x);

		//	// Testing if the point is inside a piece of line:
		//	if (  y < Mathf.Min(y1, y2) || Mathf.Max(y1, y2) < y )
		//		return Vector2.zero;

		//	// Testing if the point is inside a piece of the other line:
		//	if (y < Mathf.Min(other.y1, other.y2) || Mathf.Max(other.y1, other.y2) < y)
		//		return Vector2.zero;

		//	// There was an intersection:
		//	return new Vector2(x, y);
		//}

		/// <summary>
		/// if the intersect method does not return Vector2.zero, the lines are intersecting.
		/// </summary>
		/// <returns><c>true</c>, if intersecting, <c>false</c> otherwise.</returns>
		/// <param name="other">Other.</param>
		public bool isIntersecting(Line other)
		{
			return ! Intersect(other).Equals(Vector2.zero);
		}


		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AssemblyCSharp.Line"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AssemblyCSharp.Line"/>.</returns>
		public override string ToString()
		{
			return s+"x+"+m+" = (" + x1 + "," + y1 + ") , (" + x2 + "," + y2 + ")";
		}

		/// <summary>
		/// Prints the line geo gebra styles. IN NORWEGIAN.
		/// </summary>
		/// <returns>The geo gebra format.</returns>
		public string ToGeoGebra()
		{
			return "Linjestykke[(" + x1 + "," + y1 + ") , (" + x2 + "," + y2 + ")]";
		}
	}
}
