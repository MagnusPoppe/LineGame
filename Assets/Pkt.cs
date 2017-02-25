using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pkt
	{
		// Information about the circle;
		GameObject circle;
		Vector2 position;

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
		/// </summary>
		/// <value>The position.</value>
		public Vector2 Position
		{
			get
			{
				return position;
			}

			set
			{
				position = value;
			}
		}

		/// <summary>
		/// Gets the attached lines.
		/// </summary>
		/// <value>The attached lines.</value>
		public GameObject[] AttachedLines
		{
			get
			{
				GameObject[] lines = new GameObject[attachedLines.Count];
				for (int i = 0; i < attachedLines.Count; i++)
					lines[i++] = attachedLines[i];
				
				return lines;
			}
		}
	}
}
