using UnityEngine;
using System;

public class LambdaTester : MonoBehaviour {
	Func<int,bool> lambdaTest = x => x == 1;
	bool engaged = true;
	int health = 5;

	void Start (){

	}
}


	


