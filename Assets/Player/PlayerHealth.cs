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
		GameObject.FindObjectOfType<UIManager> ().UpdateHealthBar (currentHealth / maxHealth);
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
		if (Player.localPlayer.gameObject == this.gameObject) {
			GameObject.FindObjectOfType<UIManager> ().UpdateHealthBar ((float)currentHealth / (float)maxHealth);
		}
	}
}