using System;
using UnityEngine;
using Unity.VisualScripting;


[Serializable]
public class NPCAttackState : BaseState
{
    public int damage;
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
            //npcStateMachine.SwitchToState(npcStateMachine.IdleState);
        }
        else
        {
            npcStateMachine.SetDestination(_attackPosition);
            npcStateMachine.SetAgentSpeedMultiplier(2.5f);
        }


    }

    public override void OnCollisionEnter(BaseStateMachine controller, Collision collision)
    {
        Debug.Log("NPCAttackState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        GameObject other = collision.gameObject;
        if(other.CompareTag("Player"))
        {
            int Health = (int)Variables.Object(other).Get("PlayerHealth");
            Variables.Object(other).Set("PlayerHealth", Health - damage);

            npcStateMachine.SwitchToState(npcStateMachine.IdleState);
        }
    }

    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCAttackState:OnExitState");
    }
}