using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationHelper : MonoBehaviour {

	public float Opacity = 1;

	private TextMeshProUGUI _text;
	private float _curOpacity = 1;

	// Use this for initialization
	void Start () {
		_text = GetComponent<TextMeshProUGUI> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (Opacity - _curOpacity) > 0.005f) {
			UpdateOpacity ();
		}
	}

	private void UpdateOpacity() {
		_curOpacity = Opacity;
		_text.color = new Color (_text.color.r, _text.color.g, _text.color.b, _curOpacity);
	}
}
