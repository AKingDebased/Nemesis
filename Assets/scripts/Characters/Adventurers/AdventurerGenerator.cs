using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdventurerGenerator : MonoBehaviour
{
	Dictionary<string, string> heroInfo = new Dictionary<string, string>();

	private string[] homelands = {"of Rohan", "of Gondor", "of Angmar", "of Gondolin", "of Erebor"};
	private string[] archetypes = {"Warrior ", "Mage ", "Rogue "};
	private string[] heroClasses = {"Elite ", "Tank ", "DPS ", "Support "};
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

	
	void Awake()
	{
		heroInfo.Add("randomHomeland","");
		heroInfo.Add("randomArchetype","");
		heroInfo.Add("randomAdvClass","");
		heroInfo.Add("randomGender","");
	}

	void Start(){

	}

	void FreshHero()
	{
		heroInfo["randomHomeland"] = homelands[Random.Range(0, homelands.Length)];
		heroInfo["randomArchetype"] = archetypes[Random.Range(0, archetypes.Length)];
		heroInfo["randomAdvClass"] = heroClasses[Random.Range(0, heroClasses.Length)];			
		heroInfo["randomGender"] = genders[Random.Range(0, genders.Length)];
		adventurerName = GenerateName();
	}

	public Dictionary<string,string> GetHeroInfo()
	{
		return heroInfo;
	}

	string GenerateName()
	{
		return prefixes[Random.Range(0, 50)] + suffixes[Random.Range(0, 50)];
	}
}


