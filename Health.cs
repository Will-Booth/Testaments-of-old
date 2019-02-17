using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // The total health of this unit
    [SerializeField]
    public int m_Health = 100;

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void DoDamage(int damage)
    {
        m_Health -= damage;

        if(m_Health < 0)
        {
            if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("MainScene");
            }
            Destroy(gameObject);
        }
    }

    public bool IsAlive()
    {
        return m_Health > 0;
    }
}
