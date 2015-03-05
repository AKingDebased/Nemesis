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
		ai.Body.GetComponent<Fight>().currentTarget = ai.WorkingMemory.GetItem<GameObject>("targetEnemy");
		ai.Body.GetComponent<Fight>().engaged = true;
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}