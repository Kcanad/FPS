using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : Bar
{
    [SerializeField] private Shoot _playerShootinhg;
    
    private void OnEnable()
    {
        _playerShootinhg.AmmopChanged += OnValueChanged;
        Slider.value = 1;
    }

    
    private void OnDisable()
    {
        _playerShootinhg.AmmopChanged -= OnValueChanged;
    }
}
