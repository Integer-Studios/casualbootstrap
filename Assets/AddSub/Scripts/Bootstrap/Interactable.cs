using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	private InteractableConfig _config;
	private InteractableInfo _info;

	void Start() {
		_config = InteractableConfig.Instance;
		_info = _config.GetInfo(gameObject.tag);
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "character")
			OnTrigger ();
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "character")
			OnTrigger ();
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "character")
			OnTrigger ();
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "character")
			OnTrigger ();
	}

	void OnTrigger() {
		if (_info.Event != null)
			_info.Event.Invoke ();
		if (_info.ShouldDestroy)
			Destroy (gameObject);
		if (_info.OnTriggerParticles != null)
			Instantiate (_info.OnTriggerParticles, transform.position, Quaternion.identity);
		if (_info.OnTriggerAudio != null)
			GameController.Instance.PlaySound (_info.OnTriggerAudio);
	}

}
