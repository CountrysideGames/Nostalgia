using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {


	public float time = 3.0f;
	private string levelName;


	void Start ()
	{
		//if (PlayerPrefs.GetInt( levelName + "Tutorial") != 0)
		//	HideTutorial ();

		levelName = Application.loadedLevelName;
		Invoke ("HideTutorial", time);
	}

	//oculta o tutorial
	void HideTutorial ()
	{
		gameObject.SetActive(false);

		PlayerPrefs.SetInt (levelName + "Tutorial", 1); //define o tutorial como completo
	}
	
}