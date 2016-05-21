using UnityEngine;
using System.Collections;

// シーン基底クラス(継承するやつ)
public class SceneBehaviour : MonoBehaviour {

	public GameObject defaultScreen;

	protected GameObject _currentScreen;
	protected MySceneManager _mySceneManager;

	protected virtual void Awake(){
		if (_mySceneManager == null)
			_mySceneManager = GameObject.Find ("MySceneManager").GetComponent<MySceneManager> ();
	}

	protected virtual void OnEnable(){
		PushScreen (defaultScreen);
	}

	public void PushScreen(GameObject newScreen)
	{
		if (_currentScreen != null)
			Destroy (_currentScreen);
		_currentScreen = Instantiate (newScreen) as GameObject;
		_currentScreen.transform.parent = this.transform;
	}
}
