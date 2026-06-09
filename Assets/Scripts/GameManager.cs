using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxHealth = 3;
    int currentHealth;

    int score = 0;

    public TextMeshProUGUI scoreText;
    public HealthUI healthUI;

    public AudioSource audioSource;
    public AudioClip enemyExplosionSound;
    public AudioClip playerExplosionSound;
    public AudioClip playerHitSound;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        ScoreUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ScoreUI()
    {
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        score += 10;
    }

    public void PlayerHitByBullet()
    {
        if (isGameOver)
        {
            return;
        }

        audioSource.PlayOneShot(playerHitSound);

        currentHealth--;
        healthUI.RemoveIcon();

        if (currentHealth <= 0)
        {
            TriggerGameOver();
        }
    }

    public void PlayerHitByMeteor()
    {
        if (isGameOver)
        {
            return;
        }
        TriggerGameOver();
    }

    public void EnemyDestroyed(Vector3 position)
    {
        if (audioSource != null && enemyExplosionSound != null)
        {
            audioSource.PlayOneShot(enemyExplosionSound);
        }

        ScoreUI();
    }

    void TriggerGameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;

        if (audioSource != null && playerExplosionSound != null)
        {
            audioSource.PlayOneShot(playerExplosionSound);
        }

        // Small delay 
        Invoke(nameof(ReloadScene), 0.5f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
