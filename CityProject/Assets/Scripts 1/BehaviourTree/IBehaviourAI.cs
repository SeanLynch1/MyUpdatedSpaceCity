using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviourAI 
{

    Vector3 SetTargetPosition(Vector3 targetPosition);
    Transform GetAgentTransform();
    Vector3 GetTargetPosition();
    
}
