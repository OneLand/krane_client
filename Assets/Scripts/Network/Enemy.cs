using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public  class Enemy
{
	[SerializeField]
	string name;
	[SerializeField]
	List < string > skills;

	public Enemy ( string name, List<string> skills)
	{
		this .name = name;
		this .skills = skills;
	}
}