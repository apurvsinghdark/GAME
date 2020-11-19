using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public void Awake() {
        if(instance != null)
        {
            DontDestroyOnLoad(instance);
        }
        else
        {
            instance = this;
        }
    }
    
    public GameObject axe;
    public GameObject sword;
    public GameObject hammer;

    Weapon[] currentWeapon;
    Inventory inventory;
    CharacterAnimator characterAnimator;

    public delegate void OnEquipmentChanged(Weapon newWeapon, Weapon oldWeapon);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start() {
        inventory = Inventory.instance;
        characterAnimator = CharacterAnimator.instance;

        int numSlots = System.Enum.GetNames(typeof(WeaponID)).Length;
        currentWeapon = new Weapon[numSlots];
    }

    public void Equip(Weapon newWeapon)
    {
        int slotIndex = (int)newWeapon.weapon;
        Weapon oldWeapon = Unequip(slotIndex, null);

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newWeapon,oldWeapon);
        }

        currentWeapon[slotIndex] = newWeapon;

        if(newWeapon != null && newWeapon.weapon == WeaponID.Axe)
        {
            Unequip((int)WeaponID.Hammer, newWeapon);
            //Unequip((int)WeaponID.Sword)
            
            characterAnimator.animator.SetBool("IsCombat",true);

            axe.SetActive(true);
            hammer.SetActive(false);
            //sword.SetActive(false);
        }
        //Add More weapons And Food Manager
        // if(newWeapon != null && newWeapon.weapon == WeaponID.Sword)
        // {
            // axe.SetActive(false);
            // sword.SetActive(true);
            // hammer.SetActive(false);
        // }
        if(newWeapon != null && newWeapon.weapon == WeaponID.Hammer)
        {
            Unequip((int)WeaponID.Axe, newWeapon);
            // Unequip((int)WeaponID.Sword);
            
            characterAnimator.animator.SetBool("IsCombat",true);

            axe.SetActive(false);
            hammer.SetActive(true);
            //sword.SetActive(false);
        }
    }

    public Weapon Unequip(int slotIndex, Weapon newWeapon)
    {
        if(currentWeapon[slotIndex] != null)
        {
            Weapon oldWeapon = currentWeapon[slotIndex];
            inventory.AddItem(oldWeapon);

            currentWeapon[slotIndex] = null;

            if(onEquipmentChanged != null)
            {
                if (newWeapon != null)
                {
                    onEquipmentChanged.Invoke(newWeapon, oldWeapon);
                }else
                {
                    onEquipmentChanged.Invoke(null, oldWeapon);
                }
            }

            return oldWeapon;
        }

        return null;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }

    private void UnequipAll()
    {
        for (int i = 0; i < currentWeapon.Length; i++)
        {
            Unequip(i,null);
        }

        characterAnimator.animator.SetBool("IsCombat",false);
        axe.SetActive(false);
        sword.SetActive(false);
        hammer.SetActive(false);
    }
}
