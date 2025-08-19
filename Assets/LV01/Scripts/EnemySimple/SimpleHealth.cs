using UnityEngine;

public class SimpleHealth : MonoBehaviour
{
    Player player;
    Enemy enemy;
    public int maxHealth = 3;
    public int currentHealth;
    void Awake()
    {
        player = FindAnyObjectByType<Player>();
        enemy = GetComponent<Enemy>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0) Destroy(gameObject);
    }
}
