using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 20;
	public int currentHealth;
	//public Slider healthSlider;

	private GameManagerMB _gameManagerMB;

	void Awake(){
		currentHealth = startingHealth;
	}



	//damageImage

	public void TakeDamage(int amount){
		currentHealth -= amount;
	//	healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			_gameManagerMB.SetCurrentScene (GameManagerMB.GameState.GAMEOVER);
		}
	}
}
