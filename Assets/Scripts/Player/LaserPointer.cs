using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private Transform Pointer {
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
	// private Vector3 dt = new Vector3(0, 0, 0);

	void Update () {



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
				// 	dt =  (hitInfo.transform.position - (pointer.position + pointer.forward) )/ 20.0f;
				// 	for(var i=0; i < 20; i++){
				// 		target_obj.transform.position +=  dt;
				// 	}
				hitInfo.transform.position = pointer.position + pointer.forward;
				target_obj = hitInfo.collider.gameObject;
				// hold_obj_tag = hitInfo.collider.tag;
				if(hold_flag) hold_flag = false;
				else hold_flag = true;
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
