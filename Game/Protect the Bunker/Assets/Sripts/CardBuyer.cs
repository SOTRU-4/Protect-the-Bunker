using UnityEngine;

public class CardBuyer : MonoBehaviour, IInteractable
{
    public GameObject buyPanel;
    public CardBuyer selectedCardBuyer;
    [SerializeField] CardBuyerPoint point;
    public CardBuyerPoint Point { get { return point; } }
    public void Interact()
    {
        buyPanel.SetActive(true);
        selectedCardBuyer = this;
    }

    public void StopInteract()
    {
        buyPanel?.SetActive(false);
        selectedCardBuyer = null;
    }

}
