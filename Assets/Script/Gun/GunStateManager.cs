using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStateManager : MonoBehaviour
{
    private GunStateManager instance;
    private GunBaseState currentState;

    private GunIdleState idleState = new GunIdleState();
    private GunShootState shootState = new GunShootState();

    [SerializeField] private Gun gun;

    public GunStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GunStateManager();
            }
            return instance;
        }
    }

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnterState(this, collision);
    }

    public void SwitchState(GunBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public GunBaseState GetCurrentState()
    {
        return currentState;
    }

    public GunIdleState GetIdleState()
    {
        return idleState;
    }

    public GunShootState GetShootState()
    {
        return shootState;
    }

    public Gun GetGun()
    {
        return gun;
    }
}
