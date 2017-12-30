using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartScreen : MonoBehaviour {

	public GameObject NewBest;
	public GameObject PreviousScore;
	public TextMeshProUGUI PreviousScoreField;
	public GameObject HighScore;
	public TextMeshProUGUI HighScoreField;
	public TextMeshProUGUI IGCField;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		PreviousGameData data = FindObjectOfType<PreviousGameData> ();

		if (data != null) {
			PreviousScoreField.text = "" + data.Score;
			if (!data.NewBest)
				Destroy (NewBest);
		} else {
			Destroy (PreviousScore);
			Destroy (NewBest);
		}

		if (PlayerPrefs.HasKey ("high-score"))
			HighScoreField.text = "" + PlayerPrefs.GetInt ("high-score");
		else
			Destroy (HighScore);

		if (PlayerPrefs.HasKey ("igc"))
			IGCField.text = "" + PlayerPrefs.GetInt ("igc");
		else
			IGCField.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			StartCoroutine (Startup());
		}
	}

	private IEnumerator Startup() {
		yield return null;
		GameController.Instance.StartGame ();
		Destroy (gameObject);
	}
}
