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
		const ColorSchema.Schemas PRE_DEFINED_SCHEMA = ColorSchema.Schemas.LIGHT_STEEL;
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
        private Vector2 centerOfScreen;
		public Text Level_Number_Text;
		public Text Level_Text_Text;

        // APPLICATION SETTINGS:
        const int MOBILE_FRAMERATE = 30;
        const int OTHER_FRAMERATE = 60;
	    static int TOTAL_ANIMATED_FRAMES;

	    // Animation:
	    const int ANIMATION_SPEED = 2; // Speed in secounds
        const int ANIMATION_NOT_STARTED = -1;
        const int ANIMATION_ENDED = 0;
        int animationcounter;
        bool animationComplete;

//----------------------------------------AWAKE()----------------------------------------\\
		void Awake()
		{
		    int framerate;
            if (Application.isMobilePlatform)
                framerate = MOBILE_FRAMERATE;
            else if (Application.isWebPlayer)
                framerate = OTHER_FRAMERATE;
            else
                framerate = OTHER_FRAMERATE;

		    TOTAL_ANIMATED_FRAMES = framerate * ANIMATION_SPEED;
            Application.targetFrameRate = framerate;
		}


//----------------------------------------START()----------------------------------------\\
		void Start()
		{
			mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

            centerOfScreen = GetWorld2DPosition(mainCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0)));
            Debug.Log(centerOfScreen);

			// Setting the colors
			colorSchema = new ColorSchema(PRE_DEFINED_SCHEMA, colorcodeLines);
			Level_Number_Text.color = colorSchema.Font;
			Level_Text_Text.color = colorSchema.Font;
			mainCamera.backgroundColor = colorSchema.Background;


			// Setting up the game:
			level = 0;
			game = new GameManager(Level_Number_Text, darkCircle, lightCircle, lineMaterial, colorSchema);

            game.NextLevel(centerOfScreen);
			heldWithMouse = false;
			levelIsWon = false;
            animationcounter = -1;
		}



//----------------------------------------UPDATE()---------------------------------------\\
		void Update()
		{
            if (levelIsWon && held == null)
            {
                if (animationcounter == ANIMATION_NOT_STARTED)
                {
                    animationComplete = false;
                    OnInteractionStop();
                    animationcounter = TOTAL_ANIMATED_FRAMES;
                }
                else if (animationcounter <= ANIMATION_ENDED)
                {
                    animationComplete = true;
                    animationcounter = -1;
                }
                else
                {
                    AnimateAllAgainstCenter();
                    animationcounter--;
                }

                if (animationComplete)
                {
                    ClearLevel();
                    game.NextLevel(centerOfScreen);

                }
            }
            else if (game.LoadingLevel)
            {
                if (animationcounter == ANIMATION_NOT_STARTED)
                {
                    animationComplete = false;
                    animationcounter = TOTAL_ANIMATED_FRAMES;
                }
                else if (animationcounter <= ANIMATION_ENDED)
                {
                    animationComplete = true;
                    animationcounter = -1;
                }
                else
                {
                    AnimateAllToInitialPosition();
                    animationcounter--;

                    // Updating intersections as we animate.
                    FindIntersections(false);
                }

                if (animationComplete)
                {
                    game.LoadingLevel = false;
                }
            }
            else if (Input.touchSupported)
            {
                if (Input.touchCount > 0)
                {
                    foreach (Touch touch in Input.touches)
                    {
                        OnInteractionStart(GetWorld2DPosition(touch.position));
                    }
                }
                else
                {
                    OnInteractionStop();
                }
            }
            else if (Input.mousePresent)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    OnInteractionStart(GetWorld2DPosition(Input.mousePosition));
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    OnInteractionStop();
                }
            }

            if (heldWithMouse) // HVA SKJER NÅR MAN HOLDER ET OBJEKT?
            {
                if (held != null)
                {
                    OnInteractionActive(Input.mousePosition);
                }
            }
		}

//----------------------------------------INPUT / INTERACTION METHODS----------------------------------\\
        private void OnInteractionStart(Vector2 inputPosition)
        {
            Pkt g = IdentifyClickedItem();

            if (g != null) // BRUKER TRYKKER NED KNAPP PÅ ET OBJEKT
            {
                g.Position = inputPosition;
                heldWithMouse = true;
                held = g;
            }
        }

        private void OnInteractionActive( Vector2 inputPosition )
        {
            if (held != null)
            {
                held.Position = GetWorld2DPosition(inputPosition);
                FindIntersections(true);
            }
            else
            {
                heldWithMouse = false;
            }
        }

        private void OnInteractionStop()
        {
            heldWithMouse = false;
            held = null;
        }


//----------------------------------------METHODS FOR LINEHANDELING----------------------\\
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
	    /// <param name="tryWinning"> True if wincase should be tested for.</param>
	    private void FindIntersections(bool tryWinning)
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

	        if (canWin && tryWinning)
	        {
	            if (intersectCounter == 0)
	                levelIsWon = true;
	            else
	                levelIsWon = false;
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



//----------------------------------------METHODS FOR POSITIONAL TRACKING:---------------\\
		/// <summary>
		/// Gets the mouse world 2D Position.
		/// </summary>
		/// <returns>The mouse world2 DP osition.</returns>
        private Vector2 GetWorld2DPosition(Vector2 inputPosition)
		{
            float mousex = inputPosition.x;
            float mousey = inputPosition.y;
			Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0.0f));
			return new Vector2(v3.x, v3.y);
		}

		/// <summary>
		/// Identifies the clicked item.
		/// </summary>
		/// <returns>The clicked item.</returns>
		private Pkt IdentifyClickedItem()
		{
            Vector2 v2 = GetWorld2DPosition(Input.mousePosition);

			float circleRadius = game.lightCircle.pixelsPerUnit;

			foreach (Pkt pkt in game.Circles)
				if (Vector2.Distance(pkt.Circle.transform.position, v2) < circleRadius)
					return pkt;

			return null;
		}

        private void AnimateAllAgainstCenter()
        {
            foreach (Pkt pkt in game.Circles)
            {
                float rate = AnimationMovementSpeed(pkt.Position, centerOfScreen);
                pkt.Position = Vector2.Lerp(pkt.Position, centerOfScreen, rate);
            }
        }

        private void AnimateAllToInitialPosition()
        {
            foreach (Pkt pkt in game.Circles)
            {
                float rate = AnimationMovementSpeed(pkt.Position, pkt.InitialPosition);
                pkt.Position = Vector2.Lerp(pkt.Position, pkt.InitialPosition, rate);
            }
        }

	    private float AnimationMovementSpeed(Vector2 from, Vector2 to)
	    {
	        // Setting speed:
	        float rate = Vector2.Distance(from,to) / TOTAL_ANIMATED_FRAMES;

	        // TODO: Clamping does not work.
	        if (rate <= .1f) rate = .1f;

	        return rate;
	    }
	}
}