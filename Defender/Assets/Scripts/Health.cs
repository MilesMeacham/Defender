using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 1;
	public float maxHealth = 1;
	public float minHealth = 0;
	public float possibleMaxHealth = 10;  // This is used if you want to set a limit to the amount of health upgrades you can get
	private bool invincible;

	private GameManager gameManager;

	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	// Adds health if character is missing health
	public void AddHealth (float amount)
	{
		health += amount;
		if (health > maxHealth)
			health = maxHealth;
	}

	public void RemoveHealth (float amount)
	{
		if (!invincible)
			health -= amount;

		if (health <= minHealth) 
		{
			health = minHealth;

			Die ();
		}

	}
		
	// Sets character to inactive
	private void Die ()
	{
		gameObject.SetActive (false);

		if (gameObject.layer == 8)
			gameManager.RestartGame ();

	}



}
