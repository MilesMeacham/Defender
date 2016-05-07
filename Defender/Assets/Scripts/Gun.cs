// Author: Miles Meacham 2016
// Description: 

using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	// BASIC GUN ATTRIBUTES
	public ObjectPooler bulletPools;
	public GameObject bullet;
	public Transform shootingPoint, endPoint;  // endPoint used for LockOn
	private bool reloading;
	// Set this to which ever projectile you want him to shoot IN THE EDITOR, if unchanged it will shoot the basic bullets.
	public string poolName = "BasicBulletPooler";
	public string bulletTag;				// This should either be EnemyBullet or PlayerBullet. Set it to that in the editor

	// UPGRADABLE
	private float damage;
	public float baseDamage = 1;
	public float damageMultiplier = 1;
	public float damageUpgrade = 0;
	private float reloadTime;
	public float baseReloadTime = 0.5f;
	public float reloadTimeDecreaseMultiplier = 1;


	// HOMING SHOT ATTRIBUTES
	//public bool lockedOn;
	RaycastHit2D hit;
	private GameObject target;
	public string homingPoolName = "HomingBulletPooler";
	private ObjectPooler homingBulletPool;



	void Start()
	{
		bulletPools = GameObject.Find (poolName).GetComponent<ObjectPooler> ();
		homingBulletPool = GameObject.Find (homingPoolName).GetComponent<ObjectPooler> ();
	}


	public void Shot()
	{
		if (!reloading) 
		{
			// Functions to figure out reload time and damage
			reloadTime = baseReloadTime/reloadTimeDecreaseMultiplier;
			damage = (baseDamage * damageMultiplier) + damageUpgrade;


			bullet = bulletPools.GetPooledObject ();
			bullet.GetComponent<BulletMovement> ().parentMotor = gameObject.GetComponent<Motor> ();
			bullet.GetComponent<BulletHit> ().damage = damage;
			bullet.gameObject.tag = bulletTag;

			bullet.transform.position = shootingPoint.transform.position;
			bullet.SetActive (true);

			StartCoroutine (Reload());
		}

	}

	public void LockOn()
	{
		//Debug.DrawLine (shootingPoint.position, endPoint.position, Color.green);
		//lockedOn = Physics2D.Linecast (shootingPoint.position, endPoint.position, 1 << LayerMask.NameToLayer("Enemy"));
		hit = Physics2D.Linecast (shootingPoint.position, endPoint.position, 1 << LayerMask.NameToLayer("Enemy"));

		if (hit != false && target == null)
			target = hit.collider.gameObject;

	}

	public void LockOnShot()
	{
		if (target == null)
			target = endPoint.gameObject;

		bullet = homingBulletPool.GetPooledObject ();
		bullet.GetComponent<HomingBullet> ().parentMotor = gameObject.GetComponent<Motor> ();
		bullet.GetComponent<HomingBullet> ().damage = damage;
		bullet.GetComponent<HomingBullet> ().targetObject = target;
		bullet.gameObject.tag = bulletTag;

		bullet.transform.position = shootingPoint.transform.position;
		bullet.SetActive (true);

		target = null;

	}

	IEnumerator Reload()
	{
		reloading = true;

		yield return new WaitForSeconds (reloadTime);

		reloading = false;

	}
}
