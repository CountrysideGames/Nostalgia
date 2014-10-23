using UnityEngine;
using System.Collections;

public class HeadCollider : MonoBehaviour {


	bool isPlaying = false;


	void OnCollisionEnter2D (Collision2D col)
	{
		transform.parent = null;

		if (!isPlaying)
		{
			audio.Play ();
			isPlaying = true;
		}

		//Game.EndLevel (false);
	}

}
