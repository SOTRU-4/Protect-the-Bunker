using UnityEngine;

public class CardBuyButton : MonoBehaviour
{
    CardBuyerPoint point;
    [SerializeField] CardBase card;
    public CardBuyer[] cardBuyer;
    public void BuyTheCard()
    {
        foreach (var buyer in cardBuyer)
        {
            if (buyer.selectedCardBuyer != null)
            {
                point = buyer.Point;
                if (point.isCardBuyed != null)
                {
                    return;
                }
                point = buyer.selectedCardBuyer.Point;
                Vector2 spawnPoint = new Vector2(point.gameObject.transform.position.x, point.gameObject.transform.position.y);
                var spawnedCard = Instantiate(card, spawnPoint, Quaternion.identity);

                point.isCardBuyed = card;

                buyer.Point.isCardBuyed = spawnedCard;
                buyer.StopInteract();

            }
        }

        
    }
}
