using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

namespace Game.Generator 
{
    public class GameManager
	{
        // Map variables:
        const int width = 72;
        const int height = 128;
		string seed = "Angelica";
		int circleCount;

		// Graphical elements
        Sprite lightCircle;
        Sprite darkCircle;
        Material lineMaterial;
		Text Level_Text;
        GameObject board;

		// OTHER:
		Graphics graphics;
		private Pkt[] circles;

		public Pkt[] Circles
		{
			get
			{
				return circles;
			}
		}

		public GameManager(Text level, Sprite darkCircle, Sprite lightCircle, Material lineMaterial, ColorSchema colors)
		{
			Level_Text = level;
			this.darkCircle = darkCircle;
			this.lightCircle = lightCircle;
			this.lineMaterial = lineMaterial;

			circleCount = 10;
			graphics = new Graphics(lightCircle, darkCircle, lineMaterial, colors);
		}

		/// <summary>
		/// Nexts the level.
		/// </summary>
		/// <param name="level">Level.</param>
		public void NextLevel(int level)
		{
			// TODO: ClearBoard();

			Level_Text.text = level + "";

			seed += (char)UnityEngine.Random.Range(0 , 128);
			Vector2[] points = GeneratePoints(seed);

			// Draw nessesary objects:
			circles = graphics.AddCircles(points);
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


