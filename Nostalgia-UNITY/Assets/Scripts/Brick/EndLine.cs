using UnityEngine;
using System.Collections;

public class EndLine : MonoBehaviour {
	
	
	
	void Start ()
	{
		InvokeRepeating ("MoveDown", Game.time/5, Game.time/5);
	}
	
	void MoveDown ()
	{
		transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - 0.33f * Game.time);
		
		if (Game.time == 0)
			CancelInvoke ();
	}
	
}
