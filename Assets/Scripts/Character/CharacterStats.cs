using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    public Stat damage;
    //public Stat armor;

    public event System.Action<int,int> OnHealthChanged;
    private void Awake() {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;

        if (this != null)
            Debug.Log(transform.name + " Takes " + damage + " damage. ");
        
        if(OnHealthChanged != null)
            OnHealthChanged(maxHealth, CurrentHealth);
        
        if(CurrentHealth <= 0)
            Die();           
    }
    public void TakeHeal(int heal)
    {
        heal = Mathf.Clamp(heal, 0, int.MaxValue);

        CurrentHealth += heal;

        if (this != null)
            Debug.Log(transform.name + " Takes " + heal + " heal. ");
        
        if(OnHealthChanged != null)
            OnHealthChanged(maxHealth, CurrentHealth);
        
        if(CurrentHealth >= maxHealth)
            CurrentHealth = maxHealth;        
    }

    public virtual void Die()
    {
        print(transform.name + " Died. ");
    }
}
