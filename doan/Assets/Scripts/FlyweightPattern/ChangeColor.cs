using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorObj();
    }

    public void ChangeColorObj(){
        this.renderer.material.color = GetRandomColor();
        // Debug.Log(this.renderer.material.color.ToString());
        //this.renderer.GetPropertyBlock(materialPropertyBlock);

    }

    private Color GetRandomColor()
    {
        return new Color(r: Random.Range(0f, 1f), 
        g: Random.Range(0f, 1f), 
        b: Random.Range(0f, 1f));
    }
}
