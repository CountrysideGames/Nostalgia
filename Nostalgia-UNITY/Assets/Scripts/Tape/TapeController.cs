using UnityEngine;
using System.Collections;

public class TapeController : MonoBehaviour {

	public GameObject pencil; //lápis
	public GameObject wheel; //roda

	public Transform[] roll = new Transform[2]; //rolos de fita
	private Vector2[] rollScale = new Vector2[2]; //escala dos rolos
	private Animator pencilAnimator; //Animator do lápis
	private Animator wheelAnimator; //animador da wheel sem lápis
	bool playSound = true;

	int state = 0; //state 0 = stop / state 1 = rewind

	bool canPress = true;
	bool press = false; //indica se o jogador está tocando a tela/tecla
	float timer = 0;

	

	void Start ()
	{
		pencilAnimator = pencil.GetComponent<Animator>();
		wheelAnimator = wheel.GetComponent<Animator>();

		state = 0; //define o estado como STOP (a fita não está em Rewind)

		canPress = true;
		press = false;
		timer = 0;
	}



	void Update ()
	{
//CONTROLES TOUCH
		//se o jogo estiver no tempo normal
		if (Game.time != 0)
		{
			//e der um toque e MOVER o dedo
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 touchPosition = Input.GetTouch (0).position;
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

				//se arrastar o dedo para a esquerda na metade de baixo da tela, a fita gira e o lápis gira
				if (touchPosition.y > Screen.height/4 && touchPosition.y < (Screen.height/4) * 3 && touchDeltaPosition.y > 0)
					Rewind ();
			}
#if !UNITY_EDITOR
			//se o estado for 1 (rewind) jogador parar de mover o dedo, ou tirar ele da tela, o lápis pára de girar
			else if (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Stationary)
				StopRewind ();

			print ("Oi");
#endif

//CONTROLES TECLADO
			if (canPress && Input.GetKey (KeyCode.Space))
				Rewind ();
			else if (Input.GetKeyUp (KeyCode.Space))
				StopRewind ();


//SE O ESTADO FOR 1 (REWIND), COMEÇA UM CONTADOR DE TEMPO, QUE PAUSA APÓS 1 SEGUNDO
			if (state == 1)
			{
				timer += 1 *Time.deltaTime;

				if (timer > 0.3f)
					EndTimer ();
			}

		}
	}


	void EndTimer ()
	{
		if (press)
			press = false; //INDICA QUE O JOGADOR NÃO ESTÁ MAIS PRESSIONANDO
		
		//pausa o som
		wheel.audio.Pause ();
		playSound = true;
		canPress = false;
		timer = 0;
		state = 0;

		//reduz a velocidade da animação para zero
		pencilAnimator.speed = 0;
		wheelAnimator.speed = 0;

	}

	void Rewind ()
	{
		if (!press)
			press = true;

		rollScale[0] = roll[0].localScale;
		rollScale[1] = roll[1].localScale;

		//se o segundo rolo estiver MENOR que o limite
		if (roll[0].localScale.x < 1 && canPress)
		{
			if (playSound)
				wheel.audio.Play ();
			playSound = false;

			//reduz a escala do rolo 0
			roll[1].transform.localScale = new Vector2 (rollScale[0].x - 0.009f, rollScale[0].y - 0.009f);
			//aumenta a escala do rolo 1
			roll[0].transform.localScale = new Vector2 (rollScale[1].x + 0.005f, rollScale[1].y + 0.005f);

			//ativa a animação da caneta girando
			pencilAnimator.SetBool ("Rewind", true);
			//ativa a animação da roda girando
			wheelAnimator.SetBool ("Rewind", true);

			//aumenta a velocidade da animação para 1
			pencilAnimator.speed = 1;
			wheelAnimator.speed = 1;
		}
		else if (roll[1].localScale.x >= 1.08f)
		{
			Game.EndLevel (true);
		}

		state = 1; //define o estado como REWIND (a fita está rebobinando)
	}



	void StopRewind ()
	{
		EndTimer ();

		//desativa a animação da caneta girando
		//pencilAnimator.SetBool ("Rewind", false);
		
		//desativa a animação da roda girando
		//wheelAnimator.SetBool ("Rewind", false);

		canPress = true;
	}



}