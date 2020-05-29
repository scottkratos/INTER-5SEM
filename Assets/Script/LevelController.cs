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

    private void Awake()
    {
        Vector3 pos;
        pos = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        HubEvents.transforms.SetValue(pos, index);
    }
    // Start is called before the first frame update
    void Start()
    {
        //s = SceneManager.GetSceneByName(level);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DoorClosed = false;
        if (index == -1) return;
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
            SaturationControl.lastIndex = index;
            for (int i = 0; i < HubEvents.Instance.levels[index].LevelLoad.Length; i++)
            {
                SceneManager.LoadSceneAsync(HubEvents.Instance.levels[index].LevelLoad[i], LoadSceneMode.Additive);
            }
            for (int i = 0; i < HubEvents.Instance.levels[index].LevelUnload.Length; i++)
            {
                SceneManager.UnloadSceneAsync(HubEvents.Instance.levels[index].LevelUnload[i]);
            }
        }
    }
}
