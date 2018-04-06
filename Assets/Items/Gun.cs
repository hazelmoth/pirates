using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item {

	[SerializeField] private int baseDamage = 50;

	public int BaseDamage ()
	{
		return baseDamage;
	}
}
