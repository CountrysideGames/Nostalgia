using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {



	void OnClick ()
	{
		Game.Reset ();
		Game.StartLevel ();
	}


}
