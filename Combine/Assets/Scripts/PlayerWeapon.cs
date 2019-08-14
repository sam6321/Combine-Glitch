using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private WeaponPrototype[] weapons;

    [SerializeField]
    private float selectCycleTime = 1.5f;

    [SerializeField]
    private Vector3 particleSystemOffset = Vector3.zero;

    [SerializeField]
    private Text tempText;

    private ParticleSystem selectedParticleSystem = null;
    private GameObject selectedWeaponObject = null;
    private WeaponPrototype selectedWeapon = null;
    private WeaponPrototype.Elements?[] currentElements = new WeaponPrototype.Elements?[2];
    private int elementIndex = 0;
    private float lastSet = 0;

    void Update()
    {
        foreach(var key in WeaponPrototype.ElementKeyMap)
        {
            if(Input.GetButtonDown(key.Key))
            {
                if(lastSet + selectCycleTime < Time.time || elementIndex == 2)
                {
                    currentElements[0] = null;
                    currentElements[1] = null;
                    elementIndex = 0;
                }

                if(elementIndex == 1 && currentElements[0] == key.Element)
                {
                    // pressed the same thing twice, so ignore the key press
                    continue;
                }

                currentElements[elementIndex++] = key.Element;
                lastSet = Time.time;

                SelectWeapon();
            }
        }
    }

    private void SelectWeapon()
    {
        WeaponPrototype.Elements[] elements = currentElements
            .Where(e => e.HasValue)
            .Select(e => e.Value).ToArray();

        foreach (WeaponPrototype weapon in weapons)
        {
            if(ContainerExtensions.ScrambledEquals(elements, weapon.ElementCombination)) {
                // Cleanup old selected weapon
                ChangeWeapon(weapon);
                break;
            }
        }
    }

    private void ChangeWeapon(WeaponPrototype weapon)
    {
        if(selectedWeapon != null)
        {
            // remove and cleanup 
            ParticleSystem.MainModule main = selectedParticleSystem.main;
            main.stopAction = ParticleSystemStopAction.Destroy;
            main.loop = false;
            selectedParticleSystem = null;

            if (selectedWeaponObject)
            {
                Destroy(selectedWeaponObject);
                selectedWeaponObject = null;
            }
        }

        selectedWeapon = weapon;

        if(selectedWeapon != null)
        {
            GameObject ps = Instantiate(selectedWeapon.selectedParticleSystem, transform);
            ps.transform.localPosition = particleSystemOffset;
            selectedParticleSystem = ps.GetComponent<ParticleSystem>();

            if (selectedWeapon.weaponGameObject)
            {
                selectedWeaponObject = Instantiate(selectedWeapon.weaponGameObject, transform);
            }

            tempText.text = selectedWeapon.ElementCombination.Aggregate("", (e, a) => a + " " + e.ToString());
        }
    }
}
