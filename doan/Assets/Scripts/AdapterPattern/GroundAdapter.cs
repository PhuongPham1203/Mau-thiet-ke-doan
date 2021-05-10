using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GroundAdapter
{
    public Grid grid;
    public Tilemap tilemap;
    public GroundStatic ground;

    public GroundAdapter(GroundStatic groundStatic)
    {
        this.ground = groundStatic;

        this.grid = this.ground.GetComponentInParent<Grid>();
        this.tilemap = this.ground.GetComponent<Tilemap>();
    }

    public void TakeDamage(BulletHeavy bullet)
    {

        Debug.Log("Detroy ground postion bullet hit");

        Vector3 posBulletHit = bullet.transform.position;
        Vector3Int position = grid.WorldToCell(posBulletHit);
        //tilemap.SetTile(position, null);
        
        for (int x = position.x - 1; x <= position.x + 1; x++)
        {
            for (int y = position.y - 1; y <= position.y + 1; y++)
            {
                tilemap.SetTile(new Vector3Int(x,y,position.z ), null);
            }
        }
    }
}
