using UnityEngine;

public class EnemyActivationArea : MonoBehaviour {

    public FollowEnemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerThings")
        {
            enemy.canFollow = true;
            Destroy(gameObject);
        }
    }
}
