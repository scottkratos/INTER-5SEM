using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string level, UnLoad;
    [SerializeField]
    private Animator portao;
    public bool CutsceneDoor, isUnload, DoorClosed;
    Scene s;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        s = SceneManager.GetSceneByName(level);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DoorClosed = false;
    }
    public void Open(bool value)
    {
        portao.SetBool("DoorBool", value);
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            DoorClosed = true;
            portao.SetBool("DoorBool", false);
            Scene s = SceneManager.GetSceneByName(level);
            SceneManager.MoveGameObjectToScene(other.gameObject, s);
            GameObject[] gameObjects = s.GetRootGameObjects();
            if (gameObjects.Any(g => g.gameObject.tag == "Player") == true && isUnload == true)
            {
                Scene unLoadScene = SceneManager.GetSceneByName(UnLoad);
                SceneManager.UnloadSceneAsync(unLoadScene);

            }

        }

    }
}
