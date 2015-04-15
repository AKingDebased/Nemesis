using System;
using System.Xml;

using UnityEngine;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour {
	public string dialogueFile;
	public int sceneID;

	private GameObject dialogueObject;
	private XmlNodeList speakerList;
	private Text dialogueText;
	private Text nameText;
	private int spTracker;
	private int diaTracker;
 
	void Start() {
		this.LoadXML(dialogueFile, sceneID);
		this.CreateUIElements();
	}

	void Update() {
		if (Input.GetKeyDown("space") && dialogueObject != null) {
			if (spTracker != speakerList.Count && !GameObject.Find("decision(Clone)"))
				this.NextLine();
			else if (GameObject.Find("decision(Clone)")){}
			else Destroy(dialogueObject);
		}
	}

	void LoadXML(string file, int sceneID) {
		XmlDocument sceneDoc = new XmlDocument();
		sceneDoc.Load("Assets/scripts/Cutscene/" + file + ".xml");
		XmlNode sceneNode = sceneDoc.GetElementsByTagName("scene")[sceneID];
		speakerList = sceneNode.ChildNodes;
	}

	void CreateUIElements() {
		dialogueObject = (GameObject)Instantiate(Resources.Load("dialogue"));
		dialogueObject.transform.SetParent(this.gameObject.transform, false);
		this.FillElements();
	}

	void CreateDecisionElements() {
		GameObject decisionObject = (GameObject)Instantiate (Resources.Load ("decision"));
		decisionObject.transform.SetParent(this.gameObject.transform, false);
		
		Text[] choiceList = decisionObject.GetComponentsInChildren<Text> ();
		
		for (int i = 0; i < choiceList.Length; i++) {
			int local_i = i; //C# for loops are dumb and i is only a reference
			choiceList[i].text = speakerList[spTracker].ChildNodes[i].InnerText;
			if (i > 0)
				decisionObject.GetComponentsInChildren<Button>()[i-1].onClick.AddListener(() => makeChoice(local_i-1));
		}
	}

	void FillElements() {
		Text[] textList = this.gameObject.GetComponentsInChildren<Text>();
		dialogueText = textList[0];
		nameText = textList[1];
		spTracker = 1;
		diaTracker = 0;
		nameText.text = speakerList[0].Attributes["character"].Value;
		dialogueText.text = speakerList[0].ChildNodes[0].InnerText;
	}

	public void makeChoice(int x) {
		Debug.Log ("Button #" + x);
		Destroy(GameObject.Find("decision(Clone)"));
		speakerList = speakerList[spTracker+x].NextSibling.ChildNodes;
		this.FillElements();
	}

	void NextLine() {
		if (speakerList [spTracker].Name == "decision")
			this.CreateDecisionElements();

		else {
			nameText.text = speakerList[spTracker].Attributes["character"].Value;
			dialogueText.text = speakerList[spTracker].ChildNodes[diaTracker].InnerText;
		}

		if (diaTracker == speakerList[spTracker].ChildNodes.Count - 1) {
			spTracker++;
			diaTracker = 0;
		}

		else diaTracker++;
	}
}