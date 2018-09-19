using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGaming : MonoBehaviour {
	public static UiGaming ins; 
	void Awake(){
		ins = this;
		gameObject.SetActive (false);
	}

	//public void InitXXX(){
	//}

	public void InvokeVisible(){
		gameObject.SetActive (true);
	}
	public void InvokeInVisible(){
		gameObject.SetActive (false);
	}
}
