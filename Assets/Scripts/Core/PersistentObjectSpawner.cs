﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject persistentObjectPrefab;

    static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned) return;

        SpawnPersistenObjects();
        hasSpawned = true;
    }

    private void SpawnPersistenObjects()
    {
        GameObject persistentObject = Instantiate(persistentObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}