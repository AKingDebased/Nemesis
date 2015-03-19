using System;
using System.Xml;

using UnityEngine;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour
{
	public string dialogueFile;
	public Text dialogueBox;
	public Text nameBox;

	private XmlDocument scene;
	private XmlNodeList dialogueList;
	private XmlNodeList speakerList;

	private int spTracker = 1;
	private int diaTracker = 0;
 
	void Start()
	{
	     scene = new XmlDocument();
	     scene.Load(dialogueFile);

  		 speakerList = scene.GetElementsByTagName("speaker");

 		 nameBox.text = speakerList[0].Attributes["character"].Value;
 		 dialogueBox.text = speakerList[0].ChildNodes[0].InnerText;
	}

	void Update()
	{
		if (Input.GetKeyDown("space") && dialogueBox.gameObject != null  && nameBox.gameObject != null)
		{
			if (spTracker == speakerList.Count)
			{
				Destroy(dialogueBox.gameObject);
				Destroy(nameBox.gameObject);
			}

			else
			{
				nameBox.text = speakerList[spTracker].Attributes["character"].Value;
				dialogueBox.text = speakerList[spTracker].ChildNodes[diaTracker].InnerText;

				if (diaTracker == speakerList[spTracker].ChildNodes.Count - 1)
				{
					spTracker++;
					diaTracker = 0;
				}

				else diaTracker++;
			}
		}
	}

}