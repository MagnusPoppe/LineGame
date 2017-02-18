using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Generator;
using AssemblyCSharp;

public class ClickManager : MonoBehaviour 
{

	private bool heldWithMouse;
	private GameObject held;
	private GameObject[] childLines;

	// Use this for initialization
	void Start () 
	{
		testForIntersect();
		heldWithMouse = false;		
	}

	// Update is called once per frame
	void Update()
	{
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
			correctLinePositions(GetMouseWorld2DPosition(),held.transform.position);
			held.transform.position = GetMouseWorld2DPosition();
			testForIntersect();
		}
	}

	/// <summary>
	/// Finds the children lines.
	/// </summary>
	/// <returns>The children lines.</returns>
	/// <param name="g">The green component.</param>
	private GameObject[] FindChildrenLines( GameObject g )
	{
		GameObject[] l = GameObject.FindGameObjectsWithTag("Line");
		GameObject[] temp = new GameObject[l.Length];
		int j = 0;
		for (int i = 0; i<l.Length; i++)
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
	/// Tests for intersect.
	/// </summary>
	private void testForIntersect()
	{
		GameObject[] all = GameObject.FindGameObjectsWithTag("Line");

		for (int current = 0; current < all.Length; current++)
		{
			LineRenderer lrc = all[current].GetComponent<LineRenderer>();
			Line currentLine = new Line(lrc.GetPosition(0), lrc.GetPosition(1));

			bool touching = false;

			for (int i = 0; i < all.Length; i++)
			{
				if (i == current) continue;

				LineRenderer lri = all[i].GetComponent<LineRenderer>();

				Line otherLine = new Line(lri.GetPosition(0), lri.GetPosition(1));

				Vector2 intersection = currentLine.Intersect(otherLine);					

				if (currentLine.hasIntersection(otherLine))
				{
					Debug.Log( currentLine + "and" + otherLine +"are intersecting at "+ intersection);
					
					ColorLine(all[i].GetComponent<LineRenderer>(), Color.red);
					touching = true;
				}
				else
				{
					ColorLine(all[i].GetComponent<LineRenderer>(), Color.green);
				}
			}

			if (touching)
				ColorLine(all[current].GetComponent<LineRenderer>(), Color.red);
			else
				ColorLine(all[current].GetComponent<LineRenderer>(), Color.green);
		}
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

		GameObject map = GameObject.Find("MapGenerator");
		GameCreator gg = map.GetComponent<GameCreator>();

		int prev = number - 1;

		if (prev < 0)
		{
			prev = gg.circleCount-1;
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
