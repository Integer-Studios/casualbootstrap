using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScreen : MonoBehaviour {

	public GameObject NewBestPrefab;
	public GameObject PreviousScore;
	public Text PreviousScoreField;
	public GameObject HighScore;
	public Text HighScoreField;

	// Use this for initialization
	void Start () {
		PreviousGameData data = FindObjectOfType<PreviousGameData> ();

		if (data != null) {
			PreviousScoreField.text = "" + data.Score;
			if (data.NewBest)
				Instantiate (NewBestPrefab, transform);
		} else {
			Destroy (PreviousScore);
		}

		if (PlayerPrefs.HasKey ("high-score"))
			HighScoreField.text = "" + PlayerPrefs.GetInt ("high-score");
		else
			Destroy (HighScore);
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
