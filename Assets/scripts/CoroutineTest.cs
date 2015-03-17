using UnityEngine;
using System.Collections;

public class CoroutineTest : MonoBehaviour {
	bool count = false;
	float timer = 0.0f;

	void Start () {
		//StartCoroutine(Countdown());
		//StartCoroutine(Hello());
		TimeCounter();
	}

	void Update(){
		while(count){
			Debug.Log ("hello");

			timer += Time.deltaTime;
			
			if (timer >= 5){
				count = false;
			}
		}
	}
	
	IEnumerator Countdown(){
		for (float timer = 3; timer >= 0; timer -= Time.deltaTime){
			yield return 0;
		}

		Debug.Log ("three seconds passed");
	}

	IEnumerator Hello(){
		for (float i = 0; i < 5; i++){
			Debug.Log ("hello");
			yield return 0;
		}
	}

	IEnumerator OncePerFrame(){
		int loopCount = 0;

		while(loopCount < 20){
			Debug.Log ("loop " + loopCount);

			loopCount++;
			yield return 0;
		}
	}

	IEnumerator TimeCounter(){
		int seconds = 0;

		Debug.Log ("just once");
		while(true){
			for (float timer = 0; timer < 1; timer += Time.deltaTime){
				yield return null;
		    }

	        seconds++;
		    Debug.Log (seconds + " seconds have passed");
	    }
	}
}


