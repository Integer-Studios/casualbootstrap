using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour {

	private Camera _camera;
	private Coroutine _coroutine;

	void Start() {
		_camera = GetComponent<Camera> ();
	}

	public void Flash(Color c, float speed) {
		if (_coroutine != null)
			StopCoroutine (_coroutine);
		_coroutine = StartCoroutine(Flash (_camera.backgroundColor, c,speed));
	}

	private IEnumerator Flash(Color initial, Color flash, float speed) {
		float p = 0f;
		while (p < 1f) {
			p += Time.deltaTime * speed;
			_camera.backgroundColor = new Color (Mathf.Lerp (initial.r, flash.r, p), Mathf.Lerp (initial.g, flash.g, p), Mathf.Lerp (initial.b, flash.b, p));
			yield return null;
		}
		while (p > 0f) {
			p -= Time.deltaTime * speed;
			_camera.backgroundColor = new Color (Mathf.Lerp (initial.r, flash.r, p), Mathf.Lerp (initial.g, flash.g, p), Mathf.Lerp (initial.b, flash.b, p));
			yield return null;
		}
		_camera.backgroundColor = initial;
		_coroutine = null;
	}
}
