﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DetailsSettings
{
    [System.Serializable]
    public class Layer{
        public GameObject[] prefabs;
        public float radius = 6;
        public int numSamplesBeforeRejection = 30;
        public float minHeight;
        public float maxHeight;
    }

    public Layer[] layers;
    public float maxHeight = 500;
    public bool debug = true;

}
