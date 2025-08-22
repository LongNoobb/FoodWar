using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Damage Effect")]
public class DameEffect : CardEffect
{
    public int damageAmount;

    public override void Execute()
    {
        // Logic dame
        Debug.Log($"Dealing {damageAmount} damage");
    }
}
