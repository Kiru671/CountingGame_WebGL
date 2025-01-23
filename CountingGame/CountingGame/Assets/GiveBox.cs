using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GiveBox : MonoBehaviour
{
    private GameObject box;
    private Plane plane = new Plane();
    private Rigidbody rb;

    public static event Action OnBoxGotten;
    public static event Action OnBoxDropped;

    private bool canGetBox = true;

    public void Start()
    {
        FillSlider.OnSliderFull += ResetBox;
    }

    public void GetBoxIntoWorld()
    {
        if (ChooseNextBox.currentBox == null)
            return;

        canGetBox = false;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); // Offset for correct depth
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        box = Instantiate(ChooseNextBox.currentBox, worldPosition, Quaternion.identity);
        rb = box.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        rb.isKinematic = true;
        
        OnBoxGotten?.Invoke();
    }

    public void DragBox()
    {
        if (ChooseNextBox.currentBox == null || box == null)
            return;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); // Offset for correct depth
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        box.transform.position = worldPosition;
    }

    public void DropBox()
    {
        if (ChooseNextBox.currentBox == null || rb == null)
            return;
        
        rb.freezeRotation = false;
        rb.useGravity = true;
        rb.isKinematic = false;

        box = null;
        OnBoxDropped?.Invoke();
    }

    private void ResetBox()
    {
        canGetBox = true;
    }
}
