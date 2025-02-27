using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotVFX;
    [SerializeField] int startingHealth = 3;
    [SerializeField] AudioSource sound;

    int currentHealth;

    GameManager gameManager;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            PlaySoundDetached();
            SelfDestruct();
        }
    }

    private void PlaySoundDetached()
    {
        GameObject soundObject = new GameObject("EnemyDeathSound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = sound.clip;
        audioSource.volume = sound.volume;
        audioSource.pitch = sound.pitch;
        audioSource.Play();
        Destroy(soundObject, audioSource.clip.length); 
    }

    public void SelfDestruct()
    {
        PlaySoundDetached();
        gameManager.AdjustEnemiesLeft(-1);
        Instantiate(robotVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
