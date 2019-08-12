using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWeapon : BaseWeapon
{
    private static Elements[] elementCombination = { Elements.Electric };
    public override IReadOnlyList<Elements> ElementCombination => elementCombination;
}
