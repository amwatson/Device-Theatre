using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public GameObject phase1FX;
	public GameObject phase2FX;
	public GameObject spaaceObjects;
	public float timer = 0;
	public int ind = 0;
	public float[] events;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddTorque (Vector3.right * .2f, ForceMode.Impulse);
		GetComponent<Rigidbody>().AddForce (Vector3.right * 10f, ForceMode.Impulse);
		RenderSettings.skybox.SetColor ("_Tint", Color.gray);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		GetComponent<Rigidbody>().AddTorque (Vector3.right * .002f);
		GetComponent<Rigidbody>().AddForce (Vector3.right * .01f);
		if (ind < events.Length && timer > events [ind])
						nextScene ();
	}

	public void nextScene(){
		switch(ind){
		case 0:
			GetComponent<AudioSource>().Play ();
			break;
		case 1:
			phase1FX.SetActive(true);
			break;
		case 2:
			spaaceObjects.SetActive(false);
			StartCoroutine("FadeSkyBox");
			break;
		case 3:
			phase2FX.SetActive(true);
			break;
		default:
			break;
		}
		++ind;
	}
	
	public IEnumerator FadeSkyBox(){
		print (Color.white);
		int duration = 1000;
		int t = 0;
		Color colorStart = RenderSettings.skybox.GetColor("_Tint");
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		while (t < --duration){
			colorStart.r -= .002f;
			colorStart.g -= .002f;
			colorStart.b -= .002f;
			RenderSettings.skybox.SetColor("_Tint", colorStart);
			yield return null;
		}
	}
}

