using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {
	private Ray ray;
	private RaycastHit hit;
	private GameObject minion;

	public Text uiText;

	void Update () {
		InstantiateAtRayCast ();
		SelectSpawnMinion ();
	}
	
	private void SelectSpawnMinion(){
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			minion = Resources.Load ("minions/grunt") as GameObject;
			UpdateUI();
		}			
		
		if(Input.GetKeyDown (KeyCode.Alpha2)){
			minion = Resources.Load ("minions/shanker") as GameObject;
			UpdateUI();
		}
		
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			minion = Resources.Load("minions/mage") as GameObject;
			UpdateUI();
		}
	}

	private void InstantiateAtRayCast(){
		if (Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hit)){
				Instantiate (minion, hit.point,Quaternion.identity);
			}
		}
	}

	private void UpdateUI(){
		uiText.text = minion.name;
	}
}
