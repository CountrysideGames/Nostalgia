using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour {

	public GameObject successScene;
	public GameObject failScene;

	public void ShowCutscene (bool success)
	{
		if (success)
			successScene.SetActive(true);
		else
			failScene.SetActive(true);

	}
}
