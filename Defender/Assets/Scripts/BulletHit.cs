using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	[HideInInspector]
	public float damage;
	private int pierce = 0;
	private const int HIT = 1;

	public int pierceAmount = 1;

	void OnEnable ()
	{
		pierce = 0;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == 9) 
		{
			collider.GetComponent<Health> ().RemoveHealth (damage);
			pierce += HIT;
		}


		if (pierce == pierceAmount)
			gameObject.SetActive (false);
	}
}
