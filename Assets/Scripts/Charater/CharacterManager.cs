using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterManager : MonoBehaviour {
	[SerializeField]
	PlayerManager playerManager;

	[SerializeField]
	CharacterView characterView;

	void Start()
	{
		playerManager.HasGameObject.ObserveEveryValueChanged(x => x.Value.gameObject.tag).Subscribe(x =>
		{
			string Message = "";
			switch(x)
			{
				case "cola":
					Message = "魚もコーラ好きなのかな";
					break;
				case "fryingpan":
					Message = "料理につかいそうだね";
					break;
				case "mentos":
					Message = "";
					break;
				case "corn":
					Message = "お腹がすいてきちゃった";
					break;
				case "coin":
					Message = "お金って大事だよね";
					break;
			}
			characterView.ChangeViewText(Message);
		});
 	}
}
