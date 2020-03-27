using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemanager : MonoBehaviour
{

    public GameObject[] tileprefabs;
    public Transform playertransfrom;

    private float spawnz = 0.0f;
    private float tilelength = 20.0f;
    private int amountoftile = 5;

    private float safezone = 15.0f;

    //for random tiles
    private int lastprefabsindex = 0;


    //list for take the index of spawn tiles
    private List<GameObject> activetiles;

    // Start is called before the first frame update
    void Start()
    {
        activetiles = new List<GameObject>();

        for (int i = 0; i < amountoftile; i++)
        {


            spawntile();
        
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (playertransfrom.position.z-safezone > (spawnz- amountoftile *tilelength) )
        {
            spawntile();
            deletetile();
        }

    }


    void spawntile(int prefebindex=-1)
    {

        GameObject go;
        go = Instantiate(tileprefabs[Randomprefabtile()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnz;
        spawnz += tilelength;

        //adding tiles to the activetiles list

        activetiles.Add(go);
    
    }

    void deletetile()
    {
        //deleting tiles from activelist tile list from zero index
        Destroy(activetiles[0]);

        //after deleting we are removeing tile from the list
        activetiles.RemoveAt(0);

    
    
    }


    private int Randomprefabtile() 
    
    {

        if (tileprefabs.Length<=1)
        {

            return 0;

        }
        int randomindex = lastprefabsindex;
        while (randomindex==lastprefabsindex)
        {

            randomindex = Random.Range(0,tileprefabs.Length);

        }

        lastprefabsindex = randomindex;
        return randomindex;


    }

}
