﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HazardManager : MonoBehaviour {
	private Ray ray;
	private RaycastHit hit;
	private GameObject hazard;

	public Text uiText;

	void Update () {
		SelectHazard ();
		InstantiateAtRayCast();
	}
	
	private void SelectHazard(){
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			hazard = Resources.Load ("minions/grunt") as GameObject;
			UpdateUI();
			InstantiateAtRayCast();
		}			
		
		if(Input.GetKeyDown (KeyCode.Alpha2)){
			hazard = Resources.Load ("minions/shanker") as GameObject;
			UpdateUI();
			InstantiateAtRayCast();
		}
		
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			hazard = Resources.Load("minions/mage") as GameObject;
			UpdateUI();
			InstantiateAtRayCast();
		}
	}

	private void InstantiateAtRayCast(){
		if (Input.GetMouseButtonDown(0)){
			Debug.Log ("ass");
			if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hit)){
				Instantiate (hazard, hit.point,Quaternion.identity);
			}
		}
	}

	private void UpdateUI(){
		uiText.text = hazard.name;
	}
}
