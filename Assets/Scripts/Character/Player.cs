using UnityEngine.Events;
using UnityEngine;

public class Player : Rocket
{
    [SerializeField] private Dissolver[] _rockets;
    [SerializeField] private ParticleSystem _swapRocketEffect;

    private int _minFuel = 1;
    private int _maxFuel = 100;
    private int _currentModel;

    public event UnityAction<int> FuelChanged;

    private void Start()
    {
        _currentModel = (_rockets.Length * _fuel - 1) / _maxFuel;
        FuelChanged?.Invoke(_fuel);
        SwitchRocketModel();
    }

    public override void Damage()
    {
        base.Damage();
        FuelChanged?.Invoke(_fuel);
        SwitchRocketModel();
    }

    public void AddFuel(int fuel)
    {
        _fuel += fuel;
        _fuel = Mathf.Clamp(_fuel, _minFuel, _maxFuel);
        FuelChanged?.Invoke(_fuel);
        SwitchRocketModel();
    }

    private void SwitchRocketModel()
    {
        var FuelLevel = (_rockets.Length * _fuel - 1) / _maxFuel;

        if (FuelLevel != _currentModel)
        {
            var swapRocketEffect = Instantiate(_swapRocketEffect, transform);
            Destroy(swapRocketEffect.gameObject, swapRocketEffect.main.duration);
            _rockets[_currentModel].Dissolve();
            _currentModel = FuelLevel;
            _rockets[_currentModel].Resolve();
        }
    }
}