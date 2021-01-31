using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// simple script to update loading progress, use on Canvas Prefab with a UI Slider
public class LoadProgressBar : MonoBehaviour {


    //reference to UI Slider
    [SerializeField]
    private Slider _slider;

    // actual progress value reported by SceneManager AsyncOperation
    private float _targetProgressValue;

    // used to tell other objects what our slider currently reads
    public float sliderValue;

    // the asynchronous load ends at 0.1f, so you may want to pad the value so the bar fills out correctly
    private const float paddingValue = 0.15f;

    // speed to animate the progress bar
    private const float _lerpSpeed = 0.3f;

	private void Start()
	{
        if (_slider == null)
        {
            _slider = gameObject.GetComponentInChildren<Slider>();    
        }
        InitSlider();
	}

    public void UpdateProgress(float progressValue)
    {
        if (_slider != null)
        {
            _targetProgressValue = progressValue + paddingValue;
        }
    }

	public void InitSlider()
	{
        sliderValue = 0f;
	}

	// because the async progress reported by Unity does not smoothly animate, we can lerp to show some progress bar movement
	private void Update()
	{
        if (_slider != null)
        {
            if (Mathf.Abs(_slider.value - _targetProgressValue) > .01f)
            {
                _slider.value = Mathf.Lerp(_slider.value, _targetProgressValue, _lerpSpeed);
                sliderValue = _slider.value;
            }
        }
	}



}
