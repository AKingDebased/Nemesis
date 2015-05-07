using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HazardManager : MonoBehaviour {
	private Ray ray;
	private RaycastHit hit;
	private GameObject hazard;
	private int cost = 0;

	public Text uiText;
	public GameObject resourceManager;

	void Update () {
		SelectHazard ();
		InstantiateAtRayCast(cost);
	}
	
	private void SelectHazard(){
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			hazard = Resources.Load ("minions/grunt") as GameObject;
			UpdateUI();
			cost = 15;
		}			
		
		if(Input.GetKeyDown (KeyCode.Alpha2)){
			hazard = Resources.Load ("minions/shanker") as GameObject;
			UpdateUI();
			cost = 20;
		}
		
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			hazard = Resources.Load("minions/mage") as GameObject;
			UpdateUI();
			cost = 30;
		}

		if(Input.GetKeyDown (KeyCode.Alpha4)){
			UpdateUI("flame trap");
			gameObject.GetComponent<TrapPlacement>().NewTrap();
		}
	}

	private void InstantiateAtRayCast(int cost){
		if (Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hit)){
				if(resourceManager.GetComponent<ResourceManager>().ValidPurchase(cost)){
					Instantiate (hazard, hit.point,Quaternion.identity);
					resourceManager.GetComponent<ResourceManager>().SubtractGold(cost);
				}
			}
		}
	}

	private void UpdateUI(){
		uiText.text = hazard.name;
	}

	private void UpdateUI(string name){
		uiText.text = name;
	}
}
