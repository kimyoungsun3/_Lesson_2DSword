using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBottomMenu : UiMaster {
	public static UiBottomMenu ins {get; set;}
	public UISlider uiSlider;
	public float hpValue;
	float hpSpeed;
	float HP_MAX = 100f;
	float HP_TIME = 5f;
	float HP_SUCCESS = 10f;
	float HP_FAIL = 30f;
	public int successCount = 0;
	public ParticleSystem successEffect;
	public Transform spawnPointL, spawnPointR, spawnEnd;

	void Awake(){
		ins = this;
	}

	void Start(){
		body.SetActive (false);
		hpSpeed = HP_MAX / HP_TIME;
	}

	//--------------------------------------
	public void InitAndVisible(bool _visible){
		if (_visible) {
			hpValue = HP_MAX;
			successCount = 0;
		}
		body.SetActive (_visible);
	}

	//--------------------------------------
	public void OnUpdate(){
		hpValue -= hpSpeed * Time.deltaTime;
		float _gauge = 0f;
		if (hpValue > 0f) {
			_gauge =  hpValue / HP_MAX;
		}
		uiSlider.value = _gauge;
	}

	public void CheckHP(bool _bSuccess, Transform _spawn){
		//성공과 실패에 따른 HP증가. 횟수
		if (_bSuccess) {
			successCount++;
			hpValue += HP_SUCCESS;
			ParticleSystem _p = Instantiate (successEffect, _spawn.position, _spawn.rotation);
			_p.GetComponent<SuccessEffect> ().Co_MoveToward (spawnEnd.position, 1.5f);
		} else {
			hpValue -= HP_FAIL;
		}

		if (hpValue > HP_MAX) {
			hpValue = HP_MAX;
		} else if (hpValue < 0f) {
			hpValue = 0f;
		}
	}

	public void InvokeLeftBtn(){
		Debug.Log ("InvokeLeftBtn Click");
		bool _state = SpawnManager.ins.ClickItemBall (ItemBallDir.Left);
		CheckHP (_state, spawnPointL);
	}

	public void InvokeRightBtn(){
		Debug.Log ("InvokeRightBtn Click");
		bool _state = SpawnManager.ins.ClickItemBall (ItemBallDir.Right);
		CheckHP (_state, spawnPointR);
	}


	//--------------------------------------
	public void InvokeShowItemList(){
		UiItemList.ins.InvokeShow ();
	}

	//public override void InvokeHide(){
	//	//base.InvokeHide ();
	//}
}


