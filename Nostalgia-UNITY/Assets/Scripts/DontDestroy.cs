using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {


	//ESTA CLASSE IMPEDE QUE O GAMEOBJECT SEJA DESTRUÍDO DURANTE A MUDANÇA DE CENAS


	void Start ()
	{
		DontDestroyOnLoad (gameObject);
	}

}
