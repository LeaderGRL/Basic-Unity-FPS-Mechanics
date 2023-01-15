using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    private PlayerBaseState currentState;

    [SerializeField] private Player player;

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

        currentState = new PlayerIdleState();
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
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
        currentState = state;
        currentState.EnterState(this);
    }

    public void HandleInput(CallbackContext callBackInput)
    {
        currentState.HandleInputState(this, callBackInput);
    }

    public Player GetPlayer()
    {
        return player;
    }
}
