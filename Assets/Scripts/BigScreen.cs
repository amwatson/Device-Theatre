using UnityEngine;
using System.Collections;

public class BigScreen : MonoBehaviour {
	public AudioSource Source;
	public AudioSource Source_Temp;
	public Timer time;

	// Use this for initialization
	void Start () {
		Source.enabled = true;
		Application.targetFrameRate = 80;
		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setTexture(MovieTexture T, AudioSource audio) {
		GetComponent<Renderer> ().material.mainTexture = T;
		//T.loop = true;
		if (Source != null) {
			Source.enabled = false;
		}
		Source = audio;
		//Source.clip.LoadAudioData();

		Source.volume = .2f;
		T.Play ();



	}

	public void preload_audio(MovieTexture texture) {


	}
}
