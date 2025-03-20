using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] TextMeshProUGUI textdata;
    [SerializeField] Vector3 Pos;

    private GameObject ObjectGenerated;
    [SerializeField]
    private ARTrackedImageManager aRTrackedImageManager; 
    void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;  
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage a in args.added)
        {
            ObjectGenerated = Instantiate(prefab);
            ObjectGenerated.transform.position = Pos;
            textdata.text = "Cube Generated";
        }
    }
}
