using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public InputManager.playerEnum player;
    private Rigidbody2D rb;
    private const float MOVE_SPEED = 5.0f;
    private bool jumped = false;
    private bool shot = false;
    private bool canShoot = true;
    private Vector2 jumpVector = new Vector2(0, 350);
    private float xMov, yMov, xAim, yAim;
    private float shootDelay = 0.1f;
    public float totalDamage= 0.0f;
    public GameObject shotIndicator;
    public GameObject bulletPrefab;
    public GameObject spawnLocation;
    public GameControl.Teams team;
    public float health = 10f;
    public PlayerController teammate;
    public Buffs buffs;

    public int playersHit;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        buffs = GetComponent<Buffs>();
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    private void FixedUpdate()
    {
        if (jumped)
        {
            jumped = false;
            rb.AddForce(jumpVector);
        }

        if (shot)
        {
            shot = false;
            GameObject go = Instantiate(bulletPrefab, spawnLocation.transform.position, shotIndicator.transform.rotation);
            go.GetComponent<Bullet>().damage *= buffs.damage;
            go.GetComponent<Bullet>().originatingPlayer = this;
            go.transform.Translate(go.transform.forward);
        }

        transform.Translate(xMov, yMov, 0);
        var angle = new Vector3(0, 0, Mathf.Atan2(xAim, yAim) * 180 / Mathf.PI);
        shotIndicator.transform.eulerAngles = angle;
    }

    private bool CheckGrounded()
    {
        Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y - 0.47f);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.down, 0.03f);
        return hit != false;
    }

    private void GetInput()
    {
        //Jump
        if (InputManager.GetButtonDown(player, "Jump"))
        {
            if (CheckGrounded())
            {
                jumped = true;
            }
            else
            {
                Debug.Log(player.ToString() + " couldn't jump");
            }
        }

        //Switch Weapons
        if (InputManager.GetButtonDown(player, "SwitchWeapons"))
        {
            Debug.Log(player.ToString() + " changed weapons");
        }

        if(InputManager.GetAxis(player, "Shoot") > 0.5f)
        {
            if (canShoot)
            {
                canShoot = false;
                shot = true;
                Invoke("SetCanShoot", shootDelay);
            }
        }
        else
        {
            shot = false;
        }

        xMov = InputManager.GetAxis(player, "Horizontal") * MOVE_SPEED * buffs.speed * Time.deltaTime;
        yMov = -InputManager.GetAxis(player, "Vertical") * MOVE_SPEED * buffs.speed * Time.deltaTime;
        xAim = -InputManager.GetAxis(player, "Horizontal2") * MOVE_SPEED * Time.deltaTime;
        yAim = -InputManager.GetAxis(player, "Vertical2") * MOVE_SPEED * Time.deltaTime;
    }

    private void SetCanShoot()
    {
        canShoot = true;
    }

    public void HitPlayer()
    {
        playersHit += 1;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Debug.Log("Died");
        }
    }

    public void RecordDamage(float damage)
    {
        totalDamage += damage;
    }
}
