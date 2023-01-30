using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStateManager : MonoBehaviour
{
    private static GunStateManager instance;
    private GunBaseState currentState;

    private GunIdleState idleState = new GunIdleState();
    private GunShootState shootState = new GunShootState();
    private GunReloadState reloadState = new GunReloadState();

    [SerializeField] private Gun gun;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
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

    public static GunStateManager GetInstance()
    {
        return instance;
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

    public GunReloadState GetReloadState()
    {
        return reloadState;
    }

    public Gun GetGun()
    {
        return gun;
    }
}
