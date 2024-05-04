using UnityEngine;

public class mainplayercontroler : MonoBehaviour
{
    public  Animator animator; // Karakterin Animator bileşeni
    Rigidbody2D rb; // Karakterin Rigidbody2D bileşeni
    Vector3 velocity;
    float speedAmount = 4f;
        

    void Start()
    {
        // Rigidbody2D bileşenini alıyoruz
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity*speedAmount*Time.deltaTime;
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
           transform.rotation = Quaternion.Euler(0f,0f,0f); 
        }
    }
}
