using UnityEngine;

public class Bullet : MonoBehaviour {

    public PlayerController originatingPlayer;
    private float speed = 7.0f;
    private float lifeTime = 4.0f;
    [SerializeField]
    public float damage = 1f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,1,0) * speed * Time.deltaTime);	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player") 
        {
            PlayerController playerCon = collision.transform.GetComponent<PlayerController>();
            if(playerCon == originatingPlayer || playerCon.team == originatingPlayer.team)
            {
                return;
            }
            originatingPlayer.HitPlayer();
            playerCon.TakeDamage(damage);
            Destroy(gameObject);
        }else if(collision.transform.tag == "Boss")
        {
            Boss boss = collision.transform.GetComponent<Boss>();
            originatingPlayer.RecordDamage(damage);
            boss.TakeDamage(damage, originatingPlayer);
            Destroy(gameObject);
        }
    }
}
