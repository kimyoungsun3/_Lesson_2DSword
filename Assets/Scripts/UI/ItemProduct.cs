using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProduct : MonoBehaviour {

	public UILabel uiName;
	public UISprite uiSprite;
	VOID_FUN_STRING callbackStr;


	public void InitInfo(string _name, string _itemName, VOID_FUN_STRING _cb){
		uiName.text = _name;
		uiSprite.spriteName = _itemName;
		callbackStr = _cb;
	}

	public void InvokeClickItem(){
		if (callbackStr != null) {
			callbackStr (uiName.text);
		}
	}
}
