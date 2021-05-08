using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactoryColor : MonoBehaviour
{
    private static Hashtable listColor = new Hashtable ();
    private static SoldierFactoryColor instance ;
    public static SoldierFactoryColor getInstance() {
        return instance;
    }

    //private MaterialPropertyBlock materialPropertyBlock;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        
    }

    public Color createSoldierColor(Color c){
        
        if(listColor.ContainsKey(c.ToString())){
            return (Color)(listColor[c.ToString()]) ;
        }else{
            listColor.Add(c.ToString(),c);
        }
        return c;
    }
}
