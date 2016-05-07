using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	// UPGRADABLE
	public float speed;
	public float duration;

	public Motor parentMotor;
	private Rigidbody2D rb;
	private Vector3 movement;





	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnEnable()
	{
		movement = new Vector3(speed, 0, 0);
		StartCoroutine(Duration());
	}

	private IEnumerator Duration()
	{

		yield return new WaitForSeconds (duration);

		gameObject.SetActive(false);

	}


	void FixedUpdate () 
	{
		rb.velocity = movement;

	}
}
