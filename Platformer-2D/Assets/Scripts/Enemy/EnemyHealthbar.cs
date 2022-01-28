using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] public Slider Slider;
    //[SerializeField] public PlayerAttack Player;
    [SerializeField] public BossHealth Enemy;
    [SerializeField] public Vector3 Offset;

    void Start()
    {
        //Slider.gameObject.active = false;
        Slider.value = Enemy.health;
        Slider.maxValue = Enemy.health;
    }

    void Update()
    {
        if (Enemy.health > Enemy.currentHealth)
        {
            Slider.gameObject.active = true;
        }
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        Slider.value = Enemy.currentHealth;
    }
}
