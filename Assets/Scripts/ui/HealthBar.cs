using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    [SerializeField]
    private TMP_Text hpIndicator;
    [SerializeField]
    private PlayerHealth health;

    private void Update()
    {
        if (health != null)
        {
            hpIndicator.SetText($"{health.currentHealth}/{150}");//����currentHealthÿ֡���ڸ��£����Բ��ܷ���Awake�
        }
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
