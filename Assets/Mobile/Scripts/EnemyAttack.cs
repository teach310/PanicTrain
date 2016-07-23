using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 4;


	private GameObject _player;
	private EnemyBehaviour _enemyBehaviour;
	private PlayerHealth _playerHealth;
	private EnemyHealth _enemyHealth;
	private bool _playerInRange;
	private float timer;

	void Awake()
	{
		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerHealth = _player.GetComponent<PlayerHealth> ();
		_enemyHealth = this.GetComponent<EnemyHealth> ();
		_enemyBehaviour = this.GetComponent<EnemyBehaviour> ();
	}

	void OnTriggerEnter(Collider other)
	{
		_enemyBehaviour.SetAnimation ("attack");
		if (other.gameObject == _player) {
			_playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == _player) {
			_playerInRange = false;
		}
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && _playerInRange && _enemyHealth.currentHealth > 0) {
			Attack ();
		}
	}

	void Attack(){
		timer = 0f;
		if (_playerHealth.currentHealth > 0) {
			_playerHealth.TakeDamage (attackDamage);
		}
	}
}
