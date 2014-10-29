using UnityEngine;
using System.Collections;

public class BrickCollision : MonoBehaviour {

	//COLISOES DO CARRO PARA A FASE DA CORRIDA


	private Transform screenCrash; //sprite da tela quebrada
	private RaceWalls raceWalls; //paredes das laterais da pista
	private Transform mainCamera; //camera da gameplay
	private AudioManager audioManager;


	void Awake ()
	{
		audioManager = GameObject.Find ("AudioManager").GetComponent <AudioManager>();

		screenCrash = GameObject.Find ("ScreenCrash").transform;
		mainCamera = GameObject.Find ("Main Camera").transform;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.name == "Rival") //se colidir com rival
		{
			print ("Hit!");
			//toca som de colisão
			audioManager.Play("Brick-hit");

			//mostra a tela quebrada
			screenCrash.renderer.enabled = true;

			//gira a camera
			mainCamera.eulerAngles = new Vector3 (0, 0, 3);
			mainCamera.position = new Vector3 (mainCamera.position.x, 0.7f, mainCamera.position.z);
			mainCamera.audio.Play ();

			//inverte o lado do sprite (screenCrash) de acordo com a posição do jogador
			if (transform.position.x > 0)
				screenCrash.localScale = new Vector2 (-1, screenCrash.localScale.y);

			//anima o carro "explodindo"
			transform.FindChild ("CarBody").animation.Play("Brick-explosion");

			//pausa o movimento geral
			Game.time = 0;

			//chama o fim do level
			Invoke ("End", 2.0f);
		}
		else if (col.name == "EndLine") //se tocar na linha de chegada, completa o level
		{
			Game.EndLevel (true);
		}

	}

	//chama o Game Over
	void End ()
	{
		Game.EndLevel (false); //termina a fase sem sucesso
	}


}
