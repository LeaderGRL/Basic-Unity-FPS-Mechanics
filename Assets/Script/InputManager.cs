using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    private InputAction Walk;
    private InputAction Jump;

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

        Walk = new InputAction("Walk", InputActionType.Value);
        Walk.AddCompositeBinding("2DVector(mode=2)")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        Jump = new InputAction("Jump", InputActionType.Button);
        Jump.AddBinding("<Keyboard>/space");
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

    public InputAction GetWalk()
    {
        return Walk;
        Debug.Log("Walk");
    }

    public InputAction GetJump()
    {
        return Jump;
    }

    public void Enable()
    {
        Walk.Enable();
        Jump.Enable();
    }

    public void Disable()
    {
        Walk.Disable();
        Jump.Disable();
    }

    public void Dispose()
    {
        Walk.Dispose();
        Jump.Dispose();
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
