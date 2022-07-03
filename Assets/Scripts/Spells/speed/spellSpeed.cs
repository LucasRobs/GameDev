using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSpeed : MonoBehaviour, ISpellControler
{
    int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void addSkill(){
        level += 1;
        this.gameObject.SetActive(true);
        return;
    }
}
