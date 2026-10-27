using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform player;
    public Vector3 playerPosition;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        playerPosition = player.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, 5f * Time.deltaTime); //MoveTowards(current, target, max distance)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
