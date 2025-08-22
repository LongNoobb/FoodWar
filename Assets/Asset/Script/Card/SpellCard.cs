using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Spell")]
public class SpellCard : Card
{
    public CardEffect spellEffect;
    public bool isInstant;

    public override void Play()
    {
        base.Play();
        spellEffect?.Execute();
    }
}
