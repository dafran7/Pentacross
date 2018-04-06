using System;
using UnityEngine;
using System.Collections;

public class Spell
{
	public int spellID;
	public string spellName;
	public string spellEffect;
	public int spellDuration;
	public string spellDescription;
	public int price;
	public int held;

	public Spell(string newName, int newDuration, string newEffect, string newDescription, int newPrice, int newHeld){
		spellName = newName;
		spellEffect = newEffect;
		spellDuration = newDuration;
		spellDescription = newDescription;
		price = newPrice;
		held = newHeld;
	}
}


