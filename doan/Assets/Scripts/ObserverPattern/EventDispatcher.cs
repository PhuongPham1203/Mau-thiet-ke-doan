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
    public Image hp;

    public UnityEvent ui_EventEnemyDie = new UnityEvent();
    public UnityEvent ui_EventPlayerTakeDame = new UnityEvent();
    public UnityEvent ui_EventPlayerUpdateAll = new UnityEvent();



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

        this.ui_EventEnemyDie.AddListener(AddScore);
        this.ui_EventEnemyDie.AddListener(AddCoin);
        this.ui_EventPlayerTakeDame.AddListener(UpdateHP);

        this.ui_EventPlayerUpdateAll.AddListener(UpdateCoin);
        this.ui_EventPlayerUpdateAll.AddListener(UpdateScore);
        this.ui_EventPlayerUpdateAll.AddListener(UpdateHP);
    }


    
    #endregion

    public void AddScore()
    {

        CharacterController2D.getInstance().score+=10;
        this.score.text = CharacterController2D.getInstance().score.ToString();
    }

    public void AddCoin()
    {
        CharacterController2D.getInstance().money+=10;
        this.coin.text = CharacterController2D.getInstance().money.ToString();
    }

    public void UpdateScore()
    {
        //this.score.text = (Int64.Parse(this.score.text) + 10).ToString();
        this.score.text = CharacterController2D.getInstance().score.ToString();
    }

    public void UpdateCoin()
    {
        this.coin.text = CharacterController2D.getInstance().money.ToString();
    }

    public void UpdateHP()
    {
        float max = CharacterController2D.getInstance().hp;
        float currenthp = CharacterController2D.getInstance().currenthp;
        this.hp.fillAmount = currenthp/max; 
    }

    /*
    m_MyEvent.Invoke(5);
    void Ping(int i)
    {
        Debug.Log("Ping" + i);
    }
    */

}
