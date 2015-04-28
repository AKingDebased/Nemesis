using UnityEngine;
using System.Collections;

public class FireTowardsTarget : MonoBehaviour {
	public AudioClip collisionSound;
	public GameObject target;
	public GameObject collisionEffect;
	public GameObject caster;
	public float speed = 18;

	private AudioSource collisionSource;

	void Start(){
		collisionEffect = Resources.Load("fire explosion") as GameObject;
		collisionSource = this.GetComponent<AudioSource>();
	}

	void Update(){
		float step = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}
	
	void OnTriggerEnter(Collider other) {
		Impact ();
	}

	private void Impact(){
		caster.GetComponent<MagicalCombat>().Fight(target);
		//collisionSource.PlayOneShot(collisionSound);
		Instantiate (collisionEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Debug.Log ("destroyed fireball");
	}
}
