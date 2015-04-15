using UnityEngine;
using System.Collections;

public class FireTowardsTarget : MonoBehaviour {
	public AudioClip collisionSound;
	public GameObject target;
	public GameObject collisionEffect;
	public float speed = 18;

	private AudioSource collisionSource;

	void Start(){
		collisionEffect = Resources.Load("fire explosion") as GameObject;
		collisionSource = this.GetComponent<AudioSource>();
	}

	void Update(){
		if(target == null){
			Impact ();
			enabled = false;
		}

		float step = Time.deltaTime * speed;
		
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.GetInstanceID() == target.GetInstanceID()){
			Impact ();
		}
	}

	private void Impact(){
		collisionSource.PlayOneShot(collisionSound);
		Instantiate (collisionEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
