using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class DamageAbility : VFXAbility
{
    //public override EnumVFXAbility Name => EnumVFXAbility.Dame;
    public override void Process()
    {
        GameObject vfx = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/VFXs/CFX_GroundHitandText.prefab", typeof(GameObject));

        Object.Instantiate(vfx,CharacterController2D.getInstance().transform);
    }
}
