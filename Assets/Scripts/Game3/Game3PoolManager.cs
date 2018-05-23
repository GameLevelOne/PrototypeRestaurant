using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3PoolManager : MonoBehaviour {

	Dictionary<int, Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>>();

	static Game3PoolManager instance;

	#region Game3PoolManager Sigleton
//	public static Game3PoolManager Instance {
//		get { 
//			if (instance == null) {
//				instance = FindObjectOfType<Game3PoolManager> ();
//			}
//			return instance;
//		}
//	}
	#endregion //Game3PoolManager Sigleton

	public void CreatePool (GameObject prefab, int poolSize) {
		int poolKey = prefab.GetInstanceID ();

		if (!poolDictionary.ContainsKey (poolKey)) {
			poolDictionary.Add (poolKey, new Queue<ObjectInstance> ());

			GameObject poolHolder = new GameObject (prefab.name);
			poolHolder.transform.parent = transform;

			for (int i = 0; i < poolSize; i++) {
				ObjectInstance newObject = new ObjectInstance (Instantiate (prefab) as GameObject);
				poolDictionary [poolKey].Enqueue (newObject);
				newObject.SetParent (poolHolder.transform);
			}
		}
	}

	public void ReuseObject (GameObject prefab, Vector3 position, Quaternion rotation) {
		int poolKey = prefab.GetInstanceID ();

		if (poolDictionary.ContainsKey (poolKey)) {
			ObjectInstance objectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (objectToReuse);

			objectToReuse.Reuse (position, rotation);
		}
	}

	public class ObjectInstance {
		GameObject gameobject;
		Transform transform;

		bool hasGame3PoolObjectComponent;
		Game3PoolObject Game3PoolObjectScript;

		public ObjectInstance (GameObject objectInstance) {
			gameobject = objectInstance;
			transform = gameobject.transform;
			gameobject.SetActive(false);

			if (gameobject.GetComponent<Game3PoolObject>()) {
				hasGame3PoolObjectComponent = true;
				Game3PoolObjectScript = gameobject.GetComponent<Game3PoolObject>();
			}
		}

		public void Reuse (Vector3 position, Quaternion rotation) {
			gameobject.SetActive (true);
			transform.position = position;
			transform.rotation = rotation;

			if (hasGame3PoolObjectComponent) {
				Game3PoolObjectScript.OnObjectReuse ();
			}
		}

		public void SetParent (Transform parent) {
			transform.parent = parent;
		}
	}
}
