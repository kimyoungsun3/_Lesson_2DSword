using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour {

	void OnPress (bool _bDown){
		Debug.Log (_bDown);
		OnDestroy ();
	}

	void OnDestroy(){
		gameObject.SetActive (false);
	}
}
