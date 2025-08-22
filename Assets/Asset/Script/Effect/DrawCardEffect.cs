using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Draw Card Effect")]
public class DrawCardEffect : CardEffect
{
    public int numberOfCards;

    public override void Execute()
    {
        // Logic draw
        Debug.Log($"Drawing {numberOfCards} cards");
    }
}
