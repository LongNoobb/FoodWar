using UnityEngine;

public abstract class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public int landscapeCost;
    public Sprite artwork;

    public virtual void Play()
    {
        Debug.Log($"Playing card: {cardName}");
    }

    public virtual bool CanPlay()
    {
        return true;
    }
}
