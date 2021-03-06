﻿using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	private Transform _playerTransform;
	private PlayerHealth _playerHealth;
	private EnemyHealth _enemyHealth;
	private NavMeshAgent _nav;

	public string moveAnimation = "run";
	public string attackAnimation = "attack";
	public string loveAnimation = "idle";

	private Animation _anim;

	//Test
	private bool stop = false;
	void Awake()
	{
		_playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		_playerHealth = _playerTransform.GetComponent<PlayerHealth> ();
		_enemyHealth = this.GetComponent<EnemyHealth> ();
		_nav = this.GetComponent<NavMeshAgent> ();

		_anim = this.GetComponent<Animation> ();
	}

	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (this.transform.position, _playerTransform.position) < 2) {
			stop = true;
		}

		if (_enemyHealth.currentHealth > 0 && _playerHealth.currentHealth > 0 && !stop) {
			_nav.SetDestination (_playerTransform.position);
		} else {
			_nav.enabled = false;
		}
	}

	public void SetAnimation(string name){
		_anim.Play (name);
	}
}
