using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiItemList : UiMaster {
	public static UiItemList ins {get; set;}
	public GameObject prefab;
	public UIScrollView uiScrollView;
	public UIGrid uiGrid;
	public Transform transRoot;

	public List<ItemProduct> list = new List<ItemProduct> ();

	void Awake(){
		ins = this;
	}

	void Start(){
		GameObject _go;
		ItemProduct _scp;
		for (int i = 0; i < 10; i++) {
			_go = Instantiate (prefab, Vector3.zero, Quaternion.identity);
			_go.transform.SetParent (transRoot);
			_scp = _go.GetComponent<ItemProduct> ();
			if (_scp != null) {
				_scp.InvokeSetInfo ("Sword" + (i+1), "sword_" + (i+1));
				list.Add (_scp);			
			}
		}

		DestroyImmediate (prefab);
	}
}
