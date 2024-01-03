﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_ObjectPool : MonoBehaviour
{
    public static MJB_ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 7;

    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}