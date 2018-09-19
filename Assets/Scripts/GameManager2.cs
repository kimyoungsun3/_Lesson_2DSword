using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : FSM<GameManager2.StateGame> {
	public enum StateGame{
		None, Ready, Gaming, Result
	}
	public Text text;
	StateGame state;
	int count;

	void Start(){
		AddState (StateGame.Ready, pInReady, ModifyReady, OutReady);
		AddState (StateGame.Gaming, pInGaming, ModifyGaming, null);
		AddState (StateGame.Result, pInResult, ModifyResult, null);
		//InitState(StateGame.
		ChangeState(StateGame.Ready);
	}

	//--------------------------
	void pInReady(){
		text.text = "Ready";
		UiReady.ins.InvokeVisible ();
	}

	void ModifyReady(){
		if (Input.GetMouseButtonDown(0)) {
			UiReady.ins.InvokeInVisible ();
			ChangeState(StateGame.Gaming);
			return;
		}
		text.text = "Ready" + (count++).ToString();
	}

	void OutReady(){
		Debug.Log ("OutReady");
	}

	//--------------------------
	void pInGaming(){
		text.text = "Gaming";
		count = 0;
		UiGaming.ins.InvokeVisible ();
	}

	void ModifyGaming(){
		if (Input.GetMouseButtonDown(0)) {
			ChangeState(StateGame.Result);
			return;
		}
		text.text = "Gaming" + (count++).ToString();
	}
	//--------------------------
	void pInResult(){
		text.text = "Result";
		count = 0;

		UiGaming.ins.InvokeInVisible ();
		UiResult.ins.InvokeVisible ();
	}

	void ModifyResult(){
		if (Input.GetMouseButtonDown(0)) {
			UiResult.ins.InvokeInVisible ();
			ChangeState(StateGame.Ready);
			return;
		}
		text.text = "Result" + (count++).ToString();
	}


}
