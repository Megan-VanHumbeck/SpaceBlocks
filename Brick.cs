using UnityEngine;
using System.Collections;


public class Brick : MonoBehaviour {

	public Sprite [] hitSprites;
	public AudioClip crack;
	public GameObject smoke;
	public static int breakableCount = 0;

	private int maxHits, timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 

	void Start () {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable"); //Is this brick breakable?
		maxHits = hitSprites.Length + 1; //Determines right colour (sprite) for the brick
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (isBreakable)
		{
			breakableCount ++; //Counts number of breakable bricks in a level
			//Debug.Log (breakableCount);
		}
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable)
		{
			handleHits();
		}
	}

	void handleHits()
	{
		timesHit ++;
		if (timesHit >= maxHits)
		{
			breakableCount --;
			levelManager.BrickDestroyed();
			//Debug.Log (breakableCount);
			PuffSmoke();
			Destroy (gameObject);
		}
		else
		{

			LoadSprite();
		}
	}

	void PuffSmoke()
	{
		GameObject  smokePuff = Instantiate (smoke, this.transform.position, Quaternion.identity)as GameObject; //Turns Object into GameObject
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}

	//For debugging
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}

	void LoadSprite()
	{
		if (hitSprites[timesHit - 1])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
		}
		else
		{
			Debug.LogError ("Sprite Does Not Exist!");
		}
	}
}
