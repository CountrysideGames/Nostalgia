using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioButton : MonoBehaviour {


	//ESTA CLASSE ADICIONA SOM AO BOTÃO EM QUE FOR ANEXADA
	//não se esqueça de adicionar o clip de áudio no componente AudioSource

	void Awake ()
	{
		audio.playOnAwake = false;
	}

	void OnClick ()
	{
		audio.Play();
	}



}
