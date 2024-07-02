using System;
using UnityEngine;


[Serializable]
public class NPCIdleState : BaseState
{
    public float MinWaitTime;
    public float MaxWaitTime;

    private float leaveTime;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnEnterState");

        leaveTime = Time.time + UnityEngine.Random.Range(MinWaitTime, MaxWaitTime);
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Transitions
        // Can see or hear player > Switch to flee
        if(npcStateMachine.CanSeePlayer || npcStateMachine.CanHearPlayer) 
        {
            npcStateMachine.SwitchToState(npcStateMachine.AttackState);
        }
        // Time is up > Switch to patrol
        if(Time.time > leaveTime)
        {
            npcStateMachine.SwitchToState(npcStateMachine.PatrolState);
        }
    }

    public override void OnCollisionEnter(BaseStateMachine controller, Collision collision)
    {

    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnExitState");
    }
}
