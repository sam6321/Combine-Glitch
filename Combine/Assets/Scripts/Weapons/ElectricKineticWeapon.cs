using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricKineticWeapon : BaseWeapon
{
    private static Elements[] elementCombination = { Elements.Electric, Elements.Kinetic };
    public override IReadOnlyList<Elements> ElementCombination => elementCombination;
}
