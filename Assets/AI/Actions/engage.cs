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
		GameObject targetEnemy = ai.WorkingMemory.GetItem<GameObject>("targetEnemy");
		GameObject thisAdv = ai.Body;

		ai.Body.GetComponent<Warrior>().addToThreats(targetEnemy);
		ai.Body.GetComponent<Warrior>().Engage(targetEnemy);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}