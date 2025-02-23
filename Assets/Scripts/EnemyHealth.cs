using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotVFX;
    [SerializeField] int startingHealth = 3;
    int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0) 
        {
            Instantiate(robotVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
