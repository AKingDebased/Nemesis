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
		Debug.Log ("target is " + other.gameObject);
		if (other.gameObject == target) {
			Impact ();
		}
	}

	private void Impact(){
		Destroy(gameObject);
		Instantiate (collisionEffect, transform.position, Quaternion.identity);
		caster.GetComponent<MagicalCombat>().DoDamage(target);
		collisionSource.PlayOneShot(collisionSound);
	}
}
