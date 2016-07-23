using UnityEngine;
using System.Collections;

public class GameManagerMB : MonoBehaviour {

	private PhotonView _scenePhotonView;

	public enum GameState{
		PREPARE,
		TRAIN_STAND_BY,
		PLAYING,
		CLEAR,
		GAMEOVER
	}

	private GameState _currentGameState;

	void Start () {
		_scenePhotonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();
		SetCurrentScene (GameState.PREPARE);
	}

	// Update is called once per frame
	void Update () {

	}

	// シーンの切り替え
	public void SetCurrentScene(GameState newState){
		_currentGameState = newState;
		switch (_currentGameState) {
		case GameState.PREPARE:
			break;
		case GameState.TRAIN_STAND_BY:
			//_scenePhotonView.RPC ("SetCameraRPC", PhotonTargets.All);
			break;
		case GameState.PLAYING:
			break;
		case GameState.CLEAR:
			_scenePhotonView.RPC ("SetCurrentStateRPC", PhotonTargets.All, MySceneManager.SceneState.END);
			break;
		case GameState.GAMEOVER:
			break;
		default:
			break;
		}
		//_changeSceneFlg = true;
	}

	public void TrainStandBy(){
		SetCurrentScene (GameState.TRAIN_STAND_BY);
	}
}
