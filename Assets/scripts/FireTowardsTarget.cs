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

		Invoke("DestroySelf",3); //kludge fix for lingering fireballs
	}

	void Update(){
		float step = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == target) {
			Impact ();
		}
	}

	void DestroySelf(){
		/*gameObject.GetComponent<ParticleEmitter>().emit = false;
		yield return new WaitForSeconds(1);*/
		Destroy (gameObject);
	}

	private void Impact(){
		Destroy(gameObject);
		Instantiate (collisionEffect, transform.position, Quaternion.identity);
		caster.GetComponent<MagicalCombat>().DoDamage(target);
		collisionSource.PlayOneShot(collisionSound);
	}
}
