using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButtonManager : MonoBehaviour
{
    private int sequenceCounter = 0;

    public void DamageCharacter()
    {
        var pooledObjects = ObjectPooler.SharedInstance.pooledObjectsList;

        List<GameObject> cardsInHand = new List<GameObject>();

        foreach (var pooledList in pooledObjects)
        {
            foreach (var pooledObject in pooledList)
            {
                if (pooledObject.activeSelf)
                {
                    cardsInHand.Add(pooledObject);
                }
            }

        }

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            if (i == sequenceCounter)
            {
                var cardDisplay = cardsInHand[i].GetComponent<CardDisplay>();

                cardDisplay.Hp -= Random.Range(9, 2);
                cardDisplay.HealthText.text = cardDisplay.Hp.ToString();

                if (cardDisplay.Hp < 1)
                {
                    cardsInHand[i].SetActive(false);
                }
            }

        }

        sequenceCounter = (sequenceCounter + 1) % cardsInHand.Count;
    }
}
