using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLR : MonoBehaviour, IGround
{

    Vector3 posCurrent;
    Vector3 posLeft;
    Vector3 posRight;
    public float range;

    public bool goRight = true;

    public float speed = 10f;
    // Start is called before the first frame update
    // tu 56 -> 83
    void Start()
    {
        this.posCurrent = this.transform.position;
        this.posLeft = this.posCurrent;
        this.posRight = this.posCurrent;
        this.posLeft.x -= range;
        this.posRight.x += range;
    }

    // Update is called once per frame
    void Update()
    {
        this.Moving();
    }
    public void Moving(){
        if (this.goRight)
        {

            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, posRight, step);
            if (Vector2.Distance(transform.position, posRight) < 0.001f)
            {
                this.goRight = false;
            }
        }
        else
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, posLeft, step);
            if (Vector2.Distance(transform.position, posLeft) < 0.001f)
            {
                this.goRight = true;
            }
        }
    }

}
