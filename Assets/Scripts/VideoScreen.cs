using UnityEngine;
using System.Collections;

public class VideoScreen : MonoBehaviour {
	public MovieTexture loadedTexture;
	public AudioClip clip;
	public AudioSource audio;

	public BigScreen screen;

	// Use this for initialization
	void Start () {
		screen = GameObject.Find("Big Screen").GetComponent<BigScreen>();
		GetComponent<Renderer> ().material.mainTexture = loadedTexture;
		//loadedTexture.audioClip.preloadAudioData = true;
		loadedTexture.Play ();
		loadedTexture.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load_image() {
		screen.setTexture (loadedTexture, audio);
	}

	public void preload_audio() {
		audio.clip = clip;
		audio.clip.LoadAudioData();
		audio.volume = 0.0f;
		audio.enabled = true;
		audio.Play ();
		//screen.preload_audio (loadedTexture);
	}
}
