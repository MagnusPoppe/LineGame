using NUnit.Framework;
using System;
using UnityEngine;

namespace Game
{
	[TestFixture()]
	public class LineTests
	{

		[Test()] public void LineFromToPkts()
		{
			// EXPECTED LINE IS: g(x) = -3x+4. 
			// This line goes through the pkts (0,4) and (1,1).

			Line line = new Line(new Vector2(0f, 4f), new Vector2(1f, 1f));

			Assert.AreEqual(-3f, line.S(), "Test for S.");
			Assert.AreEqual(4f,  line.M(), "Test for M.");

			// EXPECTED LINE IS: f(x) = 2x+1. 
			// This line goes through the pkts (0,1) and (1,3).
			line = new Line(new Vector2(0f, 1f), new Vector2(1f, 3f));

			Assert.AreEqual(2f, line.S(), "Test for S.");
			Assert.AreEqual(1f, line.M(), "Test for M.");
		}

		[Test()] public void Intersection()
		{
			Line fx = new Line(new Vector2(0f, 1f), new Vector2(1f, 3f));
			Line gx = new Line(new Vector2(0f, 4f), new Vector2(1f, 1f));
			Line hx = new Line(new Vector2(0f, 0f), new Vector2(1f, 1f));
			Line ix = new Line(new Vector2(-1f, 0f), new Vector2(0f, 1f));

			Vector2 expected = new Vector2(0.6f, 2.2f);
			Assert.AreEqual(expected, fx.Intersect(gx), "Test for f(x) intersect with g(x)");
			expected = Vector2.zero;
			Assert.AreEqual(expected, ix.Intersect(hx), "Test for f(x) intersect with h(x)");

			Console.WriteLine(ix.Intersect(hx));
		}

		[Test()] public void SpesificIntersection()
		{
			Line fx = new Line(new Vector2(0.0f, 6.0f), new Vector2(4.0f, -6.0f));
			Line gx = new Line(new Vector2(0.0f, -6.0f), new Vector2(4.0f, 6.0f));

			Vector2 actual = fx.Intersect(gx);

			if (actual.Equals(Vector2.zero))
				Assert.Fail("The method could not calculate an intersection. It returned Vector2.zero.");

			float expectedX = 2; float expectedY = 0;
			Assert.AreEqual(expectedX, actual.x, "Testing x axis");
			Assert.AreEqual(expectedY, actual.y, "Testing y axis");


			// TRYING THE SAME TEST WITH AN INVERTED F(X). The intersection should be the same.  
			fx = new Line(new Vector2(4.0f, -6.0f), new Vector2(0.0f, 6.0f));

			actual = fx.Intersect(gx);

			if (actual.Equals(Vector2.zero))
				Assert.Fail("The method could not calculate an intersection. It returned Vector2.zero.");

			Assert.AreEqual(expectedX, actual.x, "Testing x axis");
			Assert.AreEqual(expectedY, actual.y, "Testing y axis");

			// Trying one last test that should fail because of intersection bigger than
			// both x axis values of both lines.
			gx = new Line(new Vector2(0.0f, -6.0f), new Vector2(-2, -12));

			actual = gx.Intersect(fx);

			if (! actual.Equals(Vector2.zero) )
				Assert.Fail("The test should have recieved an Vector2.zero.");
		}

		[Test()] public void KnownErrorIntersection()
		{
			Line fx = new Line(new Vector2(8.7f, 32.6f),  new Vector2(32.4f, 83f) );
			Line gx = new Line(new Vector2(57.2f, 72.9f), new Vector2(5f, 73f));

			Vector2 fxIntersect = fx.Intersect(gx);
			Vector2 gxIntersect = gx.Intersect(fx);

			Assert.AreEqual(fxIntersect, gxIntersect, "Testing as vector 2");
			Assert.AreEqual(fxIntersect.x, gxIntersect.x, "Testing as coordinate x");
			Assert.AreEqual(fxIntersect.y, gxIntersect.y, "Testing as coordinate y");

			Vector2 expected = new Vector2(27.68f, 72.96f);

			Assert.AreEqual(expected, fxIntersect);
			Assert.AreEqual(expected, gxIntersect);
		}
	}
}
