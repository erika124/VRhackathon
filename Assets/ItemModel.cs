using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ItemModel : MonoBehaviour
{
	[SerializeField]
	private Button button;
	[SerializeField]
	private Text name;
	[SerializeField]
	private Text description;
	[SerializeField]
	private Sprite sprite;

	void Start()
	{
		Item item = GetComponent<Item>();
		name.text = item.name;
		description.text = item.description;
	}
}
