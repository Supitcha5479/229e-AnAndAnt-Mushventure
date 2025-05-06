using UnityEngine;

public class Trap2 : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    private void OnTriggerEnter2D(Collider2D other) //use Trigger
    {
        Character player = other.GetComponent<Character>();
        if (player != null && player.CompareTag("Player")) // ��Ǩ����繼�����
        {
            player.TakeDamage(damage);
            Debug.Log("Player took damage from trap!");
        }
    }
}
