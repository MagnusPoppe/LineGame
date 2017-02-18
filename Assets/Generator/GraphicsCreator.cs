using System;
using UnityEngine;

namespace Generator
{
    public class GraphicsCreator
    {

        // Layers:
        const int LAYER_BACKGROUND = 8;
        const int LAYER_LINE = 9;
        const int LAYER_CIRCLE = 10;
		public const float CIRCLE_RADIUS = 5.0f;

        Sprite circle;
        Sprite background;
        Material lineMaterial;

        public GraphicsCreator(Sprite c, Sprite bg, Material line)
        {
            this.circle = c;
            this.background = bg;
            this.lineMaterial = line;
        }

        /// <summary>
        /// Draws the background gameobject.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public GameObject DrawBackground( int width, int height )
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

        /// <summary>
        /// Draws the circles at spesified positions one the board.
        /// The points are specified by the "points" array.
        /// </summary>
        /// <param name="points">Points in the plane.</param>
        public GameObject[] DrawCircles( Vector2[] points )
        {
            GameObject[] circles = new GameObject[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                circles[i] = new GameObject();
                circles[i].transform.position = points[i];
                circles[i].name = "Circle" + i;
                circles[i].tag = "Circle";
                circles[i].layer = LAYER_CIRCLE;
                CircleCollider2D collider = circles[i].AddComponent<CircleCollider2D>();
				collider.radius = CIRCLE_RADIUS;


                Controller controller = circles[i].AddComponent<Controller>();
				controller.enabled = false;

                SpriteRenderer sprite = circles[i].AddComponent<SpriteRenderer>();
                sprite.sortingLayerName = "Circle";
                sprite.sprite = circle;
            }
            return circles;
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
                // GETTING POSITIONS:
                Vector3[] pos = new Vector3[2];
                pos[1] = new Vector3(
                    c[i-1].transform.position.x, 
                    c[i-1].transform.position.y
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
                lines[i-1] = new GameObject();
                lines[i-1].transform.parent = c[i-1].transform;
                lines[i-1].name = "Line ("+(i-1)+"->"+i+")";
                lines[i-1].tag = "Line";
                lines[i-1].layer = LAYER_LINE;


                // ADDING/CONFIGURING THE RENDERER COMPONENT
                LineRenderer l = lines[i-1].AddComponent<LineRenderer>();
				l.useWorldSpace = true;
                l.SetPositions(pos);
                l.sortingLayerName = "Line";
                l.material = lineMaterial;
                l.startColor = Color.green;
                l.endColor = Color.green;
				l.useWorldSpace = true;

                BoxCollider2D collider = lines[i-1].AddComponent<BoxCollider2D>();
                collider.transform.position = GetLineCenter(pos[0], pos[1]);

            }
            return lines;
        }
        Vector2 GetLineCenter(Vector3 from, Vector3 to)
        {
            return new Vector2(
                (to.x - from.x),
                (to.y - from.y)
            );
        }
    }
}

