using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class TitleFade : MonoBehaviour {
	public RawImage FadeImg;

	private float fadeSpeed = 1.5f;
	private bool sceneStarting = true;
	private bool sceneEnding = false;
	private Dialogue tutorial;

	void Awake() {
		FadeImg.uvRect = new Rect (0, 0, Screen.width, Screen.height);
		FadeImg.SetNativeSize ();
		tutorial = GameObject.Find("DialogueParent").AddComponent<Dialogue>();
	}
 
	void Update () {
		if(sceneStarting)
			StartScene();

		else if(Input.GetKeyUp("space") && Application.loadedLevelName == "title_screen") {
			if (!GameObject.Find("dialogue(Clone)") && !tutorial.isOver()) {
				Destroy(GameObject.Find("nemesis"));
				Destroy(GameObject.Find("press spacebar"));
				tutorial.LoadXML("TestDialogue", 0);
			}

			else if (tutorial.isOver())
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
			Application.LoadLevel("main_game");
	}
}