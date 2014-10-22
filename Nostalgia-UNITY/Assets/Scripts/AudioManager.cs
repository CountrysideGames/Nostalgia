using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {


	public AudioClip[] audioClip = new AudioClip[15];


	public void Play (string audioClipName)
	{
		for (int i = 0; i < audioClip.Length; i++)
		{
			//define o audio.Clip como sendo aquele que está na variável "audioClipName" desta função
			if (audioClip[i].name == audioClipName)
				audio.clip = audioClip[i];
		}

		audio.Play ();
	}



}


