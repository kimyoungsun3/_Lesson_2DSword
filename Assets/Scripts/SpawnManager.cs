using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public class SpawnData{
		public int index;
		public ItemClick scpLeft, scpRight;

		public SpawnData(int _index, ItemClick _sl, ItemClick _sr){
			index 		= _index;
			scpLeft 	= _sl;
			scpRight 	= _sr;
		}

		public void Move(){
			scpLeft.MoveDown ();
			scpRight.MoveDown ();
		}
	}

	public static SpawnManager ins;
	public ItemClick prefabClick, prefabPass;
	public Transform spawnPoint1, spawnPoint2, spawnGroup;

	public List<SpawnData> list = new List<SpawnData>();
	public int COUNT = 10;
	void Awake(){
		ins = this;
	}


	public void CreateItemClick(){
		list.Clear ();

		int _rand;
		ItemClick _scp1 = null, _scp2 = null;
		SpawnData _data;
		for (int i = 0; i < COUNT; i++) {
			//_rand = Random.Range (0, 2);
			_rand = i % 2;
			if (_rand == 0) {
				_scp1 = Instantiate (prefabClick, spawnPoint1.position, spawnPoint1.rotation) as ItemClick;
				_scp2 = Instantiate (prefabPass, spawnPoint2.position, spawnPoint2.rotation) as ItemClick;
			} else {
				_scp1 = Instantiate (prefabPass, spawnPoint2.position, spawnPoint2.rotation) as ItemClick;
				_scp2 = Instantiate (prefabClick, spawnPoint1.position, spawnPoint1.rotation) as ItemClick;
			}
			_scp1.transform.SetParent (spawnGroup);
			_scp2.transform.SetParent (spawnGroup);
			//_scp1.name = i.ToString () + _rand.ToString ();
			//_scp2.name = i.ToString () + _rand.ToString ();

			_data = new SpawnData (i, _scp1, _scp2);
			list.Add (_data);
			MoveItemClick ();
		}
	}

	public void MoveItemClick(){
		for (int i = 0; i < list.Count; i++)
			list [i].Move ();
	}

}
