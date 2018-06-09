using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
	public string name;
	public string description;

	void Init(string name, string description, Image image)
	{
		this.name = name;
		this.description = description;
	}
}