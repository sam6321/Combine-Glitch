using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon
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

    public abstract IReadOnlyList<Elements> ElementCombination { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
