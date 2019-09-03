using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerZone : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
