using System;
using UnityEngine;

namespace Game.Generator
{
    public class GraphicsCreator
    {

        // Layers:
        public const int LAYER_BACKGROUND = 8;
        public const int LAYER_LINE = 9;
        public const int LAYER_CIRCLE = 10;
		public const float CIRCLE_RADIUS = 5.0f;

		Sprite circleSprite;
        Sprite background;
        Material lineMaterial;

		public GraphicsCreator(Sprite circle, Material line)
		{
			lineMaterial = line;
			circleSprite = circle;
		}

        public GraphicsCreator(Sprite c, Sprite bg, Material line)
        {
            this.circleSprite = c;
            this.background = bg;
            this.lineMaterial = line;
        }

     

        /// <summary>
        /// Draws the circles at spesified positions one the board.
        /// The points are specified by the "points" array.
        /// </summary>
        /// <param name="points">Points in the plane.</param>
        public GameObject[] AddCircles( Vector2[] points )
        {
            GameObject[] circles = new GameObject[points.Length];

			for (int i = 0; i < points.Length; i++)
				circles[i] = AddCircle(i, points[i]);
            
            return circles;
        }

		/// <summary>
		/// Configures a circle perfectly.
		/// </summary>
		/// <returns>The circle.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="pkt">Pkt.</param>
		private GameObject AddCircle(int id, Vector2 pkt)
		{ 
			GameObject circle = new GameObject();
			circle.transform.position = pkt;
			circle.name = "Circle" + id;
			circle.tag = "Circle";
			circle.layer = LAYER_CIRCLE;

			SpriteRenderer sprite = circle.AddComponent<SpriteRenderer>();
			sprite.sortingLayerName = "Circle";
			sprite.sprite = circleSprite;

			return circle;
		}

		/// <summary>
		/// Draws the spesific line.
		/// </summary>
		/// <returns>The spesific line.</returns>
		/// <param name="from">From. Index of the circle that the line starts at.</param>
		/// <param name="to">To. Index of the circle that the line stops at.</param>
		public GameObject DrawSpesificLine(int from, int to)
		{
			GameObject fromCircle = GameObject.Find("Circle" + from);
			GameObject toCircle = GameObject.Find("Circle" + to);

			return DrawSpesificLine(from, to, fromCircle, toCircle);
		}

        /// <summary>
        /// Draws the lines. The lines are positioned between to nodes.
        /// The index of the line is ordered like this:
        /// Line(1) goes from a circle(1) to cirlce(2). This applies
        /// every time except when the index of the line is the end
        /// of the array. Then it points to circle(0).
        /// </summary>
        public GameObject[] DrawLines( GameObject[] c)
        {
            GameObject[] lines = new GameObject[c.Length];

            for (int i = 1; i <= c.Length; i++ )
            {
                if (i == c.Length) 
					DrawSpesificLine(i - 1, 0, c[i - 1], c[0]);
                else 
					DrawSpesificLine(i - 1, i, c[i - 1], c[i]);
            }
            return lines;
        }

		/// <summary>
		/// Draws and configures the spesific line.
		/// The index of the line is ordered like this:
		/// Line(1) goes from a circle(1) to cirlce(2). This applies
		/// every time.
		/// </summary>
		/// <returns>The spesific line.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="fromCircle">From circle.</param>
		/// <param name="toCircle">To circle.</param>
		private GameObject DrawSpesificLine(int from, int to, GameObject fromCircle, GameObject toCircle)
		{
			// DRAWING LINES USING LINE RENDERER:
			GameObject line = new GameObject();
			line.transform.parent = fromCircle.transform;
			line.name = "Line (" + from + "->" + to + ")";
			line.tag = "Line";
			line.layer = LAYER_LINE;

			Vector3[] pos = {
				new Vector3(fromCircle.transform.position.x, fromCircle.transform.position.y, 0),
				new Vector3(toCircle.transform.position.x, toCircle.transform.position.y, 0),
			};

			// ADDING/CONFIGURING THE RENDERER COMPONENT
			LineRenderer l = line.AddComponent<LineRenderer>();
			l.useWorldSpace = true;
			l.SetPositions(pos);
			l.sortingLayerName = "Line";
			l.material = lineMaterial;
			l.startColor = Color.green;
			l.endColor = Color.green;

			return line;
		}


		/// <summary>
		/// Draws the lines. The lines are positioned between to nodes.
		/// The index of the line is ordered like this:
		/// Line(1) goes from a circle(1) to cirlce(2). This applies
		/// every time except when the index of the line is the end
		/// of the array. Then it points to circle(0).
		/// </summary>
		public GameObject[] AddLines(GameObject[] c)
		{
			GameObject[] lines = new GameObject[c.Length];
			for (int i = 1; i <= c.Length; i++)
			{
				// GETTING POSITIONS:
				Vector3[] pos = new Vector3[2];
				pos[1] = new Vector3(
					c[i - 1].transform.position.x,
					c[i - 1].transform.position.y
				);

				if (i == c.Length) pos[0] = new Vector3(
					c[0].transform.position.x,
					c[0].transform.position.y
				);
				else pos[0] = new Vector3(
					c[i].transform.position.x,
					c[i].transform.position.y
				);

				// DRAWING LINES USING LINE RENDERER:
				lines[i - 1] = new GameObject();
				lines[i - 1].transform.parent = c[i - 1].transform;
				lines[i - 1].name = "Line (" + (i - 1) + "->" + i + ")";
				lines[i - 1].tag = "Line";
				lines[i - 1].layer = LAYER_LINE;


				// ADDING/CONFIGURING THE RENDERER COMPONENT
				LineRenderer l = lines[i - 1].AddComponent<LineRenderer>();
				l.useWorldSpace = true;
				l.SetPositions(pos);
				l.sortingLayerName = "Line";
				l.material = lineMaterial;
				l.startColor = Color.green;
				l.endColor = Color.green;
			}
			return lines;
		}

		/// <summary>
		/// Finds the center of the line.
		/// </summary>
		/// <returns>The line center.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
        Vector2 GetLineCenter(Vector3 from, Vector3 to)
        {
            return new Vector2(
                (to.x - from.x),
                (to.y - from.y)
            );
        }

		/// <summary>
		/// Draws the background gameobject. DEPRECIATED.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public GameObject DrawBackground(int width, int height)
		{
			GameObject bg = new GameObject();
			bg.transform.position = new Vector2(width / 2, height / 2);
			bg.name = "Background";
			bg.tag = "Background";
			bg.layer = LAYER_BACKGROUND;
			SpriteRenderer sr = bg.AddComponent<SpriteRenderer>();
			sr.sortingLayerName = "Background";
			sr.sprite = background;

			return bg;
		}
	}
}

