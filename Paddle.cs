using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update () {
		if (!autoPlay)
		{
			MoveWithMouse();
		}
		else
		{
			FollowBall ();
		}
	}

	void MoveWithMouse ()
	{
		float mousePosInBlocks;
		Vector3 paddlePos;
		mousePosInBlocks = (Input.mousePosition.x/Screen.width * 16); //Relative mouse position Game is 16 game units wide
		paddlePos = new Vector3 (Mathf.Clamp(mousePosInBlocks, 0.75f, 15.25f), this.transform.position.y);
		this.transform.position = paddlePos;
	}

	void FollowBall ()
	{
		this.transform.position = new Vector2 (Mathf.Clamp (ball.transform.position.x, 0.5f, 15.5f),
		                                       this.transform.position.y);
	}
}
