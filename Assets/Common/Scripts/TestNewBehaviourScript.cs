using UnityEngine;
using System.Collections;

public class TestNewBehaviourScript : MonoBehaviour {

	public bool isLocal = true;
	private PhotonView _scenePhotonView;
	public MySceneManager mySceneManager;

	void Start () {
		_scenePhotonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			if(isLocal)
				mySceneManager.SetCurrentScene (MySceneManager.SceneState.TITLE);
			else
				_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.TITLE);
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			if (isLocal)
				mySceneManager.SetCurrentScene (MySceneManager.SceneState.GAME);
			else
				_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.GAME);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			if (isLocal)
				mySceneManager.SetCurrentScene (MySceneManager.SceneState.END);
			else
				_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.END);
		}
	}
}
