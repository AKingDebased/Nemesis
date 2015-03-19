using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {
	public AudioClip fireSound;
	public GameObject projectileObj;
	public float speed = 1;

	private GameObject projectile;
	
	public void Fire(GameObject target){
		projectile = Instantiate(projectileObj, transform.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<FireTowardsTarget>().enabled = true;
		projectile.GetComponent<FireTowardsTarget>().target = target;
		AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}
}
