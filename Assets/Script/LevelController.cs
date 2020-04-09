using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string level, UnLoad;
    public Animator portao;
    public bool isOper, isUnload;
    Scene s;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if (isOper == true)
            portao.SetBool("DoorBool", true);
        s = SceneManager.GetSceneByName(level);
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {




    }
    private void OnTriggerEnter(Collider other)
    {
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
