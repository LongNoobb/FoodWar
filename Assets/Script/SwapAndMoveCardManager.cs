using System.Collections.Generic;
using UnityEngine;

public class SwapAndMoveCardManager : MonoBehaviour
{
    [SerializeField] SwipeManager swipeManager;
    [SerializeField] List<SwapCard> swapCards;
    [SerializeField] GameObject handSign;
    [SerializeField] GameObject text;
    [SerializeField] GameObject button;

    private void Start()
    {
        swipeManager.enabled=false;
        handSign.SetActive(false);
    }
    public void TurnOffSwapCard()
    {
        foreach(SwapCard swapCard in swapCards)
        {
            swapCard.enabled=false;
        }
        swipeManager.enabled = true;
        handSign.SetActive(true);
        text.SetActive(false);
        button.SetActive(false);
    }

    public void AddSwapableCard(SwapCard card)
    {
        swapCards.Add(card);
    }


}
