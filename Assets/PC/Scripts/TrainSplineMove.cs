﻿using UnityEngine;
using System.Collections;

public class TrainSplineMove : MonoBehaviour {
	
	float t = 0;

	[Range(0.0f, 1.0f)]
	public float moveSpeed = 0.5f;
	public GameObject player;
	private Transform[] wayPoints;
	private Transform[] velPoints;

	//speed は1安定 2段階に動く時は減らす
	public float speed = 1.0f;
	private Vector3[] pos_wayPoint;
	private Vector3[] vel_wayPoint;

	private Vector3[] orbit;


	private int arriveWayPointCount = 0;
	//private float time_Start = 0;
	private bool canMove = false;

	const int buf = 100;

	//wayPointの親を入れる
	public GameObject wayPointsParent;


	//For Rotation
	private int countFromStart = 0;
	private Vector3[] lastPosition;


	// Use this for initialization
	void Start () {



	}

	public void InitWayPoint(){
		wayPoints = new Transform[buf];
		velPoints = new Transform[buf];
		pos_wayPoint = new Vector3[2];
		vel_wayPoint = new Vector3[2];
		lastPosition = new Vector3[2];

		for(int i=0;i<2;i++){
			wayPoints [i] = wayPointsParent.transform.GetChild (i);
			pos_wayPoint [i] = wayPoints [i].position;
			velPoints[i] = wayPoints[i].FindChild("VelPoint");
			vel_wayPoint[i] = speed*(velPoints[i].position - wayPoints[i].position).normalized;
		}

		orbit = new Vector3[4]{
			pos_wayPoint [0],
			pos_wayPoint [1],
			vel_wayPoint[0],
			vel_wayPoint[1]
		};
	}


	// Update is called once per frame
	void FixedUpdate () {
		//canMoveならTransformを更新
		if (canMove == true) {
			t += Time.deltaTime * moveSpeed ;
			UpdateTargetPosition ();
			UpdateTargetRotation ();
		}
	}

	public bool GetCanMove(){
		return canMove;
	}

	//この関数を呼ぶと動き始める
	public void StartMove(){
		canMove = true;
		//t = 0;
	}

	public void StopMove(){
		canMove = false;
	}

	//Trainの回転を更新
	void UpdateTargetRotation(){
		if (countFromStart > 2) {
			player.transform.rotation = Quaternion.LookRotation(player.transform.position - lastPosition[1]);
		}
		lastPosition [1] = lastPosition [0]; // 2つ前
		lastPosition[0] = player.transform.position;
		countFromStart++;
	}

	//Spline曲線でTrainの位地を更新
	void UpdateTargetPosition(){
		if (t < 1.0f) {
			player.transform.position = GetPosition (t);
		} else {
			player.transform.position = GetPosition (1);
			Debug.Log (wayPointsParent.transform.childCount);
			Debug.Log (arriveWayPointCount);
			//次に目指すwayPointの更新
			if (wayPointsParent.transform.childCount > (arriveWayPointCount+2)) {
				arriveWayPointCount += 1;
				t = 0;
				Debug.Log ("aP:"+arriveWayPointCount);
				UpdateWayPoint (arriveWayPointCount);
			} else {
				Debug.Log ("a");
				canMove = false;
				countFromStart = 0;
			}
		}
	}

	//次のwayPointを設定
	void UpdateWayPoint(int count){
		int nextCount = count+1;

		pos_wayPoint [0] = pos_wayPoint [1];
		vel_wayPoint [0] = vel_wayPoint [1];
		wayPoints [nextCount] = wayPointsParent.transform.GetChild (nextCount);

		pos_wayPoint [1] = wayPoints[nextCount].position;
		velPoints[nextCount] = wayPoints[nextCount].FindChild("VelPoint");
		vel_wayPoint[1] = speed*(velPoints[nextCount].position - wayPoints[nextCount].position).normalized;

		orbit = new Vector3[4]{
			pos_wayPoint[0],
			pos_wayPoint[1],
			vel_wayPoint[0],
			vel_wayPoint[1]
		};
	}

	// Positionの取得
	Vector3 GetPosition(float time){
		int i,j;
		Vector3 pos = Vector3.zero;
		Vector3[] hg = new Vector3[4];
		float[] vector_time = new float[4]{
			time * time * time,
			time * time,
			time,
			1
		};

		float[,] hermite = new float[4,4]{
			{2,-2,1,1},
			{-3,3,-2,-1},
			{0,0,1,0},
			{1,0,0,0}
		};

		//Debug.Log ("t^3: " + vector_time [0].ToString());
		for (i=0; i<4; i++) {
			for(j=0;j<4;j++){
				hg[i] += hermite[i,j] * orbit[j];
			}
		}

		//Debug.Log (hg[0]);

		for (i=0; i<4; i++) {
			pos += vector_time[i] * hg[i];
		}

		return pos;
	}
}
