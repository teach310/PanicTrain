using UnityEngine;
using System.Collections;

public class TestNewBehaviourScript : MonoBehaviour {

	public MySceneManager mySceneManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			mySceneManager.SetCurrentScene (MySceneManager.SceneState.GAME);
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			mySceneManager.SetCurrentScene (MySceneManager.SceneState.TITLE);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			mySceneManager.SetCurrentScene (MySceneManager.SceneState.END);
		}
	}
}
