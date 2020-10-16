using UnityEngine;
using Mirror;

public class Health : NetworkBehaviour
{

    public const int maxHeath = 100;
    [SyncVar(hook = nameof(OnChangeHealth))] public int currentHealth = maxHeath;
    [SyncVar(hook = nameof(OnChangearmor))] float armor;

    public RectTransform healthBar;
    public RectTransform armorBar;

    public bool destroyOnDeath;
    public Player_Abilities player_abilities;
    private NetworkStartPosition[] spawnPoints;

    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
        armor = player_abilities.abilityvalue;
        OnChangearmor(0,armor);
    }

    public void TakeDamage(int amount)
    {

        if (!isServer)
        {
            return;
        }

        if(player_abilities.abilityvalue > 0)
        {
            armor = player_abilities.abilityvalue;
            armor -= amount/2;
            player_abilities.abilityvalue = armor;
        }


        if (armor <= 0)
        {
            currentHealth -= amount;

                if (currentHealth <= 0)
                {

                    if (destroyOnDeath)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        currentHealth = maxHeath;
                        // RpcRespawn();
                    }
                }
             OnChangeHealth(1,currentHealth);
         }
        OnChangearmor(0,armor);
    }

    void OnChangearmor(float oldarmor, float armor)
    {
        armorBar.sizeDelta = new Vector2(armor * 2, healthBar.sizeDelta.y);
    }

    void OnChangeHealth(int oldhealth, int health)
    {
        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }

    /*

    [ClientRpc] 
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {

            Vector3 spawnPoint = Vector3.zero;
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            transform.position = spawnPoint;
        }
    }
    */
}
