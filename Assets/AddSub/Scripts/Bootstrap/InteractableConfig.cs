using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableConfig : MonoBehaviour {

	public static InteractableConfig Instance;

	[SerializeField, Tooltip("Register of interactables and all of their settings")]
	public InteractableInfo[] Interactables;

	public InteractableInfo GetInfo(string n) {
		foreach (InteractableInfo i in Interactables) {
			if (i.TriggerName == n)
				return i;
		}
		return null;
	}

	void Awake() {
		if (Instance == null)
			Instance = this;
	}

}

[System.Serializable]
public class InteractableInfo {
	public string TriggerName;
	public UnityEvent Event;
	public bool ShouldDestroy;
	public ParticleSystem OnTriggerParticles;
	public AudioClip OnTriggerAudio;
}
