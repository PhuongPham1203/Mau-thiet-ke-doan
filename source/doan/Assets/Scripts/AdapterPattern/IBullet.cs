using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{
    void Hit(int dame,Collider2D hitInfo);
}
