using UnityEngine;
using System.Collections;

public class ButtonRestart : MonoBehaviour {
	
	//Botão que reinicia a fase atual


	void OnClick ()
	{
		Game.Reset ();
		Game.StartLevel ();
	}


}
