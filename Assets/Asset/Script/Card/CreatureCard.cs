using UnityEngine;

[CreateAssetMenu(fileName = "CreatureCard", menuName = "Scriptable Objects/CreatureCard")]
public class CreatureCard : Card
{
    public int attack;
    public int health;
    public bool hasFloop;
    public CardEffect floopEffect;

    private bool isFlooped = false;

    public void Floop()
    {
        if (hasFloop && !isFlooped)
        {
            floopEffect?.Execute();
            isFlooped = true;
            Debug.Log($"{cardName} used Floop!");
        }
    }

    public override void Play()
    {
        base.Play();
        // Logic creature
        isFlooped = false;
    }
}
