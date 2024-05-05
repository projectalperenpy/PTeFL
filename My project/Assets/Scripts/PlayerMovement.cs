using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;




    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private BoxCollider2D boxCollider;
    public float horizontalInput;


    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();
        


    }


    


    private void Update()
    {


        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3((float)3.853515, (float)3.588508, (float)3.117731);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-(float)3.853515, (float)3.588508, (float)3.117731);
        }

        if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

        

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }



        if (horizontalInput < -0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);




        anim.SetBool("run", horizontalInput != 0);



        anim.SetBool("grounded", grounded);



    }

    private void Jump()
    {

        
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
            grounded = false;
    }

            






    }






