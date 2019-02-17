using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrateLogic : MonoBehaviour
{
    [SerializeField]
    int m_BulletAmmo = 50;

    [SerializeField]
    int m_GrenadeAmmo = 10;

    public GameObject box;

    public float resetTimer;
    public float respawnTimer;
    public bool isActive = true;

    private void Awake()
    {
        respawnTimer = resetTimer;
    }
    private void Update()
    {
        if (isActive == false)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer <= 0)
            {
                isActive = true;
                box.SetActive(true);
                respawnTimer = resetTimer;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        PistolLogic PistolLogic = other.GetComponentInChildren<PistolLogic>();
        if(PistolLogic)
        {
            PistolLogic.AddAmmo(m_BulletAmmo, m_GrenadeAmmo);
            
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
            box.SetActive(false);

        }

        MachineGunLogic MachineLogic = other.GetComponentInChildren<MachineGunLogic>();
        if (MachineLogic)
        {
            MachineLogic.AddAmmo(m_BulletAmmo, m_GrenadeAmmo);

        }
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
            box.SetActive(false);

        }
    }
}
