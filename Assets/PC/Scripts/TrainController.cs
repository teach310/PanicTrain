using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour {

	GameObject wayPointParent;
	int currentAngle = 0; //0 to 7
	public string[] linePanels = new string[3];
	private Vector3 currentCenterPosition;
	public float scale = 1;
	int index = 1;
	public TrainSplineMove trainSplineMove;

	public enum MoveDirection{
		LEFT = -1,
		STRAIGHT,
		RIGHT
	}

	private MoveDirection currentMoveDirection;

	//Test------------
	public GameObject[] panels;
	//-----------------

	// Use this for initialization
	void Start () {
		wayPointParent = this.transform.parent.Find ("Waypoints").gameObject;
		SetStartLinePanel (wayPointParent.transform.GetChild(0).position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateCurrentAngle(int num){
		currentAngle += num;
		if (currentAngle == 8)
			currentAngle = 0;
		else if (currentAngle == -1)
			currentAngle = 7;
	}

	public void SetMoveDirection(MoveDirection dir){
		currentMoveDirection = dir;



		//Test----------
		SpawnLinePanel ((int)dir, currentCenterPosition + scale * Vector3.forward);
		UpdateCurrentAngle ((int)dir);
		//---------


	}

	void SetStartLinePanel(Vector3 startPos){
		
		SpawnLinePanel(0, startPos + (scale * Vector3.forward)/2);
		//SpawnLinePanel (0, currentCenterPosition + scale * Vector3.forward);
		trainSplineMove.StopMove ();
	}


	void SpawnLinePanel(int dir, Vector3 pos){

//		GameObject newLinePanel = PhotonNetwork.Instantiate (linePanels [dir + 1],
//												currentCenterPosition + scale * Vector3.forward,
//												Quaternion.Euler (Vector3.zero),
//												0) as GameObject;
		//Test-----------------
		GameObject newLinePanel = Instantiate (
			                          panels [dir + 1], 
			pos,
			                          Quaternion.Euler (Vector3.zero)) as GameObject;

		//
		newLinePanel.transform.RotateAround (currentCenterPosition, Vector3.up, currentAngle * 45);

		Transform waypoint = newLinePanel.transform.FindChild ("Waypoint");
		waypoint.name += index.ToString ();
		waypoint.SetParent (wayPointParent.transform);
		index++;

		currentCenterPosition = newLinePanel.transform.position;

		//最初の出発
		if (index == 2) {
			trainSplineMove.InitWayPoint ();
		}

		if (trainSplineMove.GetCanMove () == false) {
			trainSplineMove.StartMove ();
		}
	}
}
