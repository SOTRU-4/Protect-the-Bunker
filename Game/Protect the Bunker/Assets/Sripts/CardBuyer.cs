using UnityEngine;

public class CardBuyer : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject buyPanel;

    public void Interact()
    {
        buyPanel.SetActive(true);
    }

    public void StopInteract()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
