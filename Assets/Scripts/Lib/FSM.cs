using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void VOID_FUN_VOID();

public class FSMData<T>{
	T state;
	public VOID_FUN_VOID onIn;
	public VOID_FUN_VOID onModify;
	public VOID_FUN_VOID onOut;

	public FSMData(T _state, VOID_FUN_VOID _onIn,  VOID_FUN_VOID _onModify, VOID_FUN_VOID _onOut){ 
		state 	= _state;
		onIn 	= _onIn;
		onModify = _onModify;
		onOut 	= _onOut;
	}
}

public class FSM<T> : MonoBehaviour {
	protected Dictionary<T, FSMData<T>> dicState = new Dictionary<T, FSMData<T>>();
	protected T befState = default(T);
	protected T curState = default(T);
	protected T nextState = default(T);
	public VOID_FUN_VOID onIn;
	public VOID_FUN_VOID onModify;
	public VOID_FUN_VOID onOut; 

	protected void InitState(T _t){
		curState = _t;
	}

	protected void AddState(T _state, VOID_FUN_VOID _onIn,  VOID_FUN_VOID _onModify, VOID_FUN_VOID _onOut){
		if (!dicState.ContainsKey (_state)) {
			//add
			//Debug.Log(_onIn + ":" + _onModify + ":" + _onOut);
			FSMData<T> _data = new FSMData<T>(_state, _onIn, _onModify, _onOut);
			dicState.Add (_state, _data);		
		} else {
			Debug.LogError ("Same State Add Error" + _state);
		}
	}

	protected void ChangeState(T _state){
		if (!dicState.ContainsKey (_state)) {
			Debug.LogError (" Not Found State Change and Check state");
			return;
		}

		//before state information is clear;
		if (onOut != null) {
			onOut ();
		}

		//change state
		befState = curState;
		curState = _state;
		nextState = _state;
		FSMData<T> _data = dicState[curState];
		onIn 		= _data.onIn;
		onModify 	= _data.onModify;
		onOut 		= _data.onOut;

		//init data
		if (onIn != null) {
			onIn ();
		}
	}

	void Update () {
		if (onModify != null) {
			onModify ();
		}
	}
}
