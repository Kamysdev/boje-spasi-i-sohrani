using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1, 100)] public float playerSpeed;
    [SerializeField][Range(1f, 5f)] public float runningSpeed = 1.5f;

    [Header("Weapon Settings")]
    [SerializeField] public WeaponSelector weaponSelector;
    [SerializeField] public WeaponScript weaponScript;
    [SerializeField] public int numberOfWeapons = 2;

    private Camera mainCamera;
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private PlayerAnimationController playerAnimationController;

    private float gravite = -9.81f;
    private bool isGrounded;
    private Vector3 velocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        mainCamera = Camera.main;
        weaponScript.setWeapon(weaponSelector.getSelectedWeapon());
    }

    void Start()
    {
        velocity = new Vector3(0, 0, 0);
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void LateUpdate()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            velocity.y = 0f;
        }

        velocity.y += gravite * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            playerSpeed *= runningSpeed;
        }
        else if (callbackContext.canceled)
        {
            playerSpeed /= runningSpeed;
        }
    }

    public void OnAiming(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (!playerAnimationController.IsAiming)
            {
                weaponScript.setWeapon(weaponSelector.selectWeaponByIndex(0));
            }
            else
            {
                weaponSelector.SetWeaponFalse();
                weaponScript.setWeapon(null);
            }
            playerAnimationController.IsAiming = !playerAnimationController.IsAiming;
        }
    }

    public void OnWeaponSelect(InputAction.CallbackContext ctx)
    {
        if (int.TryParse(ctx.control.name, out int num))
        {
            if (num >= 1 && num <= numberOfWeapons)
            {
                weaponScript.setWeapon(
                    weaponSelector.selectWeaponByIndex(num - 1)
                );
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (!playerAnimationController.IsAiming) return;

        if (ctx.performed)
        {
            weaponScript.fireStart();
        }
        else if (ctx.canceled)
        {
            weaponScript.fireEnd();
        }
    }

    private void MovePlayer()
    {
        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 localMove = Quaternion.Inverse(transform.rotation) * velocity;

        velocity = velocity.normalized * playerSpeed * Time.deltaTime;

        playerAnimationController.moveInput = new Vector2(localMove.x, localMove.z);

        characterController.Move(velocity);
    }

    private void RotatePlayer()
    {
        Vector2 loockDirection = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(loockDirection);
        Plane plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            Vector3 lookAtPoint = hitPoint - transform.position;
            lookAtPoint.y = 0;

            if (lookAtPoint.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(lookAtPoint);
            }
        }
    }
}