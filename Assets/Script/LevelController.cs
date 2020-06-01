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
                switch(index)
                {
                    case 0:
                        cut.index = 1;
                        break;
                    case 1:
                        cut.index = 2;
                        break;
                    case 2:
                        cut.index = 3;
                        break;
                    case 3:
                        cut.index = 4;
                        break;
                    case 4:
                        cut.index = 5;
                        break;
                    case 5:
                        cut.index = 6;
                        break;
                    case 6:
                        cut.index = 7;
                        break;
                    case 7:
                        cut.index = 8;
                        break;
                    case 8:
                        cut.index = 9;
                        break;
                    case 9:
                        cut.index = 9;
                        break;
                    case 10:
                        cut.index = 10;
                        break;
                    case 11:
                        cut.index = 11;
                        break;
                    case 12:
                        cut.index = 12;
                        break;
                    case 13:
                        cut.index = 13;
                        break;
                    case 14:
                        cut.index = 14;
                        break;
                    case 15:
                        cut.index = 15;
                        break;
                    case 16:
                        cut.index = 16;
                        break;
                    case 17:
                        cut.index = 17;
                        break;
                    case 18:
                        cut.index = 17;
                        break;
                    case 19:
                        cut.index = 18;
                        break;
                    case 20:
                        cut.index = 19;
                        break;
                    case 21:
                        cut.index = 20;
                        break;
                    case 22:
                        cut.index = 21;
                        break;
                    case 23:
                        cut.index = 22;
                        break;
                    case 24:
                        cut.index = 23;
                        break;
                    case 25:
                        cut.index = 24;
                        break;
                    case 26:
                        cut.index = 25;
                        break;
                    case 27:
                        cut.index = 25;
                        break;
                    case 28:
                        cut.index = 26;
                        break;
                    case 29:
                        cut.index = 27;
                        break;
                    case 30:
                        cut.index = 28;
                        break;
                    case 31:
                        cut.index = 29;
                        break;
                    case 32:
                        cut.index = 30;
                        break;
                    case 33:
                        cut.index = 31;
                        break;
                    case 34:
                        cut.index = 32;
                        break;

                }
                LoadGame.Savecutscene(cut);
            }
            if (DoorClosed) return;
            DoorClosed = true;
            portao.SetBool("DoorBool", false);
            SaturationControl.lastIndex = index;
            List<string> listUnload = new List<string>();
            for (int i = 0; i < HubEvents.Instance.levels[index].LevelUnload.Length; i++)
            {
                listUnload.Add(HubEvents.Instance.levels[index].LevelUnload[i]);
            }
            for (int i = 0; i < listUnload.Count; i++)
            {
                for (int r = 0; r < SceneManager.sceneCount; r++)
                {
                    if (SceneManager.GetSceneAt(r).name == listUnload[i])
                    {
                        SceneManager.UnloadSceneAsync(listUnload[i]);
                        break;
                    }
                }
            }
            for (int i = 0; i < HubEvents.Instance.levels[index].LevelLoad.Length; i++)
            {
                SceneManager.LoadSceneAsync(HubEvents.Instance.levels[index].LevelLoad[i], LoadSceneMode.Additive);
            }
        }
    }
}
