using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interval : MonoBehaviour {


	public float delay = 2;
	public int reward = 100;

	public UILabel scoreCounter;
	public UILabel wow;
	public List<GameObject> chanceSprite = new List<GameObject>();
	public AudioClip success;
	public AudioClip fail;
	public AudioClip gameOver;


	void Awake ()
	{
		for (int i = 0; i < chanceSprite.Count; i++)
			chanceSprite[i].SetActive(false);
	}


	void Start ()
	{
		//mostra o numero de score
		RefreshScore ();

		//mostra o número de chances
		RefreshChances ();

		if (Game.levelComplete)
			audio.clip = success;
		else
			audio.clip = fail;
		
		if (Game.chances <= 0)
			audio.clip = gameOver;

		audio.Play ();
		
		//chama a próxima fase
		Invoke ("RefreshScore", delay/4);

		//chama a próxima fase
		Invoke ("NextLevel", delay);
	}

	void RefreshChances ()
	{
		//mostra o numero de chances da sessão
		for (int i = 0; i < Game.chances; i++)
			chanceSprite[i].SetActive(true);

		//se o jogador tiver completado o level, ganha a recompensa no score
		if (Game.levelComplete)
		{
			wow.enabled = true;
			Game.score += reward;
		}
		else //caso contrario, perde 1 chance (coração)
			Game.chances -= 1;

		//roda animação de chance sendo perdida
		for (int i = chanceSprite.Count; i > Game.chances; i--)
			chanceSprite[i-1].animation.Play ("Chance-miss");
	}

	void RefreshScore ()
	{
		scoreCounter.text = Game.score.ToString ();
		
		if (Game.chances <= 0)
		{
			Application.LoadLevel ("Menu");
		}
	}

	void NextLevel ()
	{
		Game.StartLevel ();
	}


}
