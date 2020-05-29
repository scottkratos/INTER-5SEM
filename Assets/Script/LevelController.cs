using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int index;
    [SerializeField]
    private Animator portao;
    public bool CutsceneDoor, isUnload, DoorClosed, cutSceneLoad;
    Scene s;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //s = SceneManager.GetSceneByName(level);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DoorClosed = false;
        if (index == -1) return;
        Vector3 pos;
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        HubEvents.Instance.CreteTransform(pos, rot, index);
    }
    public void Open(bool value)
    {
        portao.SetBool("DoorBool", value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (portao.GetBool("DoorBool"))
            {
                LoadGame.SavePlayer(other.gameObject.GetComponent<player>());
                CutscenePrepare cut;
                cut = new CutscenePrepare();
                cut.index = index;
                LoadGame.Savecutscene(cut);
            }
            if (DoorClosed) return;
            DoorClosed = true;
            portao.SetBool("DoorBool", false);
            SaturationControl.lastIndex = index;
            for (int i = 0; i < HubEvents.Instance.levels[index].LevelLoad.Length; i++)
            {
                bool haveLoaded = false;
                for (int r = 0; r < SceneManager.sceneCount; r++)
                {
                    if (SceneManager.GetSceneAt(r).name == HubEvents.Instance.levels[index].LevelLoad[i])
                    {
                        haveLoaded = true;
                    }
                }
                if (!haveLoaded) SceneManager.LoadSceneAsync(HubEvents.Instance.levels[index].LevelLoad[i], LoadSceneMode.Additive);
            }
            for (int i = 0; i < HubEvents.Instance.levels[index].LevelUnload.Length; i++)
            {
                for (int r = 0; r < SceneManager.sceneCount; r++)
                {
                    if (SceneManager.GetSceneAt(r).name == HubEvents.Instance.levels[index].LevelUnload[i])
                    {
                        SceneManager.UnloadSceneAsync(HubEvents.Instance.levels[index].LevelUnload[i]);
                    }
                }
            }
        }
    }
}
