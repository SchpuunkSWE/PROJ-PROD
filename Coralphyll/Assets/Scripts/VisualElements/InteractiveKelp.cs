using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveKelp : MonoBehaviour
{
    // Start is called before the first frame update

    public Material[] materials;
    public Transform player;
    Vector3 playerPosition;

    void Start()
    {
        StartCoroutine("writeToMaterial");
    }

    IEnumerator writeToMaterial()
    {
        while (true)
        {
            playerPosition = player.transform.position;
            for (int i=0; i < materials.Length; i++) {
                materials[i].SetVector("_position", playerPosition);
            }

            yield return null;
        }
    }
}
