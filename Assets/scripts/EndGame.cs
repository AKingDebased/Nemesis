using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public GameObject endText;
	public GameObject restartButton;

	public void RestartLevel(){
		Application.LoadLevel ("main_game");
	}

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		endText.SetActive(true);
		restartButton.SetActive(true);
	}
}
