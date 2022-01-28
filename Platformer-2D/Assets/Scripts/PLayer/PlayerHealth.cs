using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int xp;                   //Player Experience and Levels
    public int xpNeeded = 100;
    private int level;

	public int health = 100;
	private int fullHealth = 100;

	public GameObject deathEffect;
    public HealthBar healthBar;
	public Slider xpBar;
	public PlayerAttack playerDamage;
	public XpBar xpNumbers;

    private void Start() {
		health = fullHealth;
        healthBar.SetMaxHealth(fullHealth);
    }

	public void TakeDamage(int damage)
	{
		health -= damage;
        healthBar.SetHealth(health - damage);

		StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
    public void addExperience(int addXp)
    {
        xp += addXp;
		xpNumbers.showXpNumbers(addXp);

        while(xp >= xpNeeded)
        {
			xp -= xpNeeded;
			addLevel();
        }
    }

	public void addLevel()
    {
		level++;
		xpNeeded += 20;
		fullHealth += 15;
		health = fullHealth;
		healthBar.SetMaxHealth(fullHealth);
		xpBar.maxValue = xpNeeded;
		playerDamage.playerDamage += 5;
	}
}
