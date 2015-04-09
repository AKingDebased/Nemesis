using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ManageTarget : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject sensedTarget = ai.WorkingMemory.GetItem<GameObject>("sensedTarget");
		bool engaged = ai.WorkingMemory.GetItem<bool>("engaged");

		if(!engaged && sensedTarget != null){
			ai.Body.GetComponent<TargetManager>().AddTarget(sensedTarget,100);
		} else if (engaged && sensedTarget != null){
			ai.Body.GetComponent<TargetManager>().AddTarget(sensedTarget,0);
		} else {
			return ActionResult.FAILURE;
		}

		return ActionResult.SUCCESS;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}