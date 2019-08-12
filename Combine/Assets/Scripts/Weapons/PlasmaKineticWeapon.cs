using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaKineticWeapon : BaseWeapon
{
    private static Elements[] elementCombination = { Elements.Plasma, Elements.Kinetic };
    public override IReadOnlyList<Elements> ElementCombination => elementCombination;
}
