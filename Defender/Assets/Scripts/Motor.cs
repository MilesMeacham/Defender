using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	private Rigidbody2D rb;


	public float horizontalSpeed = 7;
	public float verticalSpeed = 5;
	private float speed;
	private float speedMultiplier = 1;



	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}


	// Pass 1 or -1 for right and left
	public void Horizontal(float direction)
	{
		rb.velocity = new Vector2 (horizontalSpeed * direction, rb.velocity.y);
	}

	// Pass 1 or -1 for up and down
	public void Vertical(int direction)
	{
		rb.velocity = new Vector2 (rb.velocity.x, verticalSpeed * direction);
	}





}
