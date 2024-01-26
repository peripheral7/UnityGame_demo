using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace User_State
{    
    public class PlayerPositionSaver : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var path = Path.Combine(Application.persistentDataPath, "save.json");

            var positionString = File.ReadAllText(path);

            transform.position = JsonUtility.FromJson<Vector3>(positionString);
        }

        // Update is called once per frame
        private void OnApplicationQuit()
        {
            // PlayerPrefs.SetString("player_position", JsonUtility.ToJson(transform.position));
            // PlayerPrefs.SetString("player_rotation", JsonUtility.ToJson(transform.rotation));

            var path = Path.Combine(Application.persistentDataPath, "save.json");
            File.WriteAllText(path, JsonUtility.ToJson(transform.position));
        }
    }
}
