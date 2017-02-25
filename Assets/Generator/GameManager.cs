using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

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

		public Text Level_Text;

        GameObject board;
        public GameObject[] circles;
        public GameObject[] lines;

        // Use this for initialization
        void Start () 
        {
			
        }

		public void NextLevel(int level)
		{
			ClearBoard();

			Level_Text.text = level + "";

			// Place random points in grid.
			circleCount += 1;

			seed += (char)UnityEngine.Random.Range(0 , 128);
			Vector2[] points = GeneratePoints(seed);

			GraphicsCreator graphics = new GraphicsCreator(circle, lineMaterial);

			// Draw nessesary objects:
			circles = graphics.AddCircles(points);
			lines = graphics.AddLines(circles);

			graphics.DrawSpesificLine(0, circleCount - 1);// TODO: Virker ikke.
		}

		private void ClearBoard()
		{
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
		}

		public void SetColorSchema(ColorSchema cs)
		{
			foreach (GameObject obj in circles)
			{
				SpriteRenderer r = obj.GetComponent<SpriteRenderer>();
				r.color = cs.Circle;
			}
			foreach (GameObject obj in lines)
			{
				SpriteRenderer r = obj.GetComponent<SpriteRenderer>();
				r.color = cs.LineClear;
			}
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


