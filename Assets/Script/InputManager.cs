using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    private InputAction Walk;
    private InputAction Jump;
    private InputAction Shoot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SetDefaultWalkInput();
        SetDefaultJumpInput();
        SetDefaultShootInput();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void SetDefaultWalkInput()
    {
        Walk = new InputAction("Walk", InputActionType.Value);
        Walk.AddCompositeBinding("2DVector(mode=2)")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
    }

    private void SetDefaultJumpInput()
    {
        Jump = new InputAction("Jump", InputActionType.Button);
        Jump.AddBinding("<Keyboard>/space");
    }

    private void SetDefaultShootInput()
    {
        Shoot = new InputAction("Shoot", InputActionType.Button);
        Shoot.AddBinding("<Mouse>/leftButton");
    }

    public InputAction GetWalk()
    {
        return Walk;
    }

    public InputAction GetJump()
    {
        return Jump;
    }

    public InputAction GetShoot()
    {
        return Shoot;
    }

    public void Enable()
    {
        Walk.Enable();
        Jump.Enable();
        Shoot.Enable();
    }

    public void Disable()
    {
        Walk.Disable();
        Jump.Disable();
        Shoot.Disable();
    }

    public void Dispose()
    {
        Walk.Dispose();
        Jump.Dispose();
        Shoot.Dispose();
    }

    public void OnEnable()
    {
        Enable();
    }

    public void OnDisable()
    {
        Disable();
    }

  


}
