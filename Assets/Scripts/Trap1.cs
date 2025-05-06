using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision) //No Trigger
    {
        Character player = collision.collider.GetComponent<Character>();
        if (player != null && player.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Debug.Log("Player took damage from trap!");
        }
    }
}
