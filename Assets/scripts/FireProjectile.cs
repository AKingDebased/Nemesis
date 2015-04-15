using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {
	public AudioClip fireSound;
	public GameObject projectileObj;
	public Transform launchPoint;
	public float speed = 1;

	private GameObject projectile;
	private AudioSource fireSource;
	
	public void Awake()
	{
		fireSource = this.GetComponent<AudioSource>();
	}

	public void Fire(GameObject target){
		projectile = Instantiate(projectileObj, launchPoint.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<FireTowardsTarget>().enabled = true;
		projectile.GetComponent<FireTowardsTarget>().target = target;
		fireSource.PlayOneShot(fireSound);
	}
}
