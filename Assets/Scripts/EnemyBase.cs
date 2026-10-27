using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Base Parameters")]
    [SerializeField] private int lives;
    [SerializeField] private float moveSpeed;

    private PlayerBehaviour playerRef;
    private Vector3 playerPos;

    private void Start()
    {
        playerRef = GameManager.instance.Player;
    }

    private void Update()
    {
        playerPos = (playerRef.transform.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
    }
}
