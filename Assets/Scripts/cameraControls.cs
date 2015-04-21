using UnityEngine;
using System.Collections;

public class cameraControls : MonoBehaviour {
	public GameObject player;
	public float speed = 0.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	/*	if (Input.GetKey(KeyCode.W)) {
				Vector3 pos = player.transform.position;
				Vector3 forward = player.transform.forward;
				pos = pos + forward*speed;
			player.transform.position = pos;
		} else if (Input.GetKey(KeyCode.S)) {
			Vector3 pos = player.transform.position;
			Vector3 forward = player.transform.forward;
			pos = pos - forward*speed;
			player.transform.position = pos;
		} else if (Input.GetKey(KeyCode.D)) {
			Vector3 pos = player.transform.position;
			Vector3 right = player.transform.right;
			pos = pos + right*speed;
			player.transform.position = pos;
		} else if (Input.GetKey(KeyCode.A)) {
			Vector3 pos = player.transform.position;
			Vector3 right = player.transform.right;
			pos = pos - right*speed;
			player.transform.position = pos;
		}*/
	}
}
