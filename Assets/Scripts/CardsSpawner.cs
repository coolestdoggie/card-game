using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsSpawner : MonoBehaviour
{
    [SerializeField] int amountCardOnStart = 6;
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 pos = new Vector2(0, -3.6f);

    public int AmountPlatformsOnStart { get => amountCardOnStart; set => amountCardOnStart = value; }
    public Vector2 Offset { get => offset; set => offset = value; }

    //private void OnEnable()
    //{
    //    Platforms.PlatformDisappeared += SpawnNextPlatform;
    //}

    //private void OnDisable()
    //{
    //    Platforms.PlatformDisappeared -= SpawnNextPlatform;
    //}

    void Start()
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    SpawnUsualCard();
        //}
        SpawnStartCards();
    }

    private void SpawnStartCards()
    {
        for (int i = 0; i < AmountPlatformsOnStart; i++)
        {
            SpawnNextCards();
        }
    }

    private void SpawnNextCards()
    {
        GameObject pooledItem = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, 5));
        pooledItem.SetActive(true);
        pooledItem.transform.position = pos;

        pos += Offset;
    }

    //private void SpawnUsualCard()
    //{
    //    GameObject pooledItem = ObjectPooler.SharedInstance.GetPooledObject(0);
    //    pooledItem.SetActive(true);
    //    pooledItem.transform.position = pos;

    //    pos += Offset;
    //}
}
