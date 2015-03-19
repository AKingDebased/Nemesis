using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CheckRange : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {	

		ai.WorkingMemory.SetItem<bool>("inRange", InRange(ai));

		return ActionResult.SUCCESS;
    }

	private bool InRange(RAIN.Core.AI ai){
		GameObject target = ai.WorkingMemory.GetItem<GameObject>("target");
		float range = ai.Body.GetComponent<Stats>().range;

		return target != null && 
			Vector3.Distance(target.transform.position, ai.Body.transform.position) <= range; //MAGIC NUMBER OH NO
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}