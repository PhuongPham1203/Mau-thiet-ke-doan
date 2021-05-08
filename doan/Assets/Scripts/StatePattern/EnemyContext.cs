using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContext 
{
    private State state;
 
    public void setState(State state) {
        this.state = state;
    }
 
    public void applyState() {
        this.state.handleRequest();
    }
}
