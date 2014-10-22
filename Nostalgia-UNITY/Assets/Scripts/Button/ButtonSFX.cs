using UnityEngine;
using System.Collections;

public class ButtonSFX : MonoBehaviour {



	private GameObject sfxOn;


	void Awake ()
	{
		sfxOn = transform.FindChild("sp_SFX-on").gameObject;

		RefreshSprite ();
	}

	void OnClick ()
	{
		audio.Play ();
		
		if (AudioListener.volume == 1)
		{
			AudioListener.volume = 0;
			sfxOn.SetActive(false);
		}
		else
		{
			AudioListener.volume = 1;
			sfxOn.SetActive(true);
		}

		RefreshSprite ();
	}

	void RefreshSprite ()
	{
		if (AudioListener.volume == 1)
			sfxOn.SetActive(true);
		else
			sfxOn.SetActive(false);
	}

}
