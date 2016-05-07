using UnityEngine;
using System.Collections;

public class ExplosionDamage : MonoBehaviour {

	public HomingBullet parent;

	void OnEnable()
	{
		StartCoroutine (ExplosionDuration ());
	}

	private IEnumerator ExplosionDuration()
	{
		yield return new WaitForSeconds (0.1f);

		parent.gameObject.SetActive (false);
	}


	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 9)
			collider.GetComponent<Health> ().RemoveHealth (5);



	}

}
