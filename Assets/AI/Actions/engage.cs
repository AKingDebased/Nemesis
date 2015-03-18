using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Engage : RAINAction
{
	public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

		GameObject targetEnemy = ai.WorkingMemory.GetItem<GameObject>("targetEnemy");

		if(targetEnemy == null)
		{
			Debug.Log ("no target");
			return ActionResult.FAILURE;
		}

		ai.Body.GetComponent<PhysicalFight>().Fight(targetEnemy);


		return ActionResult.FAILURE;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}