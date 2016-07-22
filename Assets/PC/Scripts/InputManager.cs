using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public TrainController trainController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			trainController.SetMoveDirection (TrainController.MoveDirection.RIGHT);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			trainController.SetMoveDirection (TrainController.MoveDirection.STRAIGHT);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			trainController.SetMoveDirection (TrainController.MoveDirection.LEFT);
		}
	}
}
