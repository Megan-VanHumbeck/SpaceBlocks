using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	public float lr = 1f, ud = 10f;
	bool hasStarted = false;

	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>(); 
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update () {
		if (!hasStarted)
		{
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0))
			{
				//Debug.Log("Mouse Clicked, launch ball");
				this.rigidbody2D.velocity = new Vector2(lr, ud); 
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Vector2 tweak = new Vector2 (Random.Range (-0.5f, 0.5f), Random.Range(0f, 0.3f));
		this.rigidbody2D.velocity = this.rigidbody2D.velocity + tweak;
		if (hasStarted && col.gameObject.tag != "Breakable")
		{	
			audio.Play ();
		}
	}
}
