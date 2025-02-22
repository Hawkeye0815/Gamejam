using System;
using UnityEngine;
using Unity.VisualScripting;


[Serializable]
public class NPCAttackState : BaseState
{
    public float damage;
    private Vector3 _attackPosition;
     
    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCAttackState:OnEnterState");
        
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCAttackState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        _attackPosition = npcStateMachine.PlayerPosition;
        
       



            if (!npcStateMachine.CanSeePlayer && !npcStateMachine.CanHearPlayer)
            {
                npcStateMachine.SwitchToState(npcStateMachine.IdleState);
            }
            else
            {
                npcStateMachine.SetDestination(_attackPosition);
                npcStateMachine.SetAgentSpeedMultiplier(1f);
            }
       

    }


    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCAttackState:OnExitState");
    }
}