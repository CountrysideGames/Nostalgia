using UnityEngine;
using System.Collections;

public class BlowController : MonoBehaviour {


	private MicControlC micControl;
	private SpriteRenderer sprite;


	void Awake ()
	{
		micControl = GetComponent<MicControlC>();
		sprite = GetComponent<SpriteRenderer>();
	}


	void Update ()
	{
		if (micControl.loudness > 20)
			sprite.enabled = true;
		else
			sprite.enabled = false;
	}
}
