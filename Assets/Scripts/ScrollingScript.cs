﻿using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour {


	public Vector2 speed = new Vector2(2, 2);

	public Vector2 direction = new Vector2(-1, 0);

	public bool isLinkedToCamera = false;

	public bool isLooping = false;

	private List<Transform> backgroundPart;

	// Use this for initialization
	void Start () 
	{
		if (isLooping)
		{
			backgroundPart = new List<Transform>();

			for (int i = 0; i < transform.childCount; ++i)
			{
				Transform child = transform.GetChild(i);
				//add only visible children)
				if (child.renderer != null)
					backgroundPart.Add (child);
			}
			//sort by position (left to right)
			backgroundPart = backgroundPart.OrderBy (t => t.position.x).ToList ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 movement = new Vector3 (speed.x * direction.x
		                               , speed.y * direction.y
		                               , 0);
		movement *= Time.deltaTime;
		transform.Translate (movement);

		if (isLinkedToCamera)
		{
			Camera.main.transform.Translate (movement);
		}

		//loop

		if (isLooping)
		{
			// get first child from the left
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null)
			{
				//check if child is already  partly in front of the camera

				if (firstChild.position.x < Camera.main.transform.position.x)
				{
					//check if we are really outside of the camera

					if (firstChild.renderer.IsVisibleFrom(Camera.main) == false)
					{
						// get last child position
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;

						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

						//set position of recycled background element
						firstChild.position = new Vector3(lastPosition.x + lastSize.x
						                                  , firstChild.position.y
						                                  , firstChild.position.z);

						// move recycled one to the back of the list
						backgroundPart.Remove (firstChild);
						backgroundPart.Add(firstChild);

					}
				}
			}
		}
	}
}
