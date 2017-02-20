using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Generator
{
    public class Controller : MonoBehaviour 
    {
		GameObject yeah;
		void Start()
		{
			yeah = this.gameObject;
		}

        void Update( )
        {
			if (Input.GetMouseButtonDown(0))
			{
				;				
			}
        }

		private bool Clicked(Vector2 goPosition, Vector2 click)
		{
			float a = Mathf.Abs(goPosition.x - click.x);
			float b = Mathf.Abs(goPosition.y - click.y);
			float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));

			return c < GraphicsCreator.CIRCLE_RADIUS;
		}
    } 
}

