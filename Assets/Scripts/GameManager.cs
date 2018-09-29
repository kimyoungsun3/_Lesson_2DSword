﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : FSM<GameManager.StateGame> {
	public static GameManager ins { get; private set; }
	public enum StateGame{
		None, Ready, Gaming, Result
	}


	void Awake(){
		ins = this;
	}

	IEnumerator Start(){
		//1. File Read, Data File Ready
		//yield return null...
		Debug.Log ("File Loading and Prefab Create");
		yield return null;

		//2. State Setting
		AddState (StateGame.Ready, 		pInReady, 	null, 	null);
		AddState (StateGame.Gaming, 	pInGaming, 	ModifyGaming, 	null);
		AddState (StateGame.Result, 	pInResult, 	null, 	null);

		//3. Ready 상태로 변경...
		yield return null;
		ChangeState(StateGame.Ready);
	}

	//--------------------------
	void pInReady(){
		UiReady.ins.InvokeShow ();
		UiBottomMenu.ins.InvokeShow ();
	}

	public void InvokeReadyToGaming(){
		ChangeState(StateGame.Gaming);
	}	

	//--------------------------
	void pInGaming(){
		Debug.Log ("게임에 필요한 데이타 로딩세팅");
		SpawnManager.ins.CreateItemBallAll ();
	}

	void ModifyGaming(){
		//if (Input.GetMouseButtonDown(0)) {
		//	ChangeState(StateGame.Result);
		//	return;
		//}
	}
	//--------------------------
	void pInResult(){
		Debug.Log ("게임완료 > 결과 출력.");		
		UiResult.ins.InvokeShow ();
	}

	public void InvokeResultToReady(){
		ChangeState(StateGame.Ready);
	}	


}
