using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    private PlayerBaseState currentState;

    private PlayerIdleState idleState = new PlayerIdleState();
    private PlayerWalkState walkState = new PlayerWalkState();
    private PlayerJumpState jumpState = new PlayerJumpState();
    private PlayerFallState fallState = new PlayerFallState();

    [SerializeField] private Player player;

    public CallbackContext inputContext;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

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

    public static PlayerManager GetInstance()
    {
        return instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnterState(this, collision);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
       
    }

    //public void HandleInput(CallbackContext callBackInput)
    //{
    //    inputContext = callBackInput;
    //    currentState.HandleInputState(this, callBackInput);
    //}

    public Player GetPlayer()
    {
        return player;
    }

    public PlayerIdleState GetIdleState()
    {
        return idleState;
    }

    public PlayerWalkState GetWalkState()
    {
        return walkState;
    }

    public PlayerJumpState GetJumpState()
    {
        return jumpState;
    }

    public PlayerFallState GetFallState()
    {
        return fallState;
    }
}
