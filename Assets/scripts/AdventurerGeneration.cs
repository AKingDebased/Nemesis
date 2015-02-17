using UnityEngine;
using System.Collections;

public class AdventurerGeneration : MonoBehaviour
{
	private int[] hero = {0, 0, 0, 0};

	private string[] homelands = {"of Rohan", "of Gondor", "of Angmar", "of Gondolin", "of Erebor"};
	private string[] archetypes = {"Warrior ", "Mage ", "Rogue "};
	private string[] classes = {"Elite ", "Tank ", "DPS ", "Support "};
	private string[] genders = {"Male ", "Female "};

	private string adventurerName;

	/* Name components -- 50 each, for now, for 2500 possible permutations */
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

	
		void Start ()
		{
			this.freshHero();
			Debug.Log(getNamePlate());
		}

		int[] getHero()
		{
			return hero;
		}

		void freshHero()
		{
			hero[0] = Random.Range(0, homelands.Length);
			hero[1] = Random.Range(0, archetypes.Length);
			hero[2] = Random.Range(0, classes.Length);
			hero[3] = Random.Range(0, genders.Length);
			adventurerName = generateName();
		}
	
		void Update ()
		{	
		}

		string generateName()
		{
			return prefixes[Random.Range(0, 50)] + suffixes[Random.Range(0, 50)];
		}

		string getNamePlate()
		{
			string whois = adventurerName + ", " + genders[hero[3]] + classes[hero[2]] + archetypes[hero[1]] + homelands[hero[0]];
			return whois;
		}
}