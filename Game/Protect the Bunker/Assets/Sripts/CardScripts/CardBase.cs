using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject interactPanel;
    public void Interact()
    {
        interactPanel.SetActive(true);
    }

    public void StopInteract()
    {
        interactPanel.SetActive(false);
    }

    public void DeleteCard()
    {
        Destroy(gameObject);
    }
}
