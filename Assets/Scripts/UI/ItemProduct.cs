using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProduct : MonoBehaviour {

	public UILabel uiName;
	public UISprite uiSprite;

	public void InvokeSetInfo(string _name, string _itemName){
		uiName.text = _name;
		uiSprite.spriteName = _itemName;
	}
}
