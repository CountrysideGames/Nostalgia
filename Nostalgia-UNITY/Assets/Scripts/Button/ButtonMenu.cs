using UnityEngine;
using System.Collections;

public class ButtonMenu : MonoBehaviour {




	void OnClick ()
	{
		Game.time = 1;
		Time.timeScale = 1;
		Game.playedLevels.Clear ();
		Application.LoadLevel("Menu");

	}


}
