using UnityEngine;
using Unity.VisualScripting;
using System.Collections.Generic;

/// <summary>
/// Base class for all state machines
/// </summary>
public abstract class BaseStateMachine : MonoBehaviour
{
    // State that is currently being executed
    public BaseState CurrentState { get; protected set; }
    public int index { get; protected set; }

    public List<Transform> Waypoints = new List<Transform>();

    void Start()
    {
        Initialize();
        Waypoints = (List<Transform>)Variables.ActiveScene.Get("Path");
        
    }

    void Update()
    {        
        CurrentState?.OnUpdateState(this);
        Tick();
        index = Random.Range(0, Waypoints.Count);
    }

    /// <summary>
    /// Change to a given state
    /// </summary>
    /// <param name="nextState">Next state</param>
    public void SwitchToState(BaseState nextState) 
    {
        CurrentState?.OnExitState(this);
        CurrentState = nextState;
        CurrentState.OnEnterState(this);
    }

    /// <summary>
    /// Called when statemachine started
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Called every frame 
    /// </summary>
    public abstract void Tick();
}
