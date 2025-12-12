using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    public Vector2 moveInput { get; set; }

    public bool IsAiming{ get; set;}

    void Awake()
    {
        IsAiming = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateMovementAnimation();
        UpdateAimingAnimation();
    }

    private void UpdateAimingAnimation()
    {
        animator.SetBool("IsAiming", IsAiming);
        animator.SetLayerWeight(1, IsAiming ? 1f : 0f);
    }

    private void UpdateMovementAnimation()
    {
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveZ", moveInput.y);
    }
}
