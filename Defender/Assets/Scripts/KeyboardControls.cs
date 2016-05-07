using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {


	private Motor motor;
	private Gun gun;

	private float driftSpeed = 0.4f;
	private float lockOnHold = 0;
	private float lockOnTime = 1f;


	void Start () 
	{
		motor = GetComponent<Motor> ();
		gun = GetComponent<Gun> ();
	}
	
	// Called Every Frame. Use for Jumping and Shooting (Not Movement)
	void Update () 
	{
		// RIGHT SLOW
		if (Input.GetKeyUp (KeyCode.D))
			motor.Horizontal (driftSpeed);

		// LEFT SLOW
		if (Input.GetKeyUp (KeyCode.A))
			motor.Horizontal (-driftSpeed);

		// UP STOP
		if (Input.GetKeyUp (KeyCode.W))
			motor.Vertical (0);

		// DOWN STOP
		if (Input.GetKeyUp (KeyCode.S))
			motor.Vertical (0);

		// SHOOT
		if (Input.GetKey (KeyCode.F)) 
		{
			lockOnHold += Time.deltaTime;

			if (lockOnHold >= lockOnTime)
				gun.LockOn ();
			else
				gun.Shot ();
		}

		if (Input.GetKeyUp (KeyCode.F))
		{
			if (lockOnHold >= lockOnTime)
				gun.LockOnShot ();

			lockOnHold = 0;

		}
	
	}

	// Use for Movement 
	void FixedUpdate()
	{
		// RIGHT
		if (Input.GetKey (KeyCode.D))
			motor.Horizontal (1);

		// LEFT
		if (Input.GetKey (KeyCode.A))
			motor.Horizontal (-1);

		// UP
		if (Input.GetKey (KeyCode.W))
			motor.Vertical (1);

		// DOWN
		if (Input.GetKey (KeyCode.S))
			motor.Vertical (-1);



	}
}
