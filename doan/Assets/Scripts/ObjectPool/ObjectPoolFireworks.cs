using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolFireworks : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPoolFireworks Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDic;
    // Start is called before the first frame update
    void Start()
    {
        this.poolDic = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool p in this.pools)
        {

            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject obj = Instantiate(p.prefab);

                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            this.poolDic.Add(p.tag, objectPool);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }


    public GameObject SpawnFromPool(string tag, Vector3 posion)
    {
        if (!this.poolDic.ContainsKey(tag))
        {
            Debug.Log("Khong co tag nay");
            return null;
        }


        GameObject objToSpawn = this.poolDic[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = posion;


        IPoolObj pO = objToSpawn.GetComponent<IPoolObj>();
        if (pO != null)
        {
            pO.OnObjSpawn();
        }


        this.poolDic[tag].Enqueue(objToSpawn);

        return objToSpawn;


    }



    public IEnumerator WaitAndPool(float waitTime, Vector3 position)
    {
        for (int i = 0; i < 150; i++)
        {
            yield return new WaitForSeconds(waitTime);
            this.SpawnFromPool("firework", position);

        }

        //yield return new WaitForSeconds(3f);
        
    }

}
