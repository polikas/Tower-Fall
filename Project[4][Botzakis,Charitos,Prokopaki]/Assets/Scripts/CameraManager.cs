using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] currentCamera = new GameObject[4];

    private void Awake()
    {
        
        currentCamera[3].gameObject.SetActive(false);
        currentCamera[1].gameObject.SetActive(false);
        currentCamera[2].gameObject.SetActive(false);
        currentCamera[0].gameObject.SetActive(true);
    }

    public void rightCamera()
    {
        currentCamera[3].gameObject.SetActive(true);
        currentCamera[1].gameObject.SetActive(false);
        currentCamera[0].gameObject.SetActive(false);
        currentCamera[2].gameObject.SetActive(false);
    }

    public void leftCamera()
    {
        currentCamera[1].gameObject.SetActive(true);
        currentCamera[3].gameObject.SetActive(false);
        currentCamera[0].gameObject.SetActive(false);
        currentCamera[2].gameObject.SetActive(false);
    }

    public void frontCamera()
    {
        currentCamera[0].gameObject.SetActive(true);
        currentCamera[1].gameObject.SetActive(false);
        currentCamera[3].gameObject.SetActive(false);
        currentCamera[2].gameObject.SetActive(false);
    }

    public void backCamera()
    {
        currentCamera[2].gameObject.SetActive(true);
        currentCamera[1].gameObject.SetActive(false);
        currentCamera[0].gameObject.SetActive(false);
        currentCamera[3].gameObject.SetActive(false);
    }
}
