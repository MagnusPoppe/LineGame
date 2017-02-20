using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Generator;

namespace Game
{
	public class ClickManager : MonoBehaviour
	{

		private bool heldWithMouse;
		private bool levelIsWon;

		private GameManager game;
		private GameObject graphics;

		private GameObject held;
		private GameObject[] childLines;

		[Range(0, 15)] 
		public int level = 1;

		public bool canWin = false;

		// Use this for initialization
		void Start()
		{
			GameObject GameManager = GameObject.Find("GameManager");
			game = GameManager.GetComponent<GameManager>();

			level = 0;

			game.NextLevel(level);
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

				game.NextLevel(++level);

				levelIsWon = false;
			}

			if (Input.GetMouseButtonDown(0))
			{
				GameObject g = IdentifyClickedItem();

				if (g != null) // BRUKER TRYKKER NED KNAPP PÅ ET OBJEKT
				{
					g.transform.position = GetMouseWorld2DPosition();
					heldWithMouse = true;
					childLines = FindChildrenLines(g);
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
					correctLinePositions(GetMouseWorld2DPosition(), held.transform.position);
					held.transform.position = GetMouseWorld2DPosition();
					FindIntersections();
				}
				else
				{
					heldWithMouse = false;
				}
			}
		}

		/// <summary>
		/// Finds the children lines.
		/// </summary>
		/// <returns>The children lines.</returns>
		/// <param name="g">The green component.</param>
		private GameObject[] FindChildrenLines(GameObject g)
		{
			GameObject[] l = GameObject.FindGameObjectsWithTag("Line");
			GameObject[] temp = new GameObject[l.Length];
			int j = 0;
			for (int i = 0; i < l.Length; i++)
			{
				if (l[i].transform.IsChildOf(g.transform))
				{
					temp[j++] = l[i];
				}
			}

			// Creating childlines into a smaller table
			// to remove nulls.
			l = new GameObject[j];
			for (int i = 0; i < j; i++)
				l[i] = temp[i];

			return l;
		}

		/// <summary>
		/// Tests for intersections between all lines.
		/// </summary>
		private void FindIntersections()
		{
			GameObject[] all = GameObject.FindGameObjectsWithTag("Line");
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
						ColorLine(all[i].GetComponent<LineRenderer>(), Color.magenta);
						ColorLine(all[j].GetComponent<LineRenderer>(), Color.magenta);
						intersecting = true;
						intersectCounter++;
					}
				}
				if (!intersecting)
				{
					ColorLine(all[i].GetComponent<LineRenderer>(), Color.green);
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
		/// Corrects the line positions to fit the circleses movement
		/// </summary>
		/// <param name="current">Current.</param>
		/// <param name="corrected">Corrected.</param>
		private void correctLinePositions(Vector3 current, Vector3 corrected)
		{
			LineRenderer l;

			for (int i = 0; i < childLines.Length; i++)
			{
				l = childLines[i].GetComponent<LineRenderer>();
				l.SetPosition(1, corrected);
			}

			GameObject other = GetOtherLine(held.name);
			l = other.GetComponent<LineRenderer>();
			l.SetPosition(0, corrected);
		}

		/// <summary>
		/// Gets the other line thats connected to the circle
		/// </summary>
		/// <returns>The other line.</returns>
		/// <param name="GameObjectName">Game object name.</param>
		private GameObject GetOtherLine(string GameObjectName)
		{
			string numbering = GameObjectName.Substring(6, 1);
			int number = int.Parse(numbering);

			GameObject map = GameObject.Find("GameManager");
			GameManager gg = map.GetComponent<GameManager>();

			int prev = number - 1;

			if (prev < 0)
			{
				prev = gg.circleCount - 1;
				number = gg.circleCount;
			}

			return GameObject.Find("Line (" + prev + "->" + number + ")");
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
		private GameObject IdentifyClickedItem()
		{
			Vector2 v2 = GetMouseWorld2DPosition();
			GameObject[] c = GameObject.FindGameObjectsWithTag("Circle");

			foreach (GameObject go in c)
				if (clicked(go.transform.position, v2))
					return go;

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