using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    //Private variables
    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField]private int currentHealth;
    
    protected bool isDead = false;
    protected Animator anim;

    //Public properties
    public float MoveSpeed
    {
        //Read-only
        get { return moveSpeed; }
    }

    public bool IsDead
    {
        //Read-only
        get { return isDead; }
    }

    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth);}
    }


    protected virtual void Awake()
    {
        Debug.Log("Awake in Characer.cs");
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        //Level of protection
        if(isDead)
        {
            return;
        }

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} HP is now: {CurrentHealth}");

        if(CurrentHealth <= 0)
        {
            Die();
        }

    }

    //Each child object will implement their own death.
    public abstract void Die();
}
