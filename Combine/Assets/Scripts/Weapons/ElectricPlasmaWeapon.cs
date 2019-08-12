using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPlasmaWeapon : BaseWeapon
{
    private static Elements[] elementCombination = { Elements.Electric, Elements.Plasma };
    public override IReadOnlyList<Elements> ElementCombination => elementCombination;
}
