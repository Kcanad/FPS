using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public float health;

    public void TakeDamege(float amount)
    {
        health= amount;
        if (health <= 0)
            Die();
    }

    
    void Die()
    {
        Destroy(gameObject);
    }
}
