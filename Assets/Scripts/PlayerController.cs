using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Controls.playerEnum player;
    private Rigidbody2D rb;
    private const float MOVE_SPEED = 200.0f;
    private const float JUMP_DISTANCE = 800.0f;
    private const float MAX_VELOCITY_X = 4f;
    private const float MAX_VELOCITY_Y = 30.0f;
    private string joystick;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        joystick = "joystick " + (int)player;
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        //LimitVelocity();
	}

    private void LimitVelocity()
    {
        if(rb.velocity.x > MAX_VELOCITY_X)
        {
            rb.velocity = new Vector2(MAX_VELOCITY_X, rb.velocity.y);
        }
        if (rb.velocity.x < -MAX_VELOCITY_X)
        {
            rb.velocity = new Vector2(-MAX_VELOCITY_X, rb.velocity.y);
        }
        
    }

    private bool CheckGrounded()
    {
        Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y - 0.47f);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.down, 0.03f);
        return hit != false;
    }

    private void GetInput()
    {
        if (Input.GetAxis(joystick + "LeftTrigger") != 0f)
        {
            if (CheckGrounded())
            {
                float axis = Input.GetAxis(joystick + "LeftTrigger");
                rb.velocity = (new Vector2(rb.velocity.x, JUMP_DISTANCE * axis * Time.deltaTime));
            }
        }
        if (Input.GetAxis(joystick + "LeftStick") != 0f)
        {
            Debug.Log(MOVE_SPEED * Input.GetAxis(joystick + "LeftStick"));
            float axis = Input.GetAxis(joystick + "LeftStick");
            rb.velocity = (new Vector2(MOVE_SPEED * axis * Time.deltaTime,rb.velocity.y));
        }
        else if(CheckGrounded())
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        else if (!CheckGrounded())
        {
            rb.velocity += new Vector2(-rb.velocity.x * Time.deltaTime * 0.1f, 0);
        }
    }
}
