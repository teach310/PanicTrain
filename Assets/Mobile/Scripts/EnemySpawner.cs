using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public string enemy = "Aurochs_00";
	public float spawnTime = 3f;
	private Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		Transform spawnPointParent = this.transform.parent.Find ("SpawnPoints");
		spawnPoints = new Transform[spawnPointParent.childCount];
		for(int i=0;i<spawnPointParent.childCount;i++){
			spawnPoints[i] = spawnPointParent.GetChild (i);
		}
	}
	
	void Spawn(){
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		//local
		//Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		//Online
		PhotonNetwork.Instantiate ("Enemy/" + enemy,
			spawnPoints [spawnPointIndex].position, 
			spawnPoints [spawnPointIndex].rotation,
			0);
	}
}
