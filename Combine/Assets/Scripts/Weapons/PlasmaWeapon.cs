using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaWeapon : BaseWeapon
{
    private static Elements[] elementCombination = { Elements.Plasma };
    public override IReadOnlyList<Elements> ElementCombination => elementCombination;
}
