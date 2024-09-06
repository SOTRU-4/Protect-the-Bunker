using UnityEngine;

public class CardBuyerPoint : MonoBehaviour
{
    public CardBase BuyedCard;
    [SerializeField] GameObject cardBuyer;

    void Update()
    {
        if (BuyedCard != null)
        {
            cardBuyer.SetActive(false);
        }
        else
        {
            cardBuyer.SetActive(true);
        }
    }
}
