using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPaper : MonoBehaviour
{
    public Transform startingPos;

    private List<GameObject> papers;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPaper());
    }

    private IEnumerator SpawnPaper()
    {
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
