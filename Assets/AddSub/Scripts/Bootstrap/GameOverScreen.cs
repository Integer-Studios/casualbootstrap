using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

	public TextMeshProUGUI HighScoreField1;
	public TextMeshProUGUI HighScoreField2;
	public TextMeshProUGUI PrevScoreField;

	void OnEnable () {
		if (PlayerPrefs.HasKey ("high-score")) {
			HighScoreField1.text = "" + PlayerPrefs.GetInt ("high-score");
			HighScoreField2.text = "BEST " + PlayerPrefs.GetInt ("high-score");
		} else {
			HighScoreField1.text = "0";
			HighScoreField2.text = "BEST 0";
		}
		PrevScoreField.text = ""+GameController.Instance.GetScore ();
		StartCoroutine (Open ());
	}

	public void Restart() {
		GameObject g = new GameObject ("autostart");
		DontDestroyOnLoad (g);		
		g.AddComponent<AutoStart> ();
		StartCoroutine (Close ());
	}

	public void Home() {
		StartCoroutine (Close ());
	}

	private IEnumerator Close() {
		Image[] images = GetComponentsInChildren<Image> ();
		TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI> ();
		while (images [0].color.a > 0f) {
			foreach (Image i in images) {
				i.color -= new Color (0, 0, 0, Time.deltaTime * GameController.Instance.MenuFadeSpeed);
			}
			foreach (TextMeshProUGUI t in texts) {
				t.color -= new Color (0, 0, 0, Time.deltaTime * GameController.Instance.MenuFadeSpeed);
			}
			yield return null;
		}
		Destroy (gameObject);
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
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
