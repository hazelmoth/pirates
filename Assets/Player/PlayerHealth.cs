using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerHealth : NetworkBehaviour {

	private const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;

	public override void OnStartLocalPlayer ()
	{
		
	}

	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}
	}

	void OnChangeHealth (int health)
	{
		currentHealth = health;
		Player.localPlayer.GetComponent<UIManager>().UpdateHealthBar(currentHealth / maxHealth);
	}
}