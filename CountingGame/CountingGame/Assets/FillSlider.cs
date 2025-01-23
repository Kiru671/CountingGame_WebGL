using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FillSlider : MonoBehaviour
{
    public static event Action OnSliderFull;
    
    [SerializeField] private Slider slider;
    [SerializeField] private float fillTime = 5f;

    void Start()
    {
        StartCoroutine(FillSliderOverTime(fillTime));
    }
    
    private IEnumerator FillSliderOverTime(float time)
    {
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            slider.value = Mathf.Lerp(0, 1, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        slider.value = 1f;
        OnSliderFull?.Invoke();
        
        StartCoroutine(FillSliderOverTime(time));
    }
}
