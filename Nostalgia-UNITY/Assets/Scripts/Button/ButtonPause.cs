using UnityEngine;
using System.Collections;

public class ButtonPause : MonoBehaviour {


	public GameObject panelPause;
	
	
	void Update ()
	{
		//se apertar o ESC ou botão BACK do celular
		if (Input.GetKeyDown (KeyCode.Escape))
				Pause ();
	}
	
	void OnClick ()
	{
		Pause ();
	}


	void Pause ()
	{
		if (!Game.isPaused)
		{
			print ("Paused");
		
			Game.time = 0;
			Time.timeScale = 0;

			Game.isPaused = true;

			panelPause.SetActive(true);
		}
	}


}
