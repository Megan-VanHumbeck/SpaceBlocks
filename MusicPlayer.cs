using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake() //Called before Start
	{
		if (instance != null)
		{
			Destroy (gameObject);
			//Debug.Log ("SELF DESTRUCT MUSIC PLAYER");
		}

	}

	void Start () 
	{
		instance = this;
		GameObject.DontDestroyOnLoad(gameObject); 
	}

	void Update () 
	{
	
	}
}

