using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {
	private AudioSource trapSource;
	private ParticleEmitter[] emitters;
	private MeshRenderer[] meshRenderers;
	private bool activated = false;

	public int trapDmg = 10;

	void Start () {
		trapSource = this.GetComponent<AudioSource>();
		emitters = this.GetComponentsInChildren<ParticleEmitter>();
		meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("hero") && !activated) {
			Debug.Log(other.gameObject.transform.name + " triggered the flame trap!");

			this.ActivateEmitters();
			this.ActivateRenders();
			trapSource.Play();

			other.GetComponent<Stats>().TakeDamage(trapDmg);
			activated = true;

			Invoke ("DeactivateEmitters",2.0f);
		}
	}

	void ActivateEmitters(){
		for (int i = 0; i < emitters.Length; i++)
			emitters [i].emit = true;
	}

	void ActivateRenders(){
		for (int i = 0; i < meshRenderers.Length; i++){
			meshRenderers[i].enabled = true;
		}
	}

	void DeactivateEmitters(){
		for (int i = 0; i < emitters.Length; i++)
			emitters [i].emit = false;
	}
}