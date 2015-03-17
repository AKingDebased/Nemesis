using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class engage : RAINAction
{
	public override void Start(RAIN.Core.AI ai)
    {
		base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.Body.GetComponent<PhysicalFight>().Fight(ai.WorkingMemory.GetItem<GameObject>("targetEnemy"));
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}