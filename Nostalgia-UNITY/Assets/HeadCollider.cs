using UnityEngine;
using System.Collections;

public class HeadCollider : MonoBehaviour {


	bool isPlaying = false;
	private Rigidbody2D body;


	void Start ()
	{
		body = transform.parent.rigidbody2D;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		transform.parent = null;

		if (!isPlaying)
		{
			audio.Play ();
			isPlaying = true;
			Invoke ("GameOver", 1.0f);
		}
	}

	void GameOver ()
	{
		Game.EndLevel (false);
	}

}
