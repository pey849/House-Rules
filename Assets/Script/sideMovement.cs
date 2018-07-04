using UnityEngine;
using System.Collections;

public class sideMovement : MonoBehaviour
{

    Rigidbody2D r_body;
    Animator anim;

    public float max_speed;
    public float max_jump;

    bool facing_right = true;

    //jump stuff
    bool grounded = true;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Vector2 start_pos = new Vector2(-12, -2);
    float y_min = -6;

    //multiplayer stuff
    public string jumpButton = "Jump_P1";
    public string horizCtrl = "Horizontal_P1";

    // Use this for initialization
    void Start()
    {
        r_body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get spacebar input and jump
        //button goes to name, key to key
        if (grounded && Input.GetButtonDown(jumpButton))
        {
            anim.SetBool("Ground", false);
            //jump - add force up
            r_body.AddForce(new Vector2(0, max_jump));
        }

    }

    void FixedUpdate()
    {
        //get left right
        float move = Input.GetAxis(horizCtrl);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", r_body.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));

        //add forces for movement
        r_body.velocity = new Vector2(move * max_speed, r_body.velocity.y);

        if (move > 0 && !facing_right)
            Flip();
        else if (move < 0 && facing_right)
            Flip();

        if (r_body.position.y < y_min)
        {
            r_body.position = start_pos;
            r_body.velocity = Vector2.zero;
        }
    }

    void Flip()
    {
        facing_right = !facing_right;
        Vector3 the_scale = transform.localScale;
        the_scale.x *= -1;
        transform.localScale = the_scale;
    }
}
