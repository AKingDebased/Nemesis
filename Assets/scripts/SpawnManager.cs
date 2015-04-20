using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	private Ray ray;
	private RaycastHit hit;
	
	public GameObject minion;
	
	void Update () {
		InstantiateAtRayCast ();
		SelectSpawnMinion ();
	}
	
	private void SelectSpawnMinion(){
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			minion = Resources.Load ("minions/grunt") as GameObject;
		}			
		
		if(Input.GetKeyDown (KeyCode.Alpha2)){
			minion = Resources.Load ("minions/shanker") as GameObject;
		}
		
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			minion = Resources.Load("minions/mage") as GameObject;
		}
		
		if(Input.GetKeyDown (KeyCode.Alpha4)){
			Debug.Log ("4");
		}
	}

	private void InstantiateAtRayCast(){
		if (Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hit)){
				Debug.Log ("hit");
				Instantiate (minion, hit.point,Quaternion.identity);
			}
		}
	}
}
