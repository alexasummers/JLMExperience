using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCat : MonoBehaviour
{
    public GameObject Player;
    
    void Update()
    {
        transform.LookAt(Player.transform);
    }
}
