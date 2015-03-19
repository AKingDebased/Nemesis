using System;
using System.Xml;

using UnityEngine;
using UnityEngine.UI;
 
public class Dialogue : MonoBehaviour
{
	public string dialogueFile;
	public Text dialogueText;
	public Text nameText;

	private XmlDocument scene;
	private XmlNodeList dialogueList;
	private XmlNodeList speakerList;

	private int spTracker = 1;
	private int diaTracker = 0;

	private bool speakerA = true;
 
	void Start()
	{
	     scene = new XmlDocument();
	     scene.Load(dialogueFile);

  		 speakerList = scene.GetElementsByTagName("speaker");

 		 nameText.text = speakerList[0].Attributes["character"].Value;
 		 dialogueText.text = speakerList[0].ChildNodes[0].InnerText;
	}

	void Update()
	{
		if (Input.GetKeyDown("space") && this.gameObject != null)
		{
			if (spTracker == speakerList.Count)
			{
				Destroy(this.gameObject);
			}

			else
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
	}

}