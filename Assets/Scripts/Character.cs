using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int health; //��駪��͵��prob �ѹ���ٵ� ����Ẻ���ǡѹ�������˹�ҵ����� [SerializeField]=���������
    public HealthBar healthBar;
    public int currentHealth;

    /*public void Init(int newHealth) //������Ҥ͹ʵ�ѡ�͡��Ẻ���᷹
    { Health = newHealth; }*/
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public Animator anim; //�������͹������
    public Rigidbody2D rb;

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
        //return Health <= 0;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(Health); //SetMaxHealth ����絵͹����� �ѹ�����ⴹ�������ͧ�Ѿ
        Debug.Log($"{this.name} took {damage} damage; Remaining Health: {this.Health}");
        IsDead();
    }



    public virtual void Init(int newHealth)
    {
        Health = newHealth;
        healthBar.SetMaxHealth(newHealth);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
}
