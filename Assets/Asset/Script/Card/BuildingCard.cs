using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Building")]
public class BuildingCard : Card
{
    public int health;
    public int dame;
    public CardEffect continuousEffect;

    public override void Play()
    {
        base.Play();
        // Logic building
    }
}
