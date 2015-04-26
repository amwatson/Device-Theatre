using UnityEngine;
using System.Collections;

public class VideoScreen : MonoBehaviour {
	public MovieTexture loadedTexture;
	public AudioSource audio;
	public float time = 0.0f;
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
		/*time += Time.deltaTime;
		if (time == 10) {
			loadedTexture.Stop ();
			loadedTexture = Resources.Load ("1", typeof(MovieTexture)) as MovieTexture;
			loadedTexture.Play ();
			print ("here");
		} else {
			print (time);
		}*/
	}

	public void load_image() {
		screen.setTexture (loadedTexture, audio);
	}

	public void preload_audio() {
		audio.clip = loadedTexture.audioClip;
		audio.clip.LoadAudioData();
		audio.volume = 0.0f;
		audio.enabled = true;
		audio.Play ();
	}

	public void disable_audio() {
		//audio.enabled = false;
	}
}
