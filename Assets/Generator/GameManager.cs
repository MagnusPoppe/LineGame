using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace Game.Generator 
{
    public class GameManager : MonoBehaviour 
	{
        // Map variables:
        public int width = 72;
        public int height = 128;

        // Game variables:
        public string seed = "Angelica";
        public int circleCount = 10;

        public Sprite circle;
        public Sprite background;
        public Material lineMaterial;

        GameObject board;
        GameObject BG;
        public GameObject[] circles;
        public GameObject[] lines;

        // Use this for initialization
        void Start () 
        {
			
        }

		public void NextLevel(int level)
		{
			if (BG != null) 
			{
				Destroy(BG);
			}
			if (circles != null)
			{
				for (int i = 0; i < circles.Length; i++)
				{
					Destroy(lines[i]);
				}
				for (int i = 0; i < circles.Length; i++)
				{
					Destroy(circles[i]);
				}
			}
			// Place random points in grid.
			circleCount += 1;
			Vector2[] points = GeneratePoints(seed);

			GraphicsCreator graphics = new GraphicsCreator(circle, background, lineMaterial);

			// Draw nessesary objects:
			BG = graphics.DrawBackground(width, height);
			circles = graphics.AddCircles(points);
			lines = graphics.AddLines(circles);
		}

  

		/// <summary>
        /// Generates the points to place circles at random using
        /// a given seed.
        /// </summary>
        /// <returns>The points.</returns>
        Vector2[] GeneratePoints( string seed )
        {
            System.Random prng = new System.Random(seed.GetHashCode());
            Vector2[] points = new Vector2[circleCount];
            for (int i = 0; i < circleCount; i++)
            {
                points[i] = new Vector2( prng.Next(0, width), prng.Next(0, height));
            }
            return points;
        }
    }    
}


