using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsSpawner : MonoBehaviour
{
    [SerializeField] int amountCardOnStart = 6;
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 pos = new Vector2(0, -3.6f);
    [SerializeField] float angle = 45;

    public int AmountCardsOnStart { get => amountCardOnStart; set => amountCardOnStart = value; }
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
        amountCardOnStart = Random.Range(4, 6);
        SpawnStartCards();
      //  ArcPosition();
    }

    //private static void ArcPosition()
    //{
    //    float totalTwist = -60f;
    //    float twistPerCard = totalTwist / spawnedCards.Length;
    //    float startTwist = -1f * (totalTwist / 2f);
    //    float twistForThisCard = startTwist + (howManyAdded * twistPerCard);
    //    card.DORotate(new Vector3(0f, 0f, twistForThisCard), 1f); //Поворот с помощью ассета DOTween
    //}

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

        pos += Offset;

        //transform.Rotate(pooledItem.transform.position, angle);
    }
}
