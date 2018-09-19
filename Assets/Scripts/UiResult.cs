using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiResult : MonoBehaviour {
	public static UiResult ins; 
	void Awake(){
		ins = this;
		gameObject.SetActive (false);
	}

	public void InvokeVisible(){
		gameObject.SetActive (true);
	}
	public void InvokeInVisible(){
		gameObject.SetActive (false);
	}
}
