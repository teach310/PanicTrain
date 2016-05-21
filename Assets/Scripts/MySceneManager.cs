using UnityEngine;
using System.Collections;

public class MySceneManager : MonoBehaviour {

	public GameObject titleScene;
	public GameObject gameScene;
	public GameObject endScene;

	public enum SceneState
	{
		TITLE,
		GAME,
		END
	}

	private GameObject _currentScene;
	private SceneState _currentSceneState;

	private bool _changeSceneFlg = false;

	void Start () {
		InitScene ();
	}

	void LateUpdate () {
		if (_changeSceneFlg == true){
			UpdateScene ();
		}
	}
	// シーンの初期化
	void InitScene()
	{
		SetCurrentScene (SceneState.TITLE);
		_currentScene = titleScene;
	}
		
	// シーンの更新
	void UpdateScene(){
		switch (_currentSceneState){
		case SceneState.TITLE:
			PushNewScene (titleScene);
			break;
		case SceneState.GAME:
			PushNewScene (gameScene);
			break;
		case SceneState.END:
			PushNewScene (endScene);
			break;
		default:
			break;
		}

		_changeSceneFlg = false;
	}

	// シーンの切り替え
	public void SetCurrentScene(SceneState newState){
		_currentSceneState = newState;
		_changeSceneFlg = true;
	}

	// シーンのオブジェクトを切り替える
	void PushNewScene(GameObject newScene){
		_currentScene.SetActive (false);
		_currentScene = newScene;
		_currentScene.SetActive (true);
	}
}
