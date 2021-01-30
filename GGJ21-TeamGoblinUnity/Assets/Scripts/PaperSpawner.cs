using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public Transform startingPos;
    public float SpawnPeriod;
    public GameObject paperTemplate;

    private List<GameObject> papers;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPaper());
    }

    private IEnumerator SpawnPaper()
    {
        while (true)
        {
            Instantiate(paperTemplate, startingPos);
            yield return new WaitForSecondsRealtime(SpawnPeriod);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
