using UnityEngine;

public class PlayerStats
{

    //Private Fields
    private float moveSpeed;
    private int maxHealth;
    private int currentHealth;

    //Public properties
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        
        set
        {
            if(value > 20)
            {
                moveSpeed = 20;
            }
            else
            {
                moveSpeed = value;
            }
                
        }
    }

    public int MaxHealth
    {
        get {  return maxHealth; }
        set { maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set 
        {
            currentHealth = Mathf.Clamp(value, 0, 100);
            Debug.Log($"Health set to: {currentHealth}");
            //currentHealth = value; 
        }
    }

    //Constructor
    //Default constructor -- no parameters
    public PlayerStats()
    {
        moveSpeed = 10;
        maxHealth = 100;
        currentHealth = 100;
    }

    public PlayerStats(float moveSpeed, int maxHealth)
    {
        this.moveSpeed = moveSpeed;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;

        Debug.Log($"Player initialized with Movespeed = {moveSpeed}, MaxHealth = {maxHealth}, CurrentHealth = {currentHealth}");
    }
}
