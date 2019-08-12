
using UnityEngine;
using Common;

public class PlayerWeapon : MonoBehaviour
{
    private BaseWeapon[] weapons =
    {
        new ElectricWeapon(),
        new PlasmaWeapon(),
        new KineticWeapon(),
        new ElectricKineticWeapon(),
        new ElectricPlasmaWeapon(),
        new PlasmaKineticWeapon()
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private BaseWeapon SelectWeapon(BaseWeapon.Elements[] elements)
    {
        foreach(BaseWeapon weapon in weapons)
        {
            if(ContainerExtensions.ScrambledEquals(elements, weapon.ElementCombination)) {
                return weapon;
            }
        }

        return null; // Shouldn't get here
    }
}
