using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatFadeText : MonoBehaviour {

	public float FadeSpeed = 1f;
	public float FloatSpeed = 100f;

	private TextMeshProUGUI _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<TextMeshProUGUI> ();
		StartCoroutine(Fade());
	}

	void Update() {
		transform.position += Vector3.up * (FloatSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	IEnumerator Fade () {
		while (_text.color.a > 0f) {
			_text.color -= new Color (0, 0, 0, FadeSpeed * Time.deltaTime);
			yield return null;
		}
		Destroy (gameObject);
	}

	public void SetWorldPosition(Vector3 v) {
		transform.position = Camera.main.WorldToScreenPoint (v);
	}

	public void SetText(string s) {
		_text = GetComponent<TextMeshProUGUI> ();
		_text.text = s;
	}
}
