using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMaster : MonoBehaviour {
	public GameObject body;

	public virtual void InvokeShow(){
		body.SetActive (true);
	}

	public virtual void InvokeHide(){
		body.SetActive (false);
	}

}
