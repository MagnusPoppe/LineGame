using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

using Game.Levels;

namespace Game.Generator 
{
    public class GameManager
	{
        // Map variables:
        const int width = 72;
        const int height = 128;
		string seed = "Angelica";

		// Graphical elements
        public Sprite lightCircle;
        Sprite darkCircle;
        Material lineMaterial;
		Text Level_Text;
        GameObject board;

		// OTHER:
		Graphics graphics;
		private Pkt[] circles;
		LevelManager level;
        public bool LoadingLevel;

		public Pkt[] Circles
		{
			get
			{
				return circles;
			}
		}

		public GameManager(Text Txtlevel, Sprite darkCircle, Sprite lightCircle, Material lineMaterial, ColorSchema colors)
		{
			Level_Text = Txtlevel;
			this.darkCircle = darkCircle;
			this.lightCircle = lightCircle;
			this.lineMaterial = lineMaterial;

			// LEVEL STUFF:
			level = new LevelManager();
			graphics = new Graphics(lightCircle, darkCircle, lineMaterial, colors);
		}

		/// <summary>
		/// Nexts the level.
		/// </summary>
		/// <param name="level">Level.</param>
        public void NextLevel(Vector2 startPosition)
		{
			// Manages level text

			level.LevelUP();

			Level_Text.text = level.No + "";

			// Prepares the board to recieve new objects.
			ClearBoard();
			seed += (char)UnityEngine.Random.Range(0, 128);
            circles = graphics.CreateLevel(level, seed, startPosition);
            LoadingLevel = true; 
		}

	    public float LevelTimeLimit()
	    {
	        return (float)level.TimeLimit;
	    }

		void ClearBoard()
		{
			if (circles != null)
				for (int i = 0; i < circles.Length; i++)
					circles[i].DestoryAll();	
		}

		/// <summary>
        /// Generates the points to place circles at random using
        /// a given seed.
        /// </summary>
        /// <returns>The points.</returns>
        public static Vector2[] GeneratePoints( string seed, int pktCount )
        {
            System.Random prng = new System.Random(seed.GetHashCode());
            Vector2[] points = new Vector2[pktCount];
            for (int i = 0; i < pktCount; i++)
            {
                points[i] = new Vector2( prng.Next(0, width), prng.Next(0, height));
            }
            return points;
        }
    }    
}


