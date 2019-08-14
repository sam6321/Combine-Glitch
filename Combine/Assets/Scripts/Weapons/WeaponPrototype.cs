using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPrototype", menuName = "WeaponPrototype", order = 1)]
public class WeaponPrototype : ScriptableObject
{
    public enum Elements
    {
        Electric,
        Plasma,
        Kinetic
    }

    public class ElementKeyMapEntry
    {
        public string Key;
        public Elements Element;

        public ElementKeyMapEntry(string key, Elements element)
        {
            Key = key;
            Element = element;
        }
    }

    public static ElementKeyMapEntry[] ElementKeyMap = {
        new ElementKeyMapEntry("ElectricKey", Elements.Electric),
        new ElementKeyMapEntry("PlasmaKey", Elements.Plasma),
        new ElementKeyMapEntry("KineticKey", Elements.Kinetic),
    };

    public Elements[] ElementCombination;

    /// <summary>
    /// Particle system to display infront of the ship when this weapon is selected.
    /// </summary>
    public GameObject selectedParticleSystem;

    /// <summary>
    /// Behaviour to instantiate when the weapon is selected.
    /// </summary>
    public GameObject weaponGameObject;
}
