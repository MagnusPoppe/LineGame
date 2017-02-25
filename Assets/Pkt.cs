using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pkt
	{
		// Information about the circle;
		GameObject circle;
		int id;

		// All of the attached lines:
		List<GameObject> attachedLines;


		/// <summary>
		/// Pkt is a point in the map. Its represented with a Circle sprite.
		/// Initializes a new instance of the <see cref="T:Game.Pkt"/> class.
		/// </summary>
		/// <param name="circle">Circle.</param>
		public Pkt(GameObject circle)
		{
			this.Circle = circle;
			this.attachedLines = new List<GameObject>();
		}

		/// <summary>
		/// Pkt is a point in the map. Its represented with a Circle sprite.
		/// Initializes a new instance of the <see cref="T:Game.Pkt"/> class.
		/// </summary>
		/// <param name="circle">Circle.</param>
		public Pkt(GameObject circle, int id)
		{
			this.Circle = circle;
			this.id = id;
			this.attachedLines = new List<GameObject>();
		}

		/// <summary>
		/// Adds a line.
		/// </summary>
		/// <param name="line">Line.</param>
		public void AddLine(GameObject line)
		{
			attachedLines.Add(line);
		}

		/// <summary>
		/// Gets or sets the circle.
		/// </summary>
		/// <value>The circle.</value>
		public GameObject Circle
		{
			get
			{
				return circle;
			}

			set
			{
				circle = value;
			}
		}

		/// <summary>
		/// Gets or sets the position.
		/// 
		/// Setter sets position for all attached lines as well.
		/// </summary>
		/// <value>The position.</value>
		public Vector2 Position
		{
			get
			{
				return Circle.transform.position;
			}

			set
			{
				Circle.transform.position = value;

				// Changing position for the attached lines as well
				foreach (GameObject line in attachedLines)
				{
					string[] pkts = line.name.Split(';');
					LineRenderer l = line.GetComponent<LineRenderer>();;

					if (int.Parse(pkts[0]) == ID)
					{
						l.SetPosition(0, value);
					}
					else if (int.Parse(pkts[1]) == ID)
					{
						l.SetPosition(1, value);
					}
					else
					{
						Debug.Log("Error finding line to circle ID for line: " + line.name);
					}
				}
			}
		}

		/// <summary>
		/// Destories all objects attached to this pkt.
		/// </summary>
		public void DestoryAll()
		{
			foreach (GameObject line in attachedLines)
			{
				string[] pkts = line.name.Split(';');
				if (int.Parse(pkts[0]) == ID)
				{
					GameObject.Destroy(line);
				}
			}
			GameObject.Destroy(circle);
			attachedLines = null;
			circle = null;
		}

		/// <summary>
		/// Gets the attached lines.
		/// </summary>
		/// <value>The attached lines.</value>
		public GameObject[] AttachedLines
		{
			get
			{
				return attachedLines.ToArray();
			}
		}

		/// <summary>
		/// Gets the identifier. Should be the same as the index in table.
		/// </summary>
		/// <value>The identifier.</value>
		public int ID
		{
			get
			{
				return id;
			}
		}
	}
}
