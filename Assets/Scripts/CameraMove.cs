using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	
	private Vector3 _startpos;
	private Vector3 _lastTarget;
	private Vector3 _currentTarget;
	public AnimationCurve transition;

	private float _currentInterval = 0f;

	public float changeInterval = 1f;

	// Use this for initialization
	void Start () {
		_startpos = transform.position;
		_lastTarget = _startpos;
		_currentTarget = _startpos;
	}
	
	// Update is called once per frame
	void Update () {
		_currentInterval+= Time.deltaTime;
		if(_currentInterval>changeInterval){
			_lastTarget = transform.position;
			_currentTarget = _startpos + Random.insideUnitSphere*3f;
			_currentInterval = 0f;
		}
		transform.position = Vector3.Lerp(_lastTarget,_currentTarget,transition.Evaluate(_currentInterval/changeInterval));
	}
}
