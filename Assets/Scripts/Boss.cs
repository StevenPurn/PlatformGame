using UnityEngine;

public class Boss : MonoBehaviour {

    private float health = 100f;
    private float rotationTimer = 10f;
    private float rotationTime;
    private bool rotating;
    private Vector3 targetRotation;
    public float rotationSpeed = 0.3f;

	// Use this for initialization
	void Start ()
    {
        rotationTime = rotationTimer;
        targetRotation = new Vector3(0, 0, 180);
	}
	
	// Update is called once per frame
	void Update ()
    {

        rotationTime -= Time.deltaTime;

        if(rotationTime <= 0)
        {
            rotating = true;
        }
        if (rotating)
        {
            Rotate();
        }
	}

    void Rotate()
    {
        transform.Rotate(targetRotation);
        rotationTime = rotationTimer;
        rotating = false;
    }

    public void TakeDamage(float damage, PlayerController playerCon)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("killed by " + playerCon.player.ToString() + " on team " + playerCon.team.ToString());
        }
    }
}
