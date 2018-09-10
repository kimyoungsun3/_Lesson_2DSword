using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour {

	//void OnMouseDown(){
	//
	//}

	//void OnPress

	void OnPress (bool _bDown){
		Debug.Log (_bDown);
		OnDestroy ();
	}

	void OnClick(){
		//On
	}

	void OnDestroy(){
		gameObject.SetActive (false);
	}
}
