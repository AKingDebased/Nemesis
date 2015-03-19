using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdventurerGenerator : MonoBehaviour
{
	static Dictionary<string, string> advInfo = new Dictionary<string, string>();

	private static string[] homelands = {"of Rohan", "of Gondor", "of Angmar", "of Gondolin", "of Erebor"};
	private static string[] archetypes = {"Warrior ", "Mage ", "Rogue "};
	private static string[] heroClasses = {"Elite ", "Tank ", "DPS ", "Support "};
	private static string[] genders = {"Male ", "Female "};

	private string adventurerName;

	/* Name components -- 50 each, for now, for 2500 possible permutations */
	private static string[] prefixes = {"Sel", "Frei", "Hum", "Tru", "Ar", "O", "Bren", "Kur", "Lau", "Pin",
	"Tol", "Der", "Char", "Sha", "For", "Gran", "Mul", "Mar", "Bin", "War",
	"Var", "Hil", "Sen", "Mor", "Len", "Bro", "Rein", "Rho", "Skal", "Wes",
	"Corr", "Garri", "Mont", "Ji", "Aeo", "Clar", "Vik", "Yo", "Laur", "Ern",
	"Aul", "Sudi", "Em", "Rae", "Sa", "Lu", "A", "Al", "Tel", "Sor"};

	private static string[] suffixes = {"de", "helm", "hardt", "sen", "bert", "ith", "win", "ley", "mon", "no",
	"tain", "co", "kle", "min", "mian", "fel", "ven", "kar", "gue", "elia",
	"lyn", "ble", "cien", "lan", "ris", "ma", "gus", "ent", "dis", "feld",
	"cheim", "soll", "greim", "kern", "ander", "odak", "osch", "asch", "bel", "da",
	"riette", "anda", "torin", "asara", "ish", "er", "kentz", "eres", "arch", "nos"};

	void Awake()
	{
		advInfo.Add ("name","");
		advInfo.Add("homeland","");
		advInfo.Add("archetype","");
		advInfo.Add("advClass","");
		advInfo.Add("gender","");
	}

	public static Dictionary<string,string> FreshHero()
	{
		advInfo["name"] = GenerateName();
		advInfo["homeland"] = homelands[Random.Range(0, homelands.Length)];
		advInfo["archetype"] = archetypes[Random.Range(0, archetypes.Length)];
		advInfo["advClass"] = heroClasses[Random.Range(0, heroClasses.Length)];			
		advInfo["gender"] = genders[Random.Range(0, genders.Length)];

		return advInfo;
	}

	private static string GenerateName()
	{
		return prefixes[Random.Range(0, 50)] + suffixes[Random.Range(0, 50)];
	}
}