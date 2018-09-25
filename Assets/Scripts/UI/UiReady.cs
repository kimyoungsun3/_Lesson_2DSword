using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiReady : UiMaster {
	public static UiReady ins { get; private set; }

	void Awake(){
		ins = this;
	}

	//void Start(){
	//	body.SetActive (false);
	//}

	public void InvokeToGaming(){		
		GameManager.ins.InvokeReadyToGaming ();
		body.SetActive (false);
	}
}
