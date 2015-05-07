using UnityEngine;
using System.Collections.Generic;

public class ResetMinions : MonoBehaviour {
	
	public GameObject ResourceManager;

	public void Reset(){
		Debug.Log(transform.childCount);

		foreach(Transform minion in transform){ //the kludgiest, most magic numberiest fix
			Debug.Log(minion.gameObject.name);

			if(transform.childCount > 0){
				if(minion.gameObject.tag == "grunt"){
					Debug.Log("boop");
					ResourceManager.GetComponent<ResourceManager>().AddGold(15);
				} else if(minion.tag == "shanker"){
					ResourceManager.GetComponent<ResourceManager>().AddGold(20);
				} else if(minion.tag == "mage"){
					ResourceManager.GetComponent<ResourceManager>().AddGold(30);
				} else {
					return;
				} Destroy(minion.gameObject);
			} else {
				return;
			}
		}
	}
}
