using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIFuel : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.FuelChanged += OnFuelChanged;
    }

    private void OnDisable()
    {
        _player.FuelChanged -= OnFuelChanged;
    }

    private void OnFuelChanged(int fuel)
    {
        _slider.value = fuel;
    }
}
