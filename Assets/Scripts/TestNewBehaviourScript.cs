using UnityEngine;
using System.Collections;

public class TestNewBehaviourScript : MonoBehaviour {

	private PhotonView _scenePhotonView;
	public MySceneManager mySceneManager;

	void Start () {
		_scenePhotonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			//mySceneManager.SetCurrentScene (MySceneManager.SceneState.TITLE);
			_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.TITLE);
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.GAME);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.END);
		}
	}
}
