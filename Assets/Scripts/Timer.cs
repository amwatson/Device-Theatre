using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public bool timer_on = false;
	float timer = 0.0f;
	// Use this for initialization
	void Start () {
		start_timer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer_on) {
			timer+=Time.deltaTime;
		}
	}

	public void start_timer() {
		timer_on = true;
	}

	public float get_time() {
		return timer;
	}	
}
