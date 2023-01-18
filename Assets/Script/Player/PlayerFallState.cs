using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFallState : PlayerBaseState
{
    private Player player;
    public override void EnterState(PlayerManager player)
    {
        Debug.Log("Entered Fall State");
        this.player = player.GetPlayer();
        //throw new System.NotImplementedException();
    }

    public override void FixedUpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    public override void HandleInputState(PlayerManager player, InputAction.CallbackContext context)
    {
        Debug.Log("Handling Input Fall State !!!!!!!!!!!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        Debug.Log("Collision : " + collision.gameObject.name);
        //throw new System.NotImplementedException();
        if (!collision.gameObject.CompareTag("Ground"))
        {
            return;
            //player.TransitionToState(player.IdleState);
        }

        if (this.player.GetComponent<Rigidbody>().velocity.x > 0)
        {
            player.SwitchState(player.GetWalkState());
        }
        else
        {
            player.SwitchState(player.GetIdleState());
        }
    }

    public override void UpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
