using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public string effectDescription;
    public abstract void Execute();
}


[CreateAssetMenu(menuName = "Effects/Damage Effect")]
public class DamageEffect : CardEffect
{
    public int damageAmount;

    public override void Execute()
    {
        // Logic deal dame
        Debug.Log($"Dealing {damageAmount} damage");
    }
}