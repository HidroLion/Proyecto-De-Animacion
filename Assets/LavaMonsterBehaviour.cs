using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMonsterBehaviour : EnemyAnimationControl
{
    Transform player;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
