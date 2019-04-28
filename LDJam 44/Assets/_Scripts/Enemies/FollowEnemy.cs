using UnityEngine;

public class FollowEnemy : MonoBehaviour {

    public GameObject player;
    private float speed = 3;

    public bool canFollow;

    private int EnemyLife = 4;
    private int Damage = 2;

    private float repelTime = 0.1f;
    private float maxRepelTime = 0.1f;
    private bool isRepeling;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerThings");
    }

    private void Update()
    {
        if(canFollow && !isRepeling)
        {
            Movement();
        }

        if(isRepeling)
        {
            Repel();
        }
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void CheckLife()
    {
        if(EnemyLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Repel()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -3 * speed * Time.deltaTime);
        repelTime -= Time.deltaTime;
        if(repelTime <= 0)
        {
            isRepeling = false;
            repelTime = maxRepelTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Sword")
        {
            EnemyLife -= other.GetComponent<SwordDamage>().Damage;
            CheckLife();
            isRepeling = true;
        }

        if(other.tag == "PlayerThings")
        {
            other.GetComponent<PlayerLife>().Life -= Damage;
        }
    }
}
