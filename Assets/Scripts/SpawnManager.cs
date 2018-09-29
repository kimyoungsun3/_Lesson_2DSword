using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public class SpawnData{
		public int index;
		public ItemBall left, right;

		public SpawnData(int _index, ItemBall _sl, ItemBall _sr){
			index 		= _index;
			left 		= _sl;
			right 		= _sr;
		}

		public void Move(){
			left.MoveDown ();
			right.MoveDown ();
		}
	}

	public static SpawnManager ins;
	public ItemBall prefabSword, prefabSkull;
	public Transform spawnPoint1, spawnPoint2, spawnGroup;

	public List<SpawnData> list = new List<SpawnData>();
	public int COUNT = 10;
	public int cursorIndex = 0;
	void Awake(){
		ins = this;
	}


	public void CreateItemBallAll(){
		//1. list data clear
		list.Clear ();
		cursorIndex = 0;

		//2. create itemball
		for (int i = 0; i < COUNT; i++) {
			CreateItemBallOne (i);
		}
	}

	public void CreateItemBallOne(int _idx){
		cursorIndex = _idx;

		ItemBall _prefab1, _prefab2;
		ItemBall _scp1 = null, _scp2 = null;
		ItemBallKind _s1, _s2;
		int _rand = Random.Range (0, 2);
		if (_rand == 0) {
			_prefab1 = prefabSword;
			_prefab2 = prefabSkull;
			_s1 = ItemBallKind.Sword;
			_s2 = ItemBallKind.Skull;
		} else {
			_prefab1 = prefabSkull;
			_prefab2 = prefabSword;
			_s1 = ItemBallKind.Skull;
			_s2 = ItemBallKind.Sword;
		}
		_scp1 = Instantiate (_prefab1, spawnPoint1.position, Quaternion.identity) as ItemBall;
		_scp2 = Instantiate (_prefab2, spawnPoint2.position, Quaternion.identity) as ItemBall;
		_scp1.transform.SetParent (spawnGroup);
		_scp2.transform.SetParent (spawnGroup);
		_scp1.InitInfo (_s1);
		_scp2.InitInfo (_s2);

		SpawnData _data = new SpawnData (_idx, _scp1, _scp2);
		list.Add (_data);
		MoveItemClick ();
	}

	public void MoveItemClick(){
		for (int i = 0; i < list.Count; i++)
			list [i].Move ();
	}

	public void ClickItemBall(ItemBallDir _dir){
		//1. top data
		ItemBall _scp;
		if (_dir == ItemBallDir.Left) {
			_scp = list [0].left;
		} else {
			_scp = list [0].right;
		}

		//2. data compare 
		//   gameobject destroy
		if (_scp.CheckItemBall ()) {
			Debug.Log ("Success >");
		} else {
			Debug.Log ("Fail >");
		}

		//3. data destroy and new Data Input
		DestroyImmediate( list [0].left.gameObject);
		DestroyImmediate( list [0].right.gameObject);
		list.RemoveAt (0);

		//4. new Data Create
		CreateItemBallOne(cursorIndex++);
	}

	//public GameObject 	goBtnChange;
	//public void LinkEventListener ()
	//{
	//	UIEventListener.Get ( goBtnChange ).onPress = OnPress_Change;
	//	UIEventListener.Get ( goBtnChange ).onClick = OnClick_Change;
	//}
	//
	//private void OnPress_Change ( GameObject _go , bool _what )
	//{
	//}
	//private void OnClick_Change ( GameObject _go )
	//{
	//}
}
