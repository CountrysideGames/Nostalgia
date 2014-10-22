using UnityEngine;
using System.Collections;

public class ButtonSettings : MonoBehaviour {


	public GameObject panelSettings;

	void OnClick ()
	{
		if (!panelSettings.activeSelf)
			panelSettings.SetActive(true);
		else
			panelSettings.SetActive(false);
	}


}
