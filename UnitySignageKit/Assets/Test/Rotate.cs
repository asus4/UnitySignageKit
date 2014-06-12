using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	[SerializeField]
	Vector3 speed;
	
	Transform _transform;
	
	void Start() {
		_transform = transform;
	}
	
	void Update () {
		_transform.Rotate(speed);
	}
}
