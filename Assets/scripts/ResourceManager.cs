using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

	public int gold = 100;
	public Text goldDisplay;

	void Start () {
		goldDisplay.text = gold.ToString();
	}

	public bool SubtractGold(int gold){
		if(this.gold - gold >= 0){
			this.gold -= gold;
			UpdateUI ();
			return true;
		} else {
			return false;
		}
	}

	private void UpdateUI(){
		goldDisplay.text = gold.ToString ();
	}
}
