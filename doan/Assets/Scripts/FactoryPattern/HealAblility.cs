using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class HealAblility : VFXAbility
{

    //public override EnumVFXAbility Name => EnumVFXAbility.Heal;
    public override void Process()
    {
        //throw new System.NotImplementedException();
        GameObject vfx = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/VFXs/CFX_ElectricityBall.prefab", typeof(GameObject));

        Object.Instantiate(vfx,CharacterController2D.getInstance().transform);
    }

}
