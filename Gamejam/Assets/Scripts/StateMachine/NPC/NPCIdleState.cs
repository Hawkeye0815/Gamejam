using System;
using UnityEngine;


[Serializable]
public class NPCIdleState : BaseState
{
    public float MinWaitTime;
    public float MaxWaitTime;

    private float leaveTime;
    private float waitForAttack;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnEnterState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        leaveTime = Time.time + UnityEngine.Random.Range(MinWaitTime, MaxWaitTime);
        npcStateMachine.SetAgentSpeedMultiplier(0f);
        waitForAttack = Time.time + 2f;
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Transitions
        // Can see or hear player > Switch to attack after waiting
        if(npcStateMachine.CanSeePlayer || npcStateMachine.CanHearPlayer) 
        {
            if (Time.time > waitForAttack)
            {
                npcStateMachine.SwitchToState(npcStateMachine.AttackState);
            }
            
        }
        // Time is up > Switch to patrol
        if(Time.time > leaveTime)
        {
            npcStateMachine.SwitchToState(npcStateMachine.PatrolState);
        }
    }

    
    
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnExitState");
    }
}
