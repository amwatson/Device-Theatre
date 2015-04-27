using UnityEngine;
using System.Collections;

public class Rays : MonoBehaviour {
	public GameObject OVRCamera;

	public BigScreen screen;
	public GameObject heart;
	public GameObject fragments;
	public GameObject circle;
	public GameObject glow;
	VideoScreen ImagePlane = null;
	VideoScreen ImagePlane_cur = null;

	
	public int image_hits = 0;
	

	// Use this for initialization
	void Start () {
		heart = GameObject.Find ("heart");
		fragments = GameObject.Find ("fragments");
		circle = GameObject.Find ("circle");
		glow = GameObject.Find ("Holy Shine");

		disable ();

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		// TODO probs an alternative to a raycast every frame
		if (Physics.Raycast(OVRCamera.transform.position, OVRCamera.transform.forward, out hit, 150000.0F)) {


			transform.position = hit.point;
			Quaternion temp_rotation = hit.transform.rotation;
			transform.rotation = temp_rotation;
			transform.Rotate(90, 0, 0);

			if (ImagePlane_cur != null && hit.transform.gameObject.name == ImagePlane_cur.name) {
				image_hits++;
				if (image_hits > 150) {
					circle.GetComponent<Renderer> ().material.color = new Color(2.0F, .85F, .85F);
					fragments.SetActive(false);
					heart.GetComponent<Animation>().Stop();
				} else {
					enable_progress();
				}


				if (image_hits == 2 && hit.transform.gameObject.GetComponent<VideoScreen>().loadedTexture != screen.GetComponent<Renderer> ().material.mainTexture) {
					ImagePlane_cur.preload_audio();
				}

				if (image_hits == 150) {
					ImagePlane_cur.load_image();

				}

			} else {
				if (ImagePlane_cur != null && 
				    ImagePlane_cur.GetComponent<VideoScreen>().loadedTexture != 
				    screen.GetComponent<Renderer> ().material.mainTexture) {
					ImagePlane_cur.disable_audio();
				}
				ImagePlane_cur = hit.transform.gameObject.GetComponent<VideoScreen>();
				image_hits = 0;
				disable ();
			}

		}

	}


	void enable_progress() {

		heart.SetActive(true);
		fragments.SetActive(true);
		

		heart.GetComponent<Renderer> ().material.color = new Color((1.0F/150.0F)*image_hits+.5F, 
		                                                           (.150F/150.0F)*image_hits+.5F, (.150F/150.0F)*image_hits+.5F);
		fragments.GetComponent<Renderer> ().material.color = new Color((1.0F/150.0F)*image_hits+.5F, 
		                                                               (.150F/150.0F)*image_hits+.5F, (.150F/150.0F)*image_hits+.5F);
		circle.GetComponent<Renderer> ().material.color = new Color((2.0F/150.0F)*image_hits, 
		                                                            (.85F/150.0F)*image_hits, (.85F/150.0F)*image_hits);
		if (image_hits == 150 - 50) {
	
			glow.SetActive (true);
		}
		if (image_hits >= 150 - 50) {
			Color c_orig = ImagePlane_cur.GetComponent<Renderer> ().material.color;
			ImagePlane_cur.GetComponent<Renderer> ().material.color = new Color(c_orig.r+.45f, c_orig.g+.1f, c_orig.b+.1f, c_orig.a);
		}
	}
	

	void disable() {
		circle.GetComponent<Renderer> ().material.color = new Color(.5F, .25F, .25F);
		heart.SetActive(false);
		fragments.SetActive(false);
		glow.SetActive (false);

	}
}
