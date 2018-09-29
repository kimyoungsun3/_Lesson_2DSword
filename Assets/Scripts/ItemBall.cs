using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBall : MonoBehaviour {
	//VOID_FUN_STRING callbackStr;
	public ItemBallKind kind;
	public float distance = 50f;
	public void MoveDown(){
		transform.position += Vector3.down * distance;
	} 

	public void InitInfo(ItemBallKind _kind){
		kind = _kind;
	}

	public bool CheckItemBall(){
		Debug.Log (this + ":" + kind);
		return kind == ItemBallKind.Sword;
	}

	//public void InitInfo(VOID_FUN_STRING _cb){
	//	callbackStr = _cb;
	//}

	//public void InvokeClickItem(){
	//	if (callbackStr != null) {
	//		callbackStr (uiName.text);
	//	}
	//}

	//public void InvokeName(string _strDir, int _idx){
	//	name += _strDir + _idx.ToString();
	//}

	//void OnPress (bool _bDown){
	//	Debug.Log (_bDown);
	//	OnDestroy ();
	//}

	//void OnDestroy(){
	//	gameObject.SetActive (false);
	//}
}
