using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
public class EventDispatcher : MonoBehaviour
{
    public Text score;
    public Text coin;

    public UnityEvent ui_EventEnemyDie = new UnityEvent();

    #region Singleton
    // * su dung singleton 
    private static EventDispatcher s_instance;
    public static EventDispatcher GetInstance()
    {
        return s_instance;
    }


    void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;

        }
        else
        {
            Destroy(gameObject);
        }

        this.ui_EventEnemyDie.AddListener(UpdateCoin);
        this.ui_EventEnemyDie.AddListener(UpdateScore);
    }


    void OnDestroy()
    {
        // reset this static var to null if it's the singleton instance
        if (s_instance == this)
        {
            //ClearAllListener();
            s_instance = null;
        }
    }
    #endregion

    public void UpdateScore()
    {
        this.score.text = (Int64.Parse(this.score.text) + 10).ToString();
    }

    public void UpdateCoin()
    {
        this.coin.text = (Int64.Parse(this.coin.text) + 1).ToString();
    }

    /*
    m_MyEvent.Invoke(5);
    void Ping(int i)
    {
        Debug.Log("Ping" + i);
    }
    */

}
