using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpState : PlayerBaseState
{
    private Player player;
    public override void EnterState(PlayerManager player)
    {
        //this.player.playerRigidbody.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
        Debug.Log("Jump State");
        this.player = player.GetPlayer();
        this.player.Jump();
    }

    public override void FixedUpdateState(PlayerManager player)
    {
        
    }

    public override void HandleInputState(PlayerManager player, InputAction.CallbackContext context)
    {
        Debug.Log("Jump !!!!!!!!!!!!!!!!!!!!!!!!!!!!");

    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerManager player)
    {
        if (this.player.gameObject.GetComponent<Rigidbody>().velocity.y < 0)
        {
            player.SwitchState(player.GetFallState());
            //player.TransitionToState(player.fallState);
        }
        //Debug.Log(this.player.gameObject.GetComponent<Rigidbody>().velocity.y);
        // throw new System.NotImplementedException();
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
