using UnityEngine;
using System.Collections;

public class GoalBehaviour : MonoBehaviour {

	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {
			_gameManager.SetCurrentScene (GameManager.GameState.CLEAR);
		}
	}
}
