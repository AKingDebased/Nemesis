using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

	public int gold = 100;
	public Text goldDisplay;

	void Start () {
		goldDisplay.text = gold.ToString();
	}

	public void SubtractGold(int gold){
		this.gold -= gold;
		UpdateUI ();
	}

	public bool ValidPurchase(int cost){
		return this.gold - cost >= 0; //remove these magic numbers
	}

	private void UpdateUI(){
		goldDisplay.text = gold.ToString ();
	}
}
