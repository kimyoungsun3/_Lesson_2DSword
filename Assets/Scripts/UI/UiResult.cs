using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiResult : UiMaster {
	public static UiResult ins { get; private set; }

	void Awake(){
		ins = this;
	}

	void Start(){
		body.SetActive (false);
	}

	public void InvokeToReady(){		
		GameManager.ins.InvokeResultToReady ();
		body.SetActive (false);
	}
}
