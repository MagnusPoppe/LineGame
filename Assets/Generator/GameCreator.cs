using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace Generator 
{
    public class GameCreator : MonoBehaviour 
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
            // Place random points in grid.
            Vector2[] points = GeneratePoints(seed);

            GraphicsCreator graphics = new GraphicsCreator(circle, background, lineMaterial);
            // Draw nessesary objects:
            BG = graphics.DrawBackground(width, height);
            circles = graphics.DrawCircles(points);
            lines = graphics.DrawLines(circles);
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


