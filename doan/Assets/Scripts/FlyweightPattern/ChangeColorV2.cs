using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorV2 : MonoBehaviour
{
    private Renderer renderer;
    private SoldierFactoryColor soldierFactoryColor;
    void Awake()
    {
        this.renderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        this.soldierFactoryColor = SoldierFactoryColor.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorObj();
    }

    public void ChangeColorObj()
    {
        //this.renderer.material.color = GetRandomColor();
        // Debug.Log(this.renderer.material.color.ToString());
        //this.renderer.GetPropertyBlock(materialPropertyBlock);
        this.renderer.material.color = soldierFactoryColor.createSoldierColor(GetRandomColor());
        //Debug.Log(this.soldierFactoryColor.name);
    }

    private Color GetRandomColor()
    {
        return new Color(r: Random.Range(0f, 1f),
        g: Random.Range(0f, 1f),
        b: Random.Range(0f, 1f));
    }
}
