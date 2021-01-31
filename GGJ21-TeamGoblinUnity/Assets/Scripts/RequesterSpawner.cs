using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RequesterSpawner : MonoBehaviour
{
    public List<Sprite> NPCsprites;
    public List<GameObject> RequestableItems;
    public GameObject RequestTemplate;
    public Transform StartingPos;
    public float RequestPeriod;
    public bool AllRequestables;
    public string NextSceneName;
    
    private Scene NextScene;
    private List<GameObject> Requesters;

    AudioSource audioDing;


    // Start is called before the first frame update
    void Start()
    {
        Requesters = new List<GameObject>();
        audioDing = GetComponent<AudioSource>();
        StartCoroutine( SpawnRequesters());
        
    }

    private IEnumerator SpawnRequesters()
    {
        // Go through the whole list of items
        for (int i = RequestableItems.Count; i > 0; i--)
        {
            // Spawns an NPC
            GameObject Requester = Instantiate(RequestTemplate, this.transform);
            Requester.transform.position = StartingPos.position;
            audioDing.Play();
            // Give it a random NPC sprite
            Requester.GetComponent<SpriteRenderer>().sprite = NPCsprites[Random.Range(0, NPCsprites.Count)];
            // Select a random item from the item list
            GameObject RequestObject = RequestableItems[Random.Range(0, RequestableItems.Count)];
            // Give that item to the NPC to request
            Requester.GetComponent<ItemRequester>().RequestedObject = RequestObject.GetComponent<SpriteRenderer>().sprite;
            // Remove the item from the list of items
            RequestableItems.Remove(RequestObject);
            // Add the NPC to the list of currently active NPCs
            Requesters.Add(Requester);
            
            // If we want to wait for the current NPC to be done
            if (!AllRequestables)
            {
                // Wait while the Requester still exists
                yield return new WaitWhile(() => Requester != null );
            }
            else
            {
                // If we may have multiple NPCs at the same time move them so they don't overlap
                Vector3 vector3 = StartingPos.position;
                vector3.x -= 2;
                StartingPos.position = vector3;
            }
            
            // Wait x amounts of seconds for next NPC to spawn.
            yield return new WaitForSecondsRealtime(RequestPeriod);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Remove all NPCs that have been destroyed
        Requesters.RemoveAll(item => item== null);

        // Check if all NPCs are gone and all Items have NPCs
        if(Requesters.Count == 0 && RequestableItems.Count == 0)
        {

            Debug.Log("Level Complete");

            SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);

        }
    }
}
