using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Heal Effect")]
public class HealEffect : CardEffect
{
    public int healAmount;

    public override void Execute()
    {
        // Logic heal
        Debug.Log($"Healing {healAmount} health");
    }
}
