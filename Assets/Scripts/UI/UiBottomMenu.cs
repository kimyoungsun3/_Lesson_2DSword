using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBottomMenu : UiMaster {
	public static UiBottomMenu ins {get; set;}

	void Awake(){
		ins = this;
	}

	//void Start(){
	//	body.SetActive (false);
	//}

	public void InvokeLeftBtn(){
		Debug.Log ("InvokeLeftBtn Click");
		SpawnManager.ins.ClickItemBall (ItemBallDir.Left);
	}

	public void InvokeRightBtn(){
		Debug.Log ("InvokeRightBtn Click");
		SpawnManager.ins.ClickItemBall (ItemBallDir.Right);
	}

	public void InvokeShowItemList(){
		UiItemList.ins.InvokeShow ();
	}

	//public override void InvokeHide(){
	//	//base.InvokeHide ();
	//}
}


