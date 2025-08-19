using UnityEngine;

public class DamageSource : MonoBehaviour
{
    Player player;
    void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            SimpleHealth enemyHealth = other.gameObject.GetComponent<SimpleHealth>();
            enemyHealth.TakeDamage(player.damageAmount);
        }

    }
}
