using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorV2 : MonoBehaviour
{
    private Renderer renderer;
    private MaterialPropertyBlock materialPropertyBlock;
    void Awake()
    {
        this.renderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        this.materialPropertyBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorObj();
    }

    public void ChangeColorObj()
    {
        // * Lấy giá trị hiện tại của material property 
        this.renderer.GetPropertyBlock(this.materialPropertyBlock);
        // * tạo ra giá trị mới
        this.materialPropertyBlock.SetColor("_Color",GetRandomColor());
        // * Lấy giá trị và cài vào renderer
        this.renderer.SetPropertyBlock(this.materialPropertyBlock);
        
    }

    private Color GetRandomColor()
    {
        return new Color(r: Random.Range(0f, 1f),
        g: Random.Range(0f, 1f),
        b: Random.Range(0f, 1f));
    }
}
