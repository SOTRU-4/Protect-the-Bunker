using UnityEngine;

public class CardBuyer : MonoBehaviour, IInteractable
{
    public GameObject buyPanel;
    public CardBuyer selectedCardBuyer;
    [SerializeField] CardBuyerPoint point;
    public bool isCardFightable;
    public CardBuyerPoint Point 
    { 
        get 
        { 
            if (point != null)
            {
                return point;
            } else { return null; }
        } 
    }

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
