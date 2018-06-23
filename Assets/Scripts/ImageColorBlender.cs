using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorBlender : MonoBehaviour {

	public float blendTime = 1f;
	public AnimationCurve blendCurve = AnimationCurve.EaseInOut(0f,0f,1f,1f);
	
	private Image _myImg;
	private Color _lastColor;
	private Color _targetColor;
	private bool _blending = false;
	private float _timer = 0f;

	public void BlendColor(Color c){
		_lastColor = _myImg.color;
		_targetColor = c;
		_timer = 0f;
		_blending = true;	
	}

	void Start () {
		_myImg = GetComponent<Image>();
		if(!_myImg)Destroy(this);
	}

	void Update () {
		if(_blending){
			_timer+=Time.deltaTime;
			if(_timer <= blendTime){
				Debug.Log("COLOR BLEND");
				_myImg.color = Color.Lerp(_lastColor,_targetColor,blendCurve.Evaluate(_timer/blendTime));
			}else{
				_myImg.color = _targetColor;
				_blending = false;
			}
		}
	}
}
