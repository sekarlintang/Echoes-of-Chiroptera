using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public Animator animator;
    float horizontalMove = 0f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        body.velocity = new Vector2(horizontalMove, body.velocity.y);
        animator.SetFloat("Speed", horizontalMove);
        if (Input.GetButtonDown("Vertical"))
        {
            animator.SetBool("Down", true);
        }
        if (Input.GetButtonUp("Vertical"))
        {
            animator.SetBool("Down", false);
        }
        
    }
}