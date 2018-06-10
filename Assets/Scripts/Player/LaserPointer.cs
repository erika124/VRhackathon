using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/**
* レーザーポインターを出すクラス
*/
public class LaserPointer : MonoBehaviour {


	[SerializeField]
	private Transform _RightHandAnchor; // 右手

	[SerializeField]
	private Transform _LeftHandAnchor;  // 左手

	[SerializeField]
	private Transform _CenterEyeAnchor; // 目の中心

	[SerializeField]
	private float _MaxDistance = 100.0f; // 距離

	[SerializeField]
	private LineRenderer _LaserPointerRenderer; // LineRenderer

	// コントローラー
	public Transform Pointer {
		get {
			// 現在アクティブなコントローラーを取得
			var controller = OVRInput.GetActiveController();
			if (controller == OVRInput.Controller.RTrackedRemote) {
				return _RightHandAnchor;
			} else if (controller == OVRInput.Controller.LTrackedRemote) {
				return _LeftHandAnchor;
			}
			// どちらも取れなければ目の間からビームが出る
			return _CenterEyeAnchor;
		}
	}

	public GameObject player;
	bool hold_flag = false;
	private GameObject target_obj;
	string hold_obj_tag;
	public CharacterManager characterManager;
	public CanvasGroup canvasGroup;
	public CanvasGroup CharacterCanvasGroup;
	bool fadeIn = true;
	// private Vector3 dt = new Vector3(0, 0, 0);

	void Update () {

		if (OVRInput.GetDown(OVRInput.Button.Two)){
			if(fadeIn)
			{
				canvasGroup.DOFade(1,1);
				fadeIn = false;
			}
			else
			{
				canvasGroup.DOFade(0,1);
				fadeIn = true;
			}
		}

		var pointer = Pointer; // コントローラーを取得
		// コントローラーがない or LineRendererがなければ何もしない
		if (pointer == null || _LaserPointerRenderer == null) {
			return;
		}
		// コントローラー位置からRayを飛ばす
		Ray pointerRay = new Ray(pointer.position, pointer.forward);

		// レーザーの起点
		_LaserPointerRenderer.SetPosition(0, pointerRay.origin);

		RaycastHit hitInfo;

		if (Physics.Raycast(pointerRay, out hitInfo, _MaxDistance)) {
			// Rayがヒットしたらそこまで
			_LaserPointerRenderer.SetPosition(1, hitInfo.point);
			if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
				if(hitInfo.collider.tag == "Character")
				{
					CharacterCanvasGroup.DOFade(1,1);
				}
				else
				{
					hitInfo.transform.position = pointer.position + pointer.forward;
					target_obj = hitInfo.collider.gameObject;
					if(hold_flag) hold_flag = false;
					else hold_flag = true;
				}
			}
		} else {
			// Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
			_LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MaxDistance);
		}

		if(hold_flag){
			target_obj.transform.position = pointer.position + pointer.forward ;
		}
	}
}
