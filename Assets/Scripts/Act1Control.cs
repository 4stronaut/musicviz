using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act1Control : MonoBehaviour {

	public Image background;
	public LensFlare flarelight;
	public GameObject bells;

	public GameObject hearts;


	// Use this for initialization
	enum Actstate{
		START,
		BELLS,
		FLIRT,
		LOVE
	}

	private Actstate _state = Actstate.START;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			switch(_state){
				case Actstate.START:
					bells.SetActive(true);
					background.GetComponent<ImageColorBlender>().BlendColor(Color.white);
					_state = Actstate.BELLS;
				break;
				case Actstate.BELLS:
					bells.SetActive(false);
					hearts.SetActive(true);
					background.GetComponent<ImageColorBlender>().BlendColor(new Color(1f,.627f,.705f));
					_state = Actstate.FLIRT;
				break;
				default:
					bells.SetActive(false);
					hearts.SetActive(false);
					background.GetComponent<ImageColorBlender>().BlendColor(Color.black);
					_state = Actstate.START;
				break;
			}
		}
		
	}
}
