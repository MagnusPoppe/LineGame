using System;
using UnityEngine;
using Game.Generator;
using Game.Levels;

namespace Game
{
	public class Graphics
	{

        // Layers:
        public const int LAYER_BACKGROUND = 8;
		public const int LAYER_LINE = 9;
		public const int LAYER_CIRCLE = 10;
		public const float CIRCLE_RADIUS = 5.0f;

		Sprite darkCircle;
		Sprite lightCirlce;

		Material lineMaterial;

		ColorSchema colors;

		public Graphics(Sprite lightcircle, Sprite darkCircle, Material line, ColorSchema colors)
		{
			this.lightCirlce = lightcircle;
			this.darkCircle = darkCircle;
			this.lineMaterial = line;
			this.colors = colors;
		}

		public Pkt[] CreateLevel(Level level, string seed)
		{
			// Creating pkts to place circles:
			seed += (char)UnityEngine.Random.Range(0, 128);
			Vector2[] positions = GameManager.GeneratePoints(seed, level.Pkts);

			Pkt[] circles = AddCircles(positions);

			foreach (Connection c in level.Lines)
				AddLine(circles[c.From], circles[c.To]);

			return circles;
		}

		/// <summary>
		/// Draws the circles at spesified positions one the board.
		/// The points are specified by the "points" array.
		/// </summary>
		/// <param name="points">Points in the plane.</param>
		public Pkt[] AddCircles(Vector2[] points)
		{
			Pkt[] circles = new Pkt[points.Length];

			for (int i = 0; i < points.Length; i++)
				circles[i] = AddCircle(i, points[i]);

			for (int i = 1; i <= points.Length; i++)
			{
				if (i == points.Length)
					AddLine(circles[i - 1], circles[0]);
				else 
					AddLine(circles[i - 1], circles[i]);
			}

			return circles;
		}

		/// <summary>
		/// Configures a circle perfectly.
		/// </summary>
		/// <returns>The circle.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="position">Pkt.</param>
		private Pkt AddCircle(int id, Vector2 position)
		{
			GameObject circle = new GameObject();
			circle.transform.position = position;
			circle.name = "Circle" + id;
			circle.tag = "Circle";
			circle.layer = LAYER_CIRCLE;

			SpriteRenderer sprite = circle.AddComponent<SpriteRenderer>();
			sprite.sortingLayerName = "Circle";

			sprite.sprite = darkCircle;

			return new Pkt(circle, id);
		}

		/// <summary>
		/// Adds a line.
		/// </summary>
		/// <param name="pkt1">Point that the line is attached to.</param>
		/// <param name="pkt2">Other point that the line is attached to.</param>
		public void AddLine(Pkt pkt1, Pkt pkt2)
		{
			// DRAWING LINES USING LINE RENDERER:
			GameObject line = new GameObject();
			line.name = pkt1.ID + ";" + pkt2.ID;
			line.tag = "Line";
			line.layer = LAYER_LINE;

			// ADDING/CONFIGURING THE RENDERER COMPONENT
			LineRenderer renderer = line.AddComponent<LineRenderer>();
			renderer.useWorldSpace = true;
			renderer.sortingLayerName = "Line";
			renderer.material = lineMaterial;

			renderer.startColor = colors.LineClear;
			renderer.endColor = colors.LineClear;

			Vector3[] pos = { pkt1.Position, pkt2.Position };
			line.transform.parent = pkt1.Circle.transform;
			renderer.SetPositions(pos);

			pkt1.AddLine(line);
			pkt2.AddLine(line);
		}
	}
}
