using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequesterSpawner : MonoBehaviour
{
    public List<GameObject> RequestableItems;
    public GameObject RequestTemplate;
    public Transform StartingPos;
    public float RequestPeriod;
    public bool AllRequestables;

    private List<GameObject> Requesters;


    // Start is called before the first frame update
    void Start()
    {
        Requesters = new List<GameObject>();
        StartCoroutine( SpawnRequesters());
    }

    private IEnumerator SpawnRequesters()
    {
        foreach(GameObject go in RequestableItems)
        {
            GameObject Requester = Instantiate(RequestTemplate, StartingPos);
            Requester.GetComponent<ItemRequester>().RequestedObject = go.GetComponent<SpriteRenderer>().sprite;
            Requesters.Add(Requester);

            if (!AllRequestables)
            {
                yield return new WaitWhile(() => Requester != null );
            }

            yield return new WaitForSecondsRealtime(RequestPeriod);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Requesters.RemoveAll(item => item== null);

        if(Requesters.Count == 0)
        {
            Debug.Log("Level Complete");

        }
    }
}
