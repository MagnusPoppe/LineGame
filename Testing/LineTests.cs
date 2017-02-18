using NUnit.Framework;
using System;
using UnityEngine;
using AssemblyCSharp;

namespace Game
{
	[TestFixture()]
	public class LineTests
	{

		[Test()] public void LineFromToPkts()
		{
			// EXPECTED LINE IS: g(x) = -3x+4. 
			// This line goes through the pkts (0,4) and (1,1).

			Vector2 gxPKT1 = new Vector2(0f, 4f); 
			Vector2 gxPKT2 = new Vector2(1f, 1f); 
			Line line = new Line(gxPKT1, gxPKT2);

			Assert.AreEqual(-3f, line.S(), "Test for S.");
			Assert.AreEqual(4f,  line.M(), "Test for M.");

			// EXPECTED LINE IS: f(x) = 2x+1. 
			// This line goes through the pkts (0,1) and (1,3).

			Vector2 fxPKT1 = new Vector2(0f, 1f);
			Vector2 fxPKT2 = new Vector2(1f, 3f);
			line = new Line(fxPKT1, fxPKT2);

			Assert.AreEqual(2f, line.S(), "Test for S.");
			Assert.AreEqual(1f, line.M(), "Test for M.");
		}

		[Test()] public void Intersection()
		{
			Vector2 fxPKT1 = new Vector2(0f, 1f);
			Vector2 fxPKT2 = new Vector2(1f, 3f);
			Line fx = new Line(fxPKT1, fxPKT2);

			Vector2 gxPKT1 = new Vector2(0f, 4f);
			Vector2 gxPKT2 = new Vector2(1f, 1f);
			Line gx = new Line(gxPKT1, gxPKT2);

			Vector2 hxPKT1 = new Vector2(0f, 0f);
			Vector2 hxPKT2 = new Vector2(1f, 1f);
			Line hx = new Line(hxPKT1, hxPKT2);

			Vector2 ixPKT1 = new Vector2(-1f, 0f);
			Vector2 ixPKT2 = new Vector2(0f, 1f);
			Line ix = new Line(hxPKT1, hxPKT2);

			Vector2 expected = new Vector2(0.6f, 2.2f);
			Assert.AreEqual(expected, fx.Intersect(gx), "Test for f(x) intersect with g(x)");
			expected = Vector2.zero;
			Assert.AreEqual(expected, ix.Intersect(hx), "Test for f(x) intersect with h(x)");

			Console.WriteLine(ix.Intersect(hx));
		}
	}
}
