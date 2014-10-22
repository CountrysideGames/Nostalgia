using UnityEngine;
using System.Collections;

public class ButtonResume : MonoBehaviour {

	
	void Update ()
	{
		//se apertar o ESC ou botão BACK do celular
		if (Input.GetKeyDown (KeyCode.Escape))
			Resume ();
	}
	
	void OnClick ()
	{
		Resume ();
	}


	void Resume ()
	{
		print ("Resumed");
		
		Game.time = 1;
		Time.timeScale = 1;
		
		Game.isPaused = false;
		
		//oculta o menu de pause
		transform.parent.gameObject.SetActive(false);
	}
}
