using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	public TextMeshProUGUI ScoreField;
	public TextMeshProUGUI IGCField;
	public FloatFadeText FloatTextEffectPrefab;
	public float ScrollMargins;

	public GameObject GameStartScreen;
	public GameObject GameOverScreen;
	public float MenuFadeSpeed;

	[HideInInspector]
	public bool IsRunning = false;

	private AudioSource _audio;
	private float _currentScrollValue;
	private int _score = 0;
	private int _scoreMultiplier = 1;
	private int _igc = 0;

	private void Awake () {
		if (Instance == null)
			Instance = this;

		_audio = GetComponent<AudioSource> ();
		_igc = PlayerPrefs.GetInt ("igc");
	}

	private void Start() {
		AutoStart g = FindObjectOfType<AutoStart> ();
		if (g != null) {
			Destroy (g.gameObject);
			GameStartScreen.SetActive (false);
			StartGame ();
		}
	}

	private void Update() {
		if (OnHold ())
			UpdateScroll ();
	}

	private void UpdateScroll() {
		float p = Input.mousePosition.x / Screen.width;
		p -= ScrollMargins;
		p /= (1f - (ScrollMargins * 2));
		_currentScrollValue = Mathf.Max(Mathf.Min(p, 1.0f), 0.0f);
	}

	public void PlaySound(AudioClip c) {
		_audio.PlayOneShot (c);
	}

	public void EndGame() {
		PlayerPrefs.SetInt ("igc", _igc);

		if (PlayerPrefs.HasKey ("high-score")) {
			if (_score > PlayerPrefs.GetInt ("high-score")) {
				PlayerPrefs.SetInt ("high-score", _score);
			}
		} else {
			PlayerPrefs.SetInt ("high-score", _score);
		}
		GameOverScreen.SetActive (true);

	}

	public void StartGame() {
		IsRunning = true;
		Invoke ("EndGame", 1f);
	}

	public bool IsPlaying() {
		return Time.timeScale > 0f;
	}

	public bool OnTap() {
		return Input.GetMouseButtonDown (0);
	}

	public bool OnRelease() {
		return Input.GetMouseButtonUp (0);
	}

	public bool OnHold() {
		return Input.GetMouseButton (0);
	}

	public float GetScroll() {
		return _currentScrollValue;
	}

	public Vector2 GetInputPosition() {
		return Camera.main.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * Camera.main.orthographicSize);
	}

	public void SetScore(int i) {
		_score = i;
		ScoreField.text = "" + _score;
	}

	public void IncrementScore(int i) {
		SetScore (_score + (i*_scoreMultiplier));
	}

	public int GetScore() {
		return _score;
	}

	public void SetMultiplier(int i) {
		_scoreMultiplier = i;
	}

	public void SetIGC(int i) {
		_igc = i;
		IGCField.text = "" + _igc;
	}

	public void IncrementIGC(int i) {
		SetIGC (_igc + i);
	}

	public int GetIGC() {
		return _igc;
	}

	public void FloatTextEffect(string s, Vector3 worldPos) {
		FloatFadeText f = Instantiate (FloatTextEffectPrefab, transform);
		f.SetText (s);
		f.SetWorldPosition (worldPos);
	}

}
