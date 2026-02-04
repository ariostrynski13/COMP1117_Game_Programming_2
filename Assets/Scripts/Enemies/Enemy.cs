using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] private float patrolDistance = 5.0f;

    private Vector2 startPos; //Staring position
    private int direction = 1; //Direction my enemy is facing
    protected override void Awake()
    {
        base.Awake();

        //Could remove this because we are not doing anything specific, but we are keeping it 
        // to make changes in the future
        startPos = transform.position;
    }

    private void Update()
    {
        //Calculate the boundaries of my movement
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;

        //Move my enemy
        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);
        
        //Flip the enemy when it hits a boundary
        if(transform.position.x >= rightBoundary)
        {
            direction = -1; //gO to the left
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1; //Go to the right
            transform.localScale = new Vector3(-1, 1, 1);
        }
           
    }

    public override void Die()
    {
        Debug.Log("Enemy has died!");

        //Enemy death logic!!!
        //==========================
        //Award points / loot to the player
        //Player death animation
        //Destroy the enemy
    }
}
