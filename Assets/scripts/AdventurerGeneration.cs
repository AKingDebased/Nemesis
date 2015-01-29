using UnityEngine;
using System.Collections;

public class AdventurerGeneration : MonoBehaviour
{
	private bool isElite;

	private int homeland;
	/* LEGEND
	 * (If it isn't obvious, these are placeholders)
	 * 0 - Rohan
	 * 1 - Gondor
	 * 2 - Angmar
	 * 3 - Gondolin
	 * 4 - Erebor
	 */
	
	private int archetype;
	/* LEGEND
	 * 0 - Warrior
	 * 1 - Mage
	 * 2 - Rogue
	 */

	private int adventurerClass;
	/* LEGEND
	 * 0 - Elite
	 * 1 - Tank
	 * 2 - DPS
	 * 3 - Support
	 */

	private bool gender;
	/* LEGEND
	 * True - Male
	 * False - Female
	 */

	private string adventurerName;
	/* Eowyn I am, Eomund's daughter */

	private string[] prefixes = {"Sel", "Frei", "Hum", "Tru", "Ar", "O", "Bren", "Kur", "Lau", "Pin",
	"Tol", "Der", "Char", "Sha", "For", "Gran", "Mul", "Mar", "Bin", "War",
	"Var", "Hil", "Sen", "Mor", "Len", "Bro", "Rein", "Rho", "Skal", "Wes",
	"Corr", "Garri", "Mont", "Ji", "Aeo", "Clar", "Vik", "Yo", "Laur", "Ern",
	"Aul", "Sudi", "Em", "Rae", "Sa", "Lu", "A", "Al", "Tel", "Sor"};

	private string[] suffixes = {"de", "helm", "hardt", "sen", "bert", "ith", "win", "ley", "mon", "no",
	"tain", "co", "kle", "min", "mian", "fel", "ven", "kar", "gue", "elia",
	"lyn", "ble", "cien", "lan", "ris", "ma", "gus", "ent", "dis", "feld",
	"cheim", "soll", "greim", "kern", "ander", "odak", "osch", "asch", "bel", "da",
	"riette", "anda", "torin", "asara", "ish", "er", "kentz", "eres", "arch", "nos"};
	/* Name components -- 50 each, for now, for 2500 possible permutations */

	
		void Start ()
		{
			for (int i = 0; i < 5; i++)
			{
				homeland = Random.Range(0, 5);
				archetype = Random.Range(0, 3);
				adventurerClass = Random.Range(0, 4);
				adventurerName = generateName();
				gender = Random.Range(0, 2) > 0;
				Debug.Log(getNamePlate());
			}
		}
	
		void Update ()
		{	
		}

		string generateName()
		{
			/* MEGALLY EAT YOUR HEART OUT */
			return prefixes[Random.Range(0, 50)] + suffixes[Random.Range(0, 50)];
		}

		string getNamePlate()
		{
			string whois = adventurerName + ", ";
			if (gender)
				whois = whois + "Female ";
			else
				whois = whois + "Male ";

			switch (archetype)
			{
				case 0:
					whois = whois + getClass(0) + " of ";
					break;

				case 1:
					whois = whois + getClass(1) + " of ";
					break;

				case 2:
					whois = whois + getClass(2) + " of ";
					break;
			}

			switch (homeland)
			{
				case 0:
					whois = whois + "Rohan";
					break;

				case 1:
					whois = whois + "Gondor";
					break;

				case 2:
					whois = whois + "Angmar";
					break;

				case 3:
					whois = whois + "Gondolin";
					break;

				case 4:
					whois = whois + "Erebor";
					break;
			}

			return whois;
		}

		string getClass(int type)
		{
			switch(adventurerClass)
			{
				case 0: //Elites
					switch (type)
					{
						case 0:
							return "Elite Warrior";
						case 1:
							return "Elite Mage";
						case 2:
							return "Elite Rogue";
					}
					break;

				case 1: //Tanks
					switch (type)
					{
						case 0:
							return "Knight";
						case 1:
							return "Cleric";
						case 2:
							return "Monk";
					}
					break;

				case 2: //DPS
					switch (type)
					{
						case 0:
							return "Berserker";
						case 1:
							return "Sorcerer";
						case 2:
							return "Assassin";
					}
					break;

				case 3: //Supports
					switch (type)
					{
						case 0:
							return "Ranger";
						case 1:
							return "Enchanter";
						case 2:
							return "Thief";
					}
					break;
			}

			return "INVALID CLASS (REPORT THIS!)";
		}
}