using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] Transform CameraTransform;

    [SerializeField] Transform referenceObj;

    [SerializeField] float speed = 5;
    bool IsMoving = false;
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
            ObjectGenerated.transform.position = referenceObj.position;
            ObjectGenerated.transform.eulerAngles = referenceObj.eulerAngles;
        }
    }

    void Update()
    {
        if(IsMoving)
        {
            ObjectGenerated.transform.RotateAround(CameraTransform.position, Vector3.up, speed*Time.deltaTime);
        }
    }

    public void OnBtnPress()
    {
        IsMoving = !IsMoving;
    }
}
