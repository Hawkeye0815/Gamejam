using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections.Generic;

[Serializable]
public class NPCPatrolState : BaseState
{

    public List<Transform> Waypoints = new List<Transform>();

    private int _currentWaypointIndex;

    private Vector3 _targetPosition;

    private int RandomIndex;
    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCPatrolState:OnEnterState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        Waypoints = (List<Transform>)Variables.ActiveScene.Get("Path");
        RandomIndex = npcStateMachine.RandomIndex();

        if (_targetPosition == Vector3.zero) 
        {
            _targetPosition = Waypoints[0].position;
        }

        npcStateMachine.SetDestination(_targetPosition);
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCPatrolState:OnUpdateState");

        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Transitions
        // NPC reached waypoint? > Switch to idle
        float sqrtDistance = (npcStateMachine.transform.position - _targetPosition).sqrMagnitude;
        if(sqrtDistance < 1f) 
        {
            _targetPosition = GetNextWaypoint();
            npcStateMachine.SwitchToState(npcStateMachine.IdleState);
        }

        // Transitions
        // Can see player > Switch to flee
        if (npcStateMachine.CanSeePlayer || npcStateMachine.CanHearPlayer)
        {
            npcStateMachine.SwitchToState(npcStateMachine.AttackState);
        }
    }
    public override void OnTriggerEnter(BaseStateMachine controller, Collision collision)
    {

    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCPatrolState:OnExitState");
    }

    public Vector3 GetNextWaypoint() 
    {


         
        return Waypoints[RandomIndex].position;
    }
}
//_currentWaypointIndex = ++_currentWaypointIndex % Waypoints.Count;
