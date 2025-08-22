using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Landscape")]
public class LandscapeCard : Card
{
    public int manaBonus;
    public int durationTurns;

    public override void Play()
    {
        base.Play();
        // Logic landscape
    }
}
