using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXFactory : MonoBehaviour
{
    private static VFXFactory instance;
    public static VFXFactory getInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public VFXAbility getVFX(EnumVFXAbility vfxType)
    {
        switch (vfxType)
        {
            case EnumVFXAbility.Heal:
                return new HealAblility();

            case EnumVFXAbility.Dame:
                return new HealAblility();

            default:
                Debug.Log("Not have VFX");
                return null;
        }
    }

}
