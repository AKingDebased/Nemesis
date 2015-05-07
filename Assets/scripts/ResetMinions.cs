using UnityEngine;
using System.Collections.Generic;

public class ResetMinions : MonoBehaviour {
	
	public GameObject ResourceManager;
	public bool resettable = true;

	public void Reset(){
		if(resettable){
			foreach(Transform minion in transform){ //the kludgiest, most magic numberiest fix
				if(transform.childCount > 0){
					if(minion.gameObject.tag == "grunt"){
						Debug.Log("boop");
						ResourceManager.GetComponent<ResourceManager>().AddGold(15);
					} else if(minion.tag == "shanker"){
						ResourceManager.GetComponent<ResourceManager>().AddGold(20);
					} else if(minion.tag == "mage"){
						ResourceManager.GetComponent<ResourceManager>().AddGold(30);
					} else if(minion.tag == "the big man"){
						ResourceManager.GetComponent<ResourceManager>().AddGold(75);
					} else {
						return;
					} Destroy(minion.gameObject);
				} else {
					return;
				}
			}
		}
	}
}
