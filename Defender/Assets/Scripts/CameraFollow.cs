using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	private GameObject target;  // Will usually be the player
	private Rigidbody2D targetRB;
	private float targetVelocity;
	private Rigidbody2D cameraRB;
	private Vector3 lastPosition;
	private float distance;
	private float speed = 2.5f;
	private float distanceAhead = 2;


	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find ("Player");
		targetRB = target.GetComponent<Rigidbody2D> ();

		cameraRB = GetComponent<Rigidbody2D> ();

		lastPosition = target.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		CameraMovement ();
	}

	void CameraMovement()
	{

		distance = transform.position.x - lastPosition.x;
		targetVelocity = targetRB.velocity.x;


		// Adjust the camera so you can see more in front of you
		if (targetVelocity <= 0) 
		{
			if (distance >= -distanceAhead)
				speed = -8;
			else
				speed = targetVelocity;
		}
		else if (targetVelocity > 0) 
		{
			if (distance <= distanceAhead)
				speed = 8;
			else
				speed = targetVelocity;
		}


		// Keeps camera from going below the ground
		if (transform.position.y < 0)
			transform.position = new Vector2 (transform.position.x, 0);

		cameraRB.velocity = new Vector2 (speed, cameraRB.velocity.y);

		lastPosition = target.transform.position;
	}
}




// Follow behind player
/*

transform.position = Vector3.Lerp (transform.position, target.transform.position, speed * Time.deltaTime);

if (distance >= tooFarAway && speed == normalSpeed)
	speed = catchUpSpeed;
else if (distance < tooFarAway - 1 && speed != normalSpeed)
	speed = normalSpeed;
*/