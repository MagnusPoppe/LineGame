using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Line
	{
		float s; // Stigning
		float m; // m i sx+m

		float x1, y1, x2, y2;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:AssemblyCSharp.Line"/> class.
		/// </summary>
		/// <param name="pkt1">Pkt1.</param>
		/// <param name="pkt2">Pkt2.</param>
		public Line(Vector2 pkt1, Vector2 pkt2)
		{
			this.x1 = pkt1.x;
			this.y1 = pkt1.y;
			this.x2 = pkt2.x;
			this.y2 = pkt2.y;

			this.s = (y2 - y1) / (x2 - x1);
			this.m = (s * x1) + y1;
		}

		/// <summary>
		/// Gets the y using the formula f( x ) = s*x+m
		/// </summary>
		/// <returns>The y.</returns>
		/// <param name="x">The x coordinate.</param>
		public float GetY(float x)
		{
			return (s * x) + m;
		}

		/// <summary>
		/// S this instance.
		/// </summary>
		public float S()
		{
			return s;
		}

		/// <summary>
		/// M this instance.
		/// </summary>
		public float M()
		{
			return m;
		}

		/// <summary>
		/// Findes where the intersection between to lines are.
		/// </summary>
		/// <param name="other">Other.</param>
		public Vector2 Intersect(Line other)
		{
			
			double lhs = s - other.S();
			double rhs = other.M() - m;
			if (lhs == 0)
				return Vector2.zero;
			
			float x = (float)(rhs / lhs);
			return new Vector2(x, GetY(x));
		}
		                             
		public bool hasIntersection( Line other )
		{
			Vector2 isect = Intersect(other);
			if (isect != Vector2.zero)
			{
				if ((x1 <= isect.x && isect.x <= x2) && (y1 <= isect.y && isect.y <= y2))
				{
					return true;
				}
			}
			return false;
		}

		public override string ToString()
		{
			return s+"x+"+m+"=(" + x1 + "," + y1 + "),(" + x2 + "," + y2 + ")";
		}
	}
}
