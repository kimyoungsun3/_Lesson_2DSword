using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGaming : UiMaster {
	public static UiGaming ins; 
	void Awake(){
		ins = this;
		gameObject.SetActive (false);
	}

}
