using UnityEngine;
using System.Collections;

public class HomingBullet : MonoBehaviour {

	// UPGRADABLE
	public float speed;
	public float damage;

	public Motor parentMotor;
	private Rigidbody2D rb;
	private Vector3 movement;
	public GameObject targetObject;
	private Vector3 target;
	private GameObject explosionRadius;




	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		explosionRadius = transform.FindChild ("ExplosionRadius").gameObject;
	}

	void OnEnable()
	{
		movement = new Vector3(speed, 0, 0);
	}
		


	void FixedUpdate () 
	{
		target = targetObject.transform.position;

		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == 9) 
		{
			explosionRadius.SetActive (true);
		
			speed = 0;
		}


	}
}
