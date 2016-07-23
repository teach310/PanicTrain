using UnityEngine;
using System.Collections;

public class UIManagerMB : MonoBehaviour {

	public GameObject mbCamera;
	public Vector3 offset = new Vector3(0f, 1.58f, -0.08f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetCamera(){
		GameObject player = GameObject.FindWithTag ("Player");
		GameObject newCamera = Instantiate (mbCamera, player.transform.position + offset, Quaternion.identity) as GameObject;
		newCamera.transform.parent = player.transform;
	}
}
