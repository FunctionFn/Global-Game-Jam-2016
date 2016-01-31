using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CheckDistance : RAINAction
{
    EnemyScript script;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        script = ai.Body.GetComponent<EnemyScript>();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        ai.WorkingMemory.SetItem<float>("distance", script.CheckDist());
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}