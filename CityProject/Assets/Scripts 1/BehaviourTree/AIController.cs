using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour, IControllerInput, IBehaviourAI
{
    public event InputEvent FireEvent;
    public event InputEventFloat SlideEvent;
    public event InputEventFloat ForwardEvent;
    public event InputEventFloat YawEvent;
    public event InputEventFloat PitchEvent;
    public event InputEventFloat RollEvent;
    public event InputEventFloat SideStrafeEvent;
    public event InputEventFloat VerticalStrafeEvent;
    public event InputEventVector3 TurnEvent;

    public Vector3 myTargetPosition = Vector3.zero;

    //behaviour
    public Selector rootAI;
    public Sequence CheckArrivalSequence;
    public Sequence MoveSequence;


    void Start()
    {

        CheckArrivalSequence = new Sequence(new List<BTNode>
        {
            new CheckArrivalTask(this),
            new FindWanderPointTask(this, 500f),
        });

       MoveSequence = new Sequence(new List<BTNode>
        {
            new TurnToTargetTask(this, TurnEvent),
            new MoveToTargetTask(this, 100f, ForwardEvent),
        });

        rootAI = new Selector(new List<BTNode>
        {
            CheckArrivalSequence,
            MoveSequence
        });


        new FindWanderPointTask(this, 500f);
    }
    void Update()
    {
        rootAI.Evaluate();
    }
    public Vector3 SetTargetPosition(Vector3 targetPosition)
    {
        myTargetPosition = targetPosition;
        return myTargetPosition;
    }

    public Transform GetAgentTransform()
    {
        return transform;
    }

    public Vector3 GetTargetPosition()
    {
        return myTargetPosition;
    }
}
