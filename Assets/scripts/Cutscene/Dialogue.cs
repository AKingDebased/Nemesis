using System;
using System.Xml;

using UnityEngine;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour
{
	public string dialogueFile;

	private GameObject dialogueObject;
	private Text dialogueText;
	private Text nameText;
	private XmlNodeList dialogueList;
	private XmlNodeList speakerList;
	private int spTracker = 1;
	private int diaTracker = 0;
 
	void Start()
	{
		XmlDocument scene = new XmlDocument();
		scene.Load(dialogueFile);
		speakerList = scene.GetElementsByTagName("speaker");

		dialogueObject = (GameObject)Instantiate(Resources.Load("dialogue"));
		dialogueObject.transform.SetParent(this.gameObject.transform, false);

		Text[] textList = this.gameObject.GetComponentsInChildren<Text>();
		dialogueText = textList [0];
		nameText = textList[1];

 		nameText.text = speakerList[0].Attributes["character"].Value;
 		dialogueText.text = speakerList[0].ChildNodes[0].InnerText;
	}

	void Update()
	{
		if (Input.GetKeyDown("space") && this.gameObject != null)
		{
			if (spTracker != speakerList.Count) this.NextLine();
			else Destroy(dialogueObject);
		}
	}

	void NextLine()
	{
		nameText.text = speakerList[spTracker].Attributes["character"].Value;
		dialogueText.text = speakerList[spTracker].ChildNodes[diaTracker].InnerText;

		if (diaTracker == speakerList[spTracker].ChildNodes.Count - 1)
		{
			spTracker++;
			diaTracker = 0;
		}

		else diaTracker++;
	}
}