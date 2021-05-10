using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeapon : MonoBehaviour
{
    public GameObject bulletHeavy;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 8){
            PlayerMovement pm = CharacterController2D.getInstance().GetComponent<PlayerMovement>();

            foreach(WeaponStrategy we in pm.allWeapon){
                if(we is HeavyWeapon){
                    return;
                }
            }
            HeavyWeapon w = pm.gameObject.AddComponent(typeof(HeavyWeapon)) as HeavyWeapon;

            w.firePoint = pm.transform.GetChild(2).transform;
            w.bulletPrefab = this.bulletHeavy;
            pm.allWeapon.Add(w);
            pm.allWeapon[pm.allWeapon.Count-1].enabled = false;
            Destroy(gameObject);
        }
    }
}
