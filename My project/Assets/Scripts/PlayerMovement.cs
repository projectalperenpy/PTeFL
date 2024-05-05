using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
<<<<<<< HEAD
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
=======
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
>>>>>>> d483fd54828908c6de7ca15a07a48dd0928447c0
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
         body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
<<<<<<< HEAD
        {
            transform.localScale = new Vector3((float)3.853515, (float)3.588508, (float)3.117731);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-(float)3.853515, (float)3.588508, (float)3.117731);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
=======
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
>>>>>>> d483fd54828908c6de7ca15a07a48dd0928447c0

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
<<<<<<< HEAD
        anim.SetBool("grounded", grounded);

=======
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (!isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
        }
>>>>>>> d483fd54828908c6de7ca15a07a48dd0928447c0
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
=======
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0;
>>>>>>> d483fd54828908c6de7ca15a07a48dd0928447c0
    }
}