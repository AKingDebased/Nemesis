using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System.Linq;

[RAINAction]
public class WarEngage : RAINAction{
	
	public override void Start(RAIN.Core.AI ai){
		base.Start(ai);
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai){
		
		/*GameObject targetEnemy = ai.WorkingMemory.GetItem<GameObject>("targetEnemy");
		bool engaged = ai.WorkingMemory.GetItem<bool> ("engaged");
		
		if(targetEnemy == null){
			Debug.Log ("no target");
			return ActionResult.FAILURE;
		}
		
		if(targetEnemy != null && !engaged){
			ai.WorkingMemory.SetItem("engaged", true);

			ai.Body.GetComponent<WarriorFight>().Fight(targetEnemy, ()=> {
				ai.WorkingMemory.SetItem("engaged", false);
			});
		}

		if(!engaged && targetEnemy == null){
			Debug.Log("SUCCESS");
			return ActionResult.SUCCESS;
		} else {
			//calling failure once at start of script
			return ActionResult.FAILURE;
		}

		return ActionResult.RUNNING;*/
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai){
		base.Stop(ai);
	}
}