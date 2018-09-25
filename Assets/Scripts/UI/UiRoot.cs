using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiRoot : MonoBehaviour {
	public static UiRoot ins { get; private set; }

	void Awake(){
		ins = this;
	}

}
