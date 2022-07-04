using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellAmuletOfLife : MonoBehaviour, ISpellControler
{
    int level = 0;
    PlayerControler playerControler;
    
    private void Awake() {
        playerControler = GameObject.FindGameObjectWithTag("Player")
                                    .GetComponent<PlayerControler>();
    }
    
    public void addSkill(){
        level += 1;
        this.gameObject.SetActive(true);
        playerControler.addMaxLife(10);
        print("Life");
        return;
    }
}
