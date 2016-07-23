using UnityEngine;
using System.Collections;

public class MBCameraBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PhotonNetwork.isMasterClient) {
			this.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
