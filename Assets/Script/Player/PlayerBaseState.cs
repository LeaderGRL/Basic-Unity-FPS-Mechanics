using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerManager player);
    public abstract void UpdateState(PlayerManager player);
    public abstract void OnCollisionEnterState(PlayerManager player, Collision collision);
    public abstract void HandleInputState(PlayerManager player, InputAction.CallbackContext context);
}
