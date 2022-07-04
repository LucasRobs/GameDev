using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSharpSword : MonoBehaviour, ISpellControler
{
    int level = 0;
    PlayerControler playerControler;
    
    void Awake()
    {
        playerControler = GameObject.FindGameObjectWithTag("Player")
                                    .GetComponent<PlayerControler>();
    }

    public void addSkill(){
        level += 1;
        this.gameObject.SetActive(true);
        playerControler.addDamege(1.1f); //add 10% damage to player
        print("damage");
        return;
    }
}
