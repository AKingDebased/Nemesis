using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {
	private AudioSource trapSource;
	private bool activated;
	private ParticleEmitter[] emitters;

	void Start () {
		trapSource = this.GetComponent<AudioSource>();
		activated = false;
		emitters = this.GetComponentsInChildren<ParticleEmitter>();
		this.DeactivateEmitters();
	}

	void Update () {
		if (!trapSource.isPlaying && activated)
			this.DeactivateEmitters();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("hero") && !activated) {
			Debug.Log(other.gameObject.transform.name + " triggered the flame trap!");
			this.ActivateEmitters();
			trapSource.Play();
			activated = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if ((other.gameObject.CompareTag ("hero") || other.gameObject.CompareTag ("minion")) && trapSource.isPlaying) {
			other.GetComponent<Stats>().TakeDamage(2);

			if (other.GetComponent<Stats>().health <= 0) {
				Debug.Log (other.gameObject.name + " fell to a flame trap!");
				Destroy(other.gameObject);
			}
		}
	}


	void ActivateEmitters(){
		for (int i = 0; i < emitters.Length; i++)
			emitters [i].emit = true;
	}

	void DeactivateEmitters(){
		for (int i = 0; i < emitters.Length; i++)
			emitters [i].emit = false;
	}
}