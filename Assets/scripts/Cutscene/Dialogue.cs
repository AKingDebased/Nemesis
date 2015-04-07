using System;
using System.Xml;

using UnityEngine;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour
{
	public string dialogueFile;
	public int sceneID;

	private GameObject dialogueObject;
	private Text dialogueText;
	private Text nameText;
	private XmlNodeList speakerList;
	private int spTracker = 1;
	private int diaTracker = 0;
	private bool decision = false;
 
	void Start()
	{
		this.LoadXML(dialogueFile, sceneID);
		this.CreateUIElements();
	}

	void Update()
	{
		if (Input.GetKeyDown("space") && dialogueObject != null)
		{
			if (spTracker != speakerList.Count && !decision) this.NextLine();
			else if (decision){}
			else Destroy(dialogueObject);
		}
	}

	void LoadXML(string file, int sceneID)
	{
		XmlDocument sceneDoc = new XmlDocument();
		sceneDoc.Load("Assets/scripts/Cutscene/" + file + ".xml");
		XmlNode sceneNode = sceneDoc.GetElementsByTagName("scene")[sceneID];
		speakerList = sceneNode.ChildNodes;
	}

	void CreateUIElements()
	{
		dialogueObject = (GameObject)Instantiate(Resources.Load("dialogue"));
		dialogueObject.transform.SetParent(this.gameObject.transform, false);
		
		Text[] textList = this.gameObject.GetComponentsInChildren<Text>();
		dialogueText = textList[0];
		nameText = textList[1];
		
		nameText.text = speakerList[0].Attributes["character"].Value;
		dialogueText.text = speakerList[0].ChildNodes[0].InnerText;
	}



	void NextLine()
	{
		if (speakerList [spTracker].Name == "decision")
		{
			GameObject decisionObject = (GameObject)Instantiate(Resources.Load("decision"));
			decisionObject.transform.SetParent(this.gameObject.transform, false);
			decision = true;

			Text[] choiceList = decisionObject.GetComponentsInChildren<Text>();

			for (int i = 0; i < choiceList.Length; i++)
			{
				choiceList[i].text = speakerList[spTracker].ChildNodes[i].InnerText;
			}
		}

		else
		{
			nameText.text = speakerList[spTracker].Attributes["character"].Value;
			dialogueText.text = speakerList[spTracker].ChildNodes[diaTracker].InnerText;
		}

		if (diaTracker == speakerList[spTracker].ChildNodes.Count - 1)
		{
			spTracker++;
			diaTracker = 0;
		}

		else diaTracker++;
	}
}