using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiXxx : MonoBehaviour {
	public List<GameObject> list = new List<GameObject> ();
	public void InvokeVisible(){
		foreach (GameObject _go in list)
			_go.SetActive (true);
	}
}
