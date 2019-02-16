using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGold : MonoBehaviour
{
    public GameObject goldPrefab;
    public int count = 30;
    public float range = 5;


    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            CreateRandomGold();
        }
        
    }

    private void CreateRandomGold()
    {
        Vector3 position = this.transform.position;
        Vector3 random = new Vector3(GetRandomFloat(), GetRandomFloat(), GetRandomFloat());
        position += random;

        Instantiate(goldPrefab, position, Quaternion.identity);
    }

    private float GetRandomFloat()
    {
        return UnityEngine.Random.Range(-range, range);
    }
}
