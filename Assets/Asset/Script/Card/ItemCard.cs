using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Item")]
public class ItemCard : Card
{
    public CardEffect equipEffect;
    public bool isEquipment;

    public override void Play()
    {
        base.Play();
        equipEffect?.Execute();
    }
}
