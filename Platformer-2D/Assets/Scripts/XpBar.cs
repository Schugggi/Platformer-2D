using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField] public Slider Slider;
    [SerializeField] public PlayerHealth playerXp;
    // Start is called before the first frame update
    void Start()
    {
        Slider.value = playerXp.xp;
        Slider.maxValue = playerXp.xpNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = playerXp.xp;
        Slider.maxValue = playerXp.xpNeeded;
    }
}
