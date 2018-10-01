using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessEffect : MonoBehaviour {
	public void Co_MoveToward(Vector3 _end, float _moveTime){
		StartCoroutine (CoMoveToward (_end, _moveTime));	
	}

	IEnumerator CoMoveToward(Vector3 _end, float _moveTime){
		Vector3 _start = transform.position;
		float _speed = 1f / _moveTime;
		float _interval = 0f;

		while(_interval < 1f){
			_interval += _speed * Time.deltaTime;
			transform.position = Vector3.Lerp (_start, _end, _interval);
			yield return null;
		}

		Destroy (gameObject);
	}
}
