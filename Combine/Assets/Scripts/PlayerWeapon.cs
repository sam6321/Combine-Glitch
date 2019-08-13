
using System.Linq;
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

    [SerializeField]
    private float selectCycleTime = 1.5f;

    private BaseWeapon selectedWeapon = null;
    private BaseWeapon.Elements?[] currentElements = new BaseWeapon.Elements?[2];
    private int elementIndex = 0;
    private float lastSet = 0;

    void Start()
    {
        
    }

    void Update()
    {
        foreach(var key in BaseWeapon.ElementKeyMap)
        {
            if(Input.GetButtonDown(key.Key))
            {
                if(lastSet < selectCycleTime + Time.time || elementIndex == 2)
                {
                    currentElements[0] = null;
                    currentElements[1] = null;
                    elementIndex = 0;
                }

                currentElements[elementIndex++] = key.Element;
                lastSet = Time.time;

            }
        }
    }

    private void SelectWeapon()
    {
        BaseWeapon.Elements[] elements = currentElements
            .Where(e => e.HasValue)
            .Select(e => e.Value).ToArray();

        foreach (BaseWeapon weapon in weapons)
        {
            if(ContainerExtensions.ScrambledEquals(elements, weapon.ElementCombination)) {
                selectedWeapon = weapon;
                break;
            }
        }

        selectedWeapon = null;
    }
}
