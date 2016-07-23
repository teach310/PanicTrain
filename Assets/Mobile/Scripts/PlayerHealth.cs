using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 20;
	public int currentHealth;
	//public Slider healthSlider;
	private GameObject _gameManager;


	void Awake(){
		currentHealth = startingHealth;
	}

	void Start(){
		_gameManager = GameObject.Find ("GameManager");
		Debug.Log (_gameManager);
		_gameManager.SendMessage("TrainStandBy");
	}



	//damageImage

	public void TakeDamage(int amount){
		currentHealth -= amount;
	//	healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			_gameManager.SendMessage("SetCurrentScene", GameManagerMB.GameState.GAMEOVER);
		}
	}
}
