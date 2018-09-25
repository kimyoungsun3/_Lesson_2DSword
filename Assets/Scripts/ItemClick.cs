using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour {
	public float distance = 50f;
	public void MoveDown(){
		transform.position += Vector3.down * distance;
	} 

	//void OnPress (bool _bDown){
	//	Debug.Log (_bDown);
	//	OnDestroy ();
	//}

	//void OnDestroy(){
	//	gameObject.SetActive (false);
	//}
}
