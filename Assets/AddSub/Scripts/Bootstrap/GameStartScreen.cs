﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartScreen : MonoBehaviour {

	public TextMeshProUGUI HighScoreField;
	public Animator TapToStart;

	void Start () {
		TapToStart.SetTrigger ("breath");
		if (PlayerPrefs.HasKey ("high-score"))
			HighScoreField.text = "" + PlayerPrefs.GetInt ("high-score");
		else
			HighScoreField.text = "0";

		StartCoroutine (Open ());
	}

	public void BGTap() {
		StartCoroutine (Startup());
	}

	private IEnumerator Startup() {
		TapToStart.SetTrigger ("shrink");
		Image[] images = GetComponentsInChildren<Image> ();
		TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI> ();
		while (images [0].color.a > 0f) {
			foreach (Image i in images) {
				if (i.tag != "transparent")
					i.color -= new Color (0, 0, 0, Time.deltaTime * GameController.Instance.MenuFadeSpeed);
			}
			foreach (TextMeshProUGUI t in texts) {
				t.color -= new Color (0, 0, 0, Time.deltaTime * GameController.Instance.MenuFadeSpeed);
			}
			yield return null;
		}
		GameController.Instance.StartGame ();
		Destroy (gameObject);
	}

	private IEnumerator Open() {
		Image[] images = GetComponentsInChildren<Image> ();
		TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI> ();
		foreach (Image i in images) {
			if (i.tag != "transparent")
				i.color = new Color (i.color.r, i.color.g, i.color.b, 0);
		}
		foreach (TextMeshProUGUI i in texts) {
			i.color = new Color (i.color.r, i.color.g, i.color.b, 0);
		}
		while (images [0].color.a < 1f) {
			foreach (Image i in images) {
				if (i.tag != "transparent")
					i.color += new Color (0, 0, 0, Time.deltaTime * GameController.Instance.MenuFadeSpeed);
			}
			foreach (TextMeshProUGUI t in texts) {
				t.color += new Color (0, 0, 0, Time.deltaTime * GameController.Instance.MenuFadeSpeed);
			}
			yield return null;
		}
		foreach (Image i in images) {
			if (i.tag != "transparent")
				i.color = new Color (i.color.r, i.color.g, i.color.b, 1);
		}
		foreach (TextMeshProUGUI i in texts) {
			i.color = new Color (i.color.r, i.color.g, i.color.b, 1);
		}
	}


}
