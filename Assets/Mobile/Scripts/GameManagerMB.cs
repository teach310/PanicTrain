using UnityEngine;
using System.Collections;

public class GameManagerMB : MonoBehaviour {

	private PhotonView _scenePhotonView;

	public enum GameState{
		PLAYING,
		CLEAR,
		GAMEOVER
	}

	private GameState _currentGameState;

	void Start () {
		_scenePhotonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();
		SetCurrentScene (GameState.PLAYING);
	}

	// Update is called once per frame
	void Update () {

	}

	// シーンの切り替え
	public void SetCurrentScene(GameState newState){
		_currentGameState = newState;
		_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.END);
		//_changeSceneFlg = true;
	}

}
