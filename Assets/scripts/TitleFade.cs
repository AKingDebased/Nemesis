using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class TitleFade : MonoBehaviour {
	public RawImage FadeImg;
	public Object scene;

	private float fadeSpeed = 0.66f;
	private bool sceneStarting = true;
	private bool sceneEnding = false;
	private bool tutorialComplete = false;
	private Dialogue tutorial;

	void Awake() {
		FadeImg.uvRect = new Rect (0, 0, Screen.width, Screen.height);
		FadeImg.SetNativeSize ();
		tutorial = gameObject.transform.parent.gameObject.AddComponent<Dialogue>();
	}
 
	void Update () {
		if(sceneStarting)
			StartScene();

		else if(Input.GetKeyUp("space") && scene.name == "main_game") {
			if (!GameObject.Find("dialogue(Clone)") && !tutorialComplete) {
				tutorial.LoadXML("TestDialogue", 0);
			}
			else if (tutorialComplete)
				sceneEnding = true;
		}

		else if (sceneEnding)
			EndScene();
	}	
	
	void StartScene () {
		FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
		if(FadeImg.color.a <= 0.05f) {
			FadeImg.color = Color.clear;
			FadeImg.enabled = false;
			sceneStarting = false;
		}
	}
	
	
	public void EndScene () {
		FadeImg.enabled = true;
		FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
		if(FadeImg.color.a >= 0.95f)
			Application.LoadLevel(scene.name);
	}
}