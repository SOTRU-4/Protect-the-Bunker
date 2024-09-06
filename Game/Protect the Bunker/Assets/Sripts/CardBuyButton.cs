using TMPro;
using UnityEngine;

public class CardBuyButton : MonoBehaviour
{
    CardBuyerPoint point;
    [SerializeField] CardBase card;
    [SerializeField] int cardCost;
    [SerializeField] TextMeshProUGUI costText;
    public CardBuyer[] cardBuyer;

    private void Start()
    {
        costText.text = cardCost.ToString();
    }
    public void BuyTheCard()
    {
        foreach (var buyer in cardBuyer)
        {
            if (buyer.selectedCardBuyer != null)
            {
                point = buyer.Point;
                if (point.BuyedCard != null || MoneyWallet.currentMoney < cardCost)
                {
                    return;
                }
                MoneyWallet.currentMoney -= cardCost;

                point = buyer.selectedCardBuyer.Point;
                Vector2 spawnPoint = new Vector2(point.gameObject.transform.position.x, point.gameObject.transform.position.y);
                var spawnedCard = Instantiate(card, spawnPoint, Quaternion.identity);

                point.BuyedCard = card;

                buyer.Point.BuyedCard = spawnedCard;
                buyer.StopInteract();

            }
        }

        
    }
}
