using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class ObjectPool : MonoBehaviour
    {
        private const int poolCount = 100;

        public static ObjectPool Instance { get; private set; }

        private readonly List<GameObject> objects = new List<GameObject>();

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }

            else
            {
                Destroy(this);
            }

            Clear();
        }

        public void Clear()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Destroy(objects[i]);
            }
            objects.Clear();
        }

        public GameObject Create<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (!objects[i].activeSelf && objects[i].GetComponent<T>() != null)
                {
                    objects[i].transform.position = position;
                    objects[i].transform.rotation = rotation;
                    objects[i].SetActive(true);
                    return objects[i];
                }
            }

            GameObject go = Instantiate(prefab);
            go.transform.position = position;
            go.transform.rotation = rotation;

            if (objects.Count <= poolCount)
            {
                objects.Add(go);
            }

            return go;
        }

        public void Delete(GameObject go)
        {
            if (objects.Contains(go))
            {
                go.SetActive(false);
            }
            else
            {
                Destroy(go);
            }
        }
    }
}