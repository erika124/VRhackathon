using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ItemModel : MonoBehaviour
{
	public Button button;
	[SerializeField]
	public Text name;
	[SerializeField]
	private Text description;
	[SerializeField]
	//private Sprite sprite;

	void Start()
	{
		Item item = GetComponent<Item>();
		name.text = item.name;
		description.text = item.description;
	}

	public string GetName()
	{
		return GetComponent<Item>().name;
	}
}
