using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.instance.selectedCard = this;
    }

    public void StopInteract()
    {
        GameManager.instance.selectedCard = null;
    }

    public void DeleteCard()
    {
        Destroy(GameManager.instance.selectedCard.gameObject);
    }
}
