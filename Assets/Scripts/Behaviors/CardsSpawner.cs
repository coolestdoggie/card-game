using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class CardsSpawner : MonoBehaviour
{
    [SerializeField] int amountCardOnStart = 6;
    [SerializeField] Vector2 pos = new Vector2(0, -3.6f);
    [SerializeField] float angle = 45;

    public int AmountCardsOnStart { get => amountCardOnStart; set => amountCardOnStart = value; }

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
        amountCardOnStart = Random.Range(4, 6);
        SpawnStartCards();
    }

    private void SpawnStartCards()
    {
        for (int i = 0; i < AmountCardsOnStart; i++)
        {
            SpawnNextCards();
        }
    }

    private void SpawnNextCards()
    {
        GameObject pooledItem = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, 5));
        pooledItem.SetActive(true);
        pooledItem.transform.position = pos;

        int activePooledObjects = 0;
        var pooledObjects = ObjectPooler.SharedInstance.pooledObjectsList;

        foreach (var pooledList in pooledObjects)
        {
            foreach (var pooledObject in pooledList)
            {
                if (pooledObject.activeSelf)
                {
                    activePooledObjects++;
                }
            }

        }

        for (int i = 0; i < activePooledObjects; i++)
        {
            ArcPosition(pooledItem, i);
        }

    }

    private void ArcPosition(GameObject item, int rotatedCards)
    {
        float totalTwist = -angle;
        float twistPerCard = totalTwist / amountCardOnStart;
        float startTwist = -1f * (totalTwist / 2f);
        float twistForThisCard = startTwist + (rotatedCards * twistPerCard);
        item.transform.DORotate(new Vector3(0f, 0f, twistForThisCard), 1f);
    }

}
