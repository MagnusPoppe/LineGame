using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Generator;
using UnityEngine.UI;

namespace Game
{
	public class ClickManager : MonoBehaviour
	{
		// DEFINITION FOR COLOR SCHEMAS:
		const ColorSchema.Schemas PRE_DEFINED_SCHEMA = ColorSchema.Schemas.DARK_GREEN;
		public bool colorcodeLines = true;
		public ColorSchema colorSchema;

		// Variables to play the game.
		private bool heldWithMouse;
		private bool levelIsWon;
		private GameManager game;
		private GameObject graphics;
		private Camera mainCamera;
		private Pkt held;

		[Range(0, 15)] 
		public int level = 1;
		public bool canWin = false;

		// Sprites: 
		public Sprite lightCircle;
		public Sprite darkCircle;
		public Material lineMaterial;

		public Text Level_Number_Text;
		public Text Level_Text_Text;

		// Use this for initialization
		void Start()
		{
			mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

			// Setting the colors
			colorSchema = new ColorSchema(PRE_DEFINED_SCHEMA, colorcodeLines);
			Level_Number_Text.color = colorSchema.Font;
			Level_Text_Text.color = colorSchema.Font;
			mainCamera.backgroundColor = colorSchema.Background;


			// Setting up the game:
			level = 0;
			game = new GameManager(Level_Number_Text, darkCircle, lightCircle, lineMaterial, colorSchema);

			game.NextLevel();
			FindIntersections();
			heldWithMouse = false;
			levelIsWon = false;
		}

		// Update is called once per frame
		void Update()
		{
			if (levelIsWon)
			{
				Debug.Log("You beat level "+level+"!");

				ClearLevel();
				game.NextLevel();
			}

			if (Input.GetMouseButtonDown(0))
			{
				Pkt g = IdentifyClickedItem();

				if (g != null) // BRUKER TRYKKER NED KNAPP PÅ ET OBJEKT
				{
					g.Position = GetMouseWorld2DPosition();
					heldWithMouse = true;
					held = g;
				}
			}
			else if (Input.GetMouseButtonUp(0)) // SIRKEL BLE SLUPPET
			{
				heldWithMouse = false;
				held = null;
			}

			if (heldWithMouse) // HVA SKJER NÅR MAN HOLDER ET OBJEKT?
			{
				if (held != null)
				{
					held.Position = GetMouseWorld2DPosition();
					FindIntersections();
				}
				else
				{
					heldWithMouse = false;
				}
			}
		}

		/// <summary>
		/// Clears the level.
		/// </summary>
		private void ClearLevel()
		{
			heldWithMouse = false;
			levelIsWon = false;
			held = null;
		}

		private GameObject[] FindAllLines()
		{
			List<GameObject> lines = new List<GameObject>();
			for (int i = 0; i < game.Circles.Length; i++)
			{
				GameObject[] current = game.Circles[i].AttachedLines;
				for (int j = 0; j < current.Length; j++)
				{
					if (!lines.Contains(current[j]))
						lines.Add(current[j]);
				}
			}
			return lines.ToArray();
		}

		/// <summary>
		/// Tests for intersections between all lines.
		/// </summary>
		private void FindIntersections()
		{
			GameObject[] all = FindAllLines();
			Line[] line = new Line[all.Length];

			for (int i = 0; i < all.Length; i++)
			{
				LineRenderer lr = all[i].GetComponent<LineRenderer>();
				line[i] = new Line(lr.GetPosition(0), lr.GetPosition(1));
			}

			int intersectCounter = 0;

			for (int i = 0; i < line.Length; i++)
			{
				bool intersecting = false;

				for (int j = 0; j < line.Length; j++)
				{
					if (i == j) continue; // Same lines.

					if (line[i].isIntersecting(line[j]))
					{

						// FOUND INTERSECTION:
						ColorLine(all[i].GetComponent<LineRenderer>(), colorSchema.LineCrossing);
						ColorLine(all[j].GetComponent<LineRenderer>(), colorSchema.LineCrossing);
						intersecting = true;
						intersectCounter++;
					}
				}
				if (!intersecting)
				{
					ColorLine(all[i].GetComponent<LineRenderer>(), colorSchema.LineClear);
				}
			}

			if (canWin)
				if (intersectCounter == 0) 
					levelIsWon = true;
		}

		/// <summary>
		/// Colors the line.
		/// </summary>
		/// <param name="line">Line.</param>
		/// <param name="color">Color.</param>
		private void ColorLine(LineRenderer line, Color color)
		{
			line.startColor = color;
			line.endColor = color;
		}

		/// <summary>
		/// Gets the mouse world 2D Position.
		/// </summary>
		/// <returns>The mouse world2 DP osition.</returns>
		private Vector2 GetMouseWorld2DPosition()
		{
			float mousex = Input.mousePosition.x;
			float mousey = Input.mousePosition.y;
			Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0.0f));
			return new Vector2(v3.x, v3.y);
		}

		/// <summary>
		/// Identifies the clicked item.
		/// </summary>
		/// <returns>The clicked item.</returns>
		private Pkt IdentifyClickedItem()
		{
			Vector2 v2 = GetMouseWorld2DPosition();
			Pkt[] c = game.Circles;

			foreach (Pkt pkt in c)
				if (clicked(pkt.Circle.transform.position, v2))
					return pkt;

			return null;
		}

		/// <summary>
		/// Clicked the specified go and mouse.
		/// </summary>
		/// <param name="go">Go.</param>
		/// <param name="mouse">Mouse.</param>
		private bool clicked(Vector2 go, Vector2 mouse)
		{
			return Vector2.Distance(go, mouse) < GraphicsCreator.CIRCLE_RADIUS;
		}
	}
}