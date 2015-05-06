using UnityEngine;
using System.Collections;

public class TorchBehaviors : MonoBehaviour {

	private ParticleEmitter[] emitters;
	private Light torchlight;
	private bool intensifying = true;
	private bool running = true;
	
	// Use this for initialization
	void Start () {
		emitters = this.GetComponentsInChildren<ParticleEmitter>();
		torchlight = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (intensifying && running) {
			torchlight.intensity += 0.05f;
			if (torchlight.intensity >= 4f)
				intensifying = false;
		}

		else if (!intensifying) {
			torchlight.intensity -= 0.05f;
			if (torchlight.intensity <= 3f)
				intensifying = true;
		}

		if(Application.loadedLevelName == "title_screen" && Input.GetKeyUp("space")) {
			for (int i = 0; i < emitters.Length; i++)	
				emitters[i].emit = false;
			torchlight.intensity = 0f;
			running = false;
		}
	}
}
