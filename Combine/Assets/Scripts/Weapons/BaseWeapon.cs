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
