﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange_Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameScene(){
		SceneManager.LoadScene ("Stage1");
	}
}
