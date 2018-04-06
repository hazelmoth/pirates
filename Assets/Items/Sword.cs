using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item {

	[SerializeField] private int baseDamage = 30;

	public int BaseDamage ()
	{
		return baseDamage;
	}
}
