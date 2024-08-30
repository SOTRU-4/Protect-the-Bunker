using UnityEngine;

public class CardBuyerPoint : MonoBehaviour
{
    public CardBase isCardBuyed;
    [SerializeField] GameObject cardBuyer;

    void Update()
    {
        if (isCardBuyed != null)
        {
            cardBuyer.SetActive(false);
        }
        else
        {
            cardBuyer.SetActive(true);
        }
    }
}
