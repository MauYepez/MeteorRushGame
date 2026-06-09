using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 1f;

    public float rotationSpeed = 100f;

    private Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (transform.position.y < -8f || Mathf.Abs(transform.position.x) > 10f)
        {
            Destroy(gameObject);
        }

    }

    // Called from MeteorSpawner to know where the player is
    public void Initialize(Vector3 playerPosition)
    {
        moveDirection = (playerPosition - transform.position).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHitByMeteor();
            Destroy(gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
