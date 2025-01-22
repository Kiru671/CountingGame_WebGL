using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNextBox : MonoBehaviour
{
    [SerializeField] private GameObject[] boxes;
    private GameObject currentBox;
    void Start()
    {
        FillSlider.OnSliderFull += GetRandomBox;
    }
    
    void Update()
    {
        
    }
    
    private void GetRandomBox()
    {
        if (currentBox != null)
        {
            Destroy(currentBox);
        }
        currentBox = boxes[Random.Range(0, boxes.Length)];
    }
    
    public void GetBoxIntoWorld()
    {
        Debug.Log("DRAG");
    }

    public void DragBox()
    {
        Debug.Log("OH NO I'M BEING DRAGGED AAHHH!!!");
    }
}
