using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateGame{
	Ready = 0, Gaming, Result
}
public class GameManager : MonoBehaviour {
	public Text text;
	StateGame state;
	int count;
	//public GameObject uiReady, uiGaming, uiResult;

	void Awake () {
		
	}

	void Start(){
		pInReady ();
	}

	//--------------------------
	void pInReady(){
		state = StateGame.Ready;
		text.text = "Ready";
		UiReady.ins.InvokeVisible ();
	}

	void ModifyReady(){
		if (Input.GetMouseButtonDown(0)) {
			OutReady ();
			pInGaming ();
			return;
		}
		text.text = "Ready" + (count++).ToString();
	}

	void OutReady(){
		UiReady.ins.InvokeInVisible ();
	}

	//--------------------------
	void pInGaming(){
		state = StateGame.Gaming;
		text.text = "Gaming";
		count = 0;
		UiGaming.ins.InvokeVisible ();
	}

	void ModifyGaming(){
		if (Input.GetMouseButtonDown(0)) {
			pInResult ();
			return;
		}
		text.text = "Gaming" + (count++).ToString();
	}
	//--------------------------
	void pInResult(){
		state = StateGame.Result;
		text.text = "Result";
		count = 0;

		UiGaming.ins.InvokeInVisible ();
		UiResult.ins.InvokeVisible ();
	}

	void ModifyResult(){
		if (Input.GetMouseButtonDown(0)) {
			UiResult.ins.InvokeInVisible ();
			pInReady ();
			return;
		}
		text.text = "Result" + (count++).ToString();
	}


	// Update is called once per frame
	void Update () {
		switch (state) {
		case StateGame.Ready:
			ModifyReady ();
			break;
		case StateGame.Gaming:
			ModifyGaming ();
			break;
		case StateGame.Result:
			ModifyResult ();
			break;
		}
	}
}
