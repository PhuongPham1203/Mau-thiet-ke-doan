using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : ISoldier
{
    private Color aColor ;
    private string name;
    public Soldier(string n){
        this.name = n;
    }

    public void setColor( Color c){
        this.aColor = c;
    }
    public override Color getColor(){

        return this.aColor;
    }
    
}
