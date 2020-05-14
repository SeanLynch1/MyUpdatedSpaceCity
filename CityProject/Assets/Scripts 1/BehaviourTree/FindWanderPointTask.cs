﻿using UnityEngine;
using System.Collections;

public class FindWanderPointTask : BTNode
{

    float range;
    IBehaviourAI myAI;

    public FindWanderPointTask (IBehaviourAI _myAI, float _range)
    {
        range = _range;
        myAI = _myAI;
    }

    public override BTNodeStates Evaluate()
    {
        myAI.SetTargetPosition(Random.insideUnitSphere * range);

        return BTNodeStates.SUCCESS;
    }
}