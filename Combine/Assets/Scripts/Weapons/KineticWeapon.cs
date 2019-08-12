using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticWeapon : BaseWeapon
{
    private static Elements[] elementCombination = { Elements.Kinetic };
    public override IReadOnlyList<Elements> ElementCombination => elementCombination;
}
