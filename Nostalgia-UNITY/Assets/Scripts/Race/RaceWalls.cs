using UnityEngine;
using System.Collections;

public class RaceWalls : MonoBehaviour {

	
	void Start ()
	{
		InvokeRepeating ("MoveDown", 0.2f, 0.2f);
	}
	
	void MoveDown ()
	{
		transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - 0.33f * Game.time * 2.0f);

		if (Game.time == 0)
			CancelInvoke ();
	}

	void Update ()
	{
		if (transform.localPosition.y < -1.3f)
			transform.localPosition = new Vector2 (0, 0);
	}

}
