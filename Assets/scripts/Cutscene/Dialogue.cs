using System;
using UnityEngine;
using System.IO;
using System.Xml;
 
 
public class Dialogue : MonoBehaviour
{
	public string localizedStringsFile;
	string language;
	string grouping;
	XmlDocument root;
	XmlNamespaceManager nsmgr;
 
	void Start ()
	{
	     // Get the file into the document.
	     root = new XmlDocument();
	     root.Load(localizedStringsFile);

	     nsmgr = new XmlNamespaceManager(root.NameTable);

	     
	 
	     language = root.SelectSingleNode ("scene/characterlist/character").InnerText;
	     grouping = root.SelectSingleNode ("scene/characterlist/character").InnerText;
	 
	}

	 /* 
	 * <summary>Retrieves the string by its ID. Only works when the referenced file
	 * is both monolingual and monogrouped. Will throw a NullReference Exception
	 * when the file doesn't meet the requirements.</summary>
	 * <param name="id">The ID of the requested string.</param>
	 * <returns>A string with the required text.</returns>
	 */

	public string GetText (string id)
	{
	  try {
	      if (language == "multilingual" || grouping == "multi") {
	           throw new NullReferenceException ("The referenced file is" + "multilangual and/or multigrouped.");
	     } else {
	           string n = root.SelectSingleNode ("localizableStrings" + "/group/string[@id='" + id + "']/text").InnerText;
	            return n;
	      }
	 
	   } catch (NullReferenceException ex) {
	      string s = "Missing string (" + ex.ToString () + ")";
	      return s;
	  }
	}
}