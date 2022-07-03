using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellAmuletOfLife : MonoBehaviour, ISpellControler
{
    int level = 0;

    public void addSkill(){
        level += 1;
        this.gameObject.SetActive(true);
        return;
    }
}
