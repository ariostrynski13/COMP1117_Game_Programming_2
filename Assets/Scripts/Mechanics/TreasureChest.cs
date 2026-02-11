using UnityEngine;

public class TreasureChest : MonoBehaviour, IInteractable
{
    [Header("Loot Settings")]
    [SerializeField] private GameObject gemPrefab; // "______Prefab" is convention
    [SerializeField] private int gemCount = 3;  // How many gems get spawnedd from the chest
    [SerializeField] private float launchForce = 5f;  // Force behind launching gems

    [Header("Visuals")]
    [SerializeField] private Sprite openChestSprite; // Sprite for an open chest

    private SpriteRenderer sRend;
    private bool isOpened = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>(); // Cashing your reference
    }

    public void Interact()
    {
        //Safety Check
        if(isOpened)
        {
            //If my chest is already opened, do nothing and leave
            return;
        }

        //Chest is not Opened
        isOpened = true;
        OpenChest();
    }

    private void OpenChest()
    {
        // 1. Change Visual State to open
       if(sRend != null && openChestSprite != null)
       {
           sRend.sprite = openChestSprite;
       }

        // 2. Spew Gems
        for(int i = 0; i < gemCount; i++)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            Rigidbody2D gemRB = gem.GetComponent<Rigidbody2D>();

            // Safety Check
            if(gemRB != null)
            {
                //Launch it up into the air
                //Create a fountain effect
                Vector2 force = new Vector2(Random.Range(-1f, 1f), 1.5f).normalized * launchForce;
                gemRB.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}
