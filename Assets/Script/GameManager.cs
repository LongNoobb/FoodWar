using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private List<GameObject> listLand;
    [SerializeField] private List<GameObject> listZone;
    [SerializeField] private List<GameObject> listLandUserPlay;

    private void Awake()
    {
        instance = this;
    }



    public void SpawnLand()
    {

    }
}
