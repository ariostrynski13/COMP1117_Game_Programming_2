using UnityEngine;

public class NPCLogic : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject speechBubble;
  public void Interact()
    {
        //Safety Check
        if(speechBubble == null)
        {
            //If the speech bubble doesnt exist, resturn immedietly and do nothing
            return;
        }

        //Speech bubble does exist!!
        bool isCurrentlyActive = speechBubble.activeSelf;
        
        speechBubble.SetActive(!isCurrentlyActive);
        Debug.Log("Npc Interraction toggled");
    }
}
