using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	//CONTROLE DO CARRO DA FASE RACE

	private SpriteRenderer buttonSprite;
	public Sprite buttonDown;
	public Sprite buttonUp;

	public GameObject car;
	int buttonNumber = 0;
	
	private AudioManager audioManager;
	
	
	void Awake ()
	{
		audioManager = GameObject.Find ("AudioManager").GetComponent <AudioManager>();
		buttonSprite = GetComponent<SpriteRenderer>();

		if (transform.localPosition.x < 0)
			buttonNumber = 1;
		if (transform.localPosition.x > 0)
			buttonNumber = -1;
	}

	void OnMouseDown ()
	{
		if (buttonNumber == 1 && car.transform.localPosition.x > -0.4f)
			MoveLeft ();
		else if (buttonNumber == -1 && car.transform.localPosition.x < 0.4f)
			MoveRight ();

		if (Game.time != 0)
			audioManager.Play ("Race-move");

		//diminui o botão
		buttonSprite.sprite = buttonDown;
	}

	void OnMouseUp ()
	{
		//aumenta o botão
		buttonSprite.sprite = buttonUp;
	}

	//movimenta o carro para a esquerda
	void MoveLeft ()
	{
		car.transform.localPosition = new Vector2 (car.transform.localPosition.x - 0.33f * Game.time, car.transform.localPosition.y);
	}

	//movimenta o carro para a direita
	void MoveRight ()
	{
		car.transform.localPosition = new Vector2 (car.transform.localPosition.x + 0.33f * Game.time, car.transform.localPosition.y);
	}


#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
	//CONTROLES DE TECLADO
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A) && buttonNumber == 1 && car.transform.localPosition.x > -0.4f)
		{
			MoveLeft ();
			
			//diminui o botão
			buttonSprite.sprite = buttonDown;
			
			if (Game.time != 0)
				audioManager.Play ("Race-move");
		}
		else if (Input.GetKeyDown (KeyCode.D) && buttonNumber == -1 && car.transform.localPosition.x < 0.4f)
		{
			MoveRight ();
			
			//diminui o botão
			buttonSprite.sprite = buttonDown;
			
			if (Game.time != 0)
				audioManager.Play ("Race-move");
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D))
			buttonSprite.sprite = buttonUp; //aumenta o botão

	}
#endif


}
