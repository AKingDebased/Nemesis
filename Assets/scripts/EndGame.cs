using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text endText;
	public Button restartButton;

	void OnTriggerEnter(Collider other){
		Instantiate(endText);
		Instantiate(restartButton);
	}
}
