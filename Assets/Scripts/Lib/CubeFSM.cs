using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFSM : FSM<CubeFSM.StateGame> {
	public enum StateGame{
		None, Idle, Move
	}
	float nextTime;
	public float NEXT_TIME = 1f;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		AddState(StateGame.Idle, Init_Idle, Modify_Idle, null);
		AddState(StateGame.Move, Init_Move, Modify_Move, null);

		ChangeState (StateGame.Idle);
	}

	#region Idle State
	//idle
	void Init_Idle(){
		nextTime = Time.time + NEXT_TIME;
	}

	void Modify_Idle(){
		if (Time.time > nextTime) {
			ChangeState (StateGame.Move);
		}
	}
	#endregion

	#region Move State
	//idle
	void Init_Move(){
		nextTime = Time.time + NEXT_TIME;
	}

	void Modify_Move(){
		if (Time.time > nextTime) {
			ChangeState (StateGame.Idle);
			return;
		}

		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
	#endregion
}
