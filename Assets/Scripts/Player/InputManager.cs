using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CannonController controller;
    [SerializeField] private MouseLook mouseLook;
    private CannonControls controls;
    private CannonControls.CannonActions cannonAction;

    private Vector2 moveInput;
    private Vector2 mouseInput;


    private void Awake()
    {
        controls = new CannonControls();
        cannonAction = controls.Cannon;

        cannonAction.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();

        cannonAction.Shoot.performed += _ => controller.Shoot();

        cannonAction.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        cannonAction.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        controller.ReceiveInput(moveInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
