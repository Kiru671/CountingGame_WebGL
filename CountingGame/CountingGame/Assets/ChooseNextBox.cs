using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChooseNextBox : MonoBehaviour
{
    [SerializeField] private GameObject[] shownBoxes;
    [SerializeField] private GameObject[] boxPrefabs;
    
    private GameObject currentShownBox;
    public static GameObject currentBox;
    
    public event Action<GameObject> OnBoxSelected;
    
    void Start()
    {
        FillSlider.OnSliderFull += GetRandomBox;
        GiveBox.OnBoxGotten += DisableShownBox;
        GiveBox.OnBoxDropped += NullifyBox;
        GetRandomBox();
    }
    
    private void GetRandomBox()
    {
        int randInt = Random.Range(0, shownBoxes.Length);
        currentShownBox = shownBoxes[randInt];
        currentBox = boxPrefabs[randInt];
        foreach (var box in shownBoxes)
        {
            if(box != currentShownBox)
            {
                box.SetActive(false);
            }
            else
            {
                box.SetActive(true);
            }
        }
    }

    private void DisableShownBox()
    {
        currentShownBox.SetActive(false);
    }
    private void NullifyBox()
    {
        currentBox = null;
    }
}
