using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public static class LoadGame
{
    public static void SavePlayer(player player)
    {



        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static void Savecutscene(CutscenePrepare cutsceneControl)
    {



        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cutscene.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        CutSceneData data = new CutSceneData(cutsceneControl);
        formatter.Serialize(stream, data);
        stream.Close();



    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }
        else
        {

            //Debug.LogError("Save file not found is" + path);
            return null;
        }



    }
    public static CutSceneData LoadCutscene()
    {
        string path = Application.persistentDataPath + "/cutscene.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CutSceneData data = formatter.Deserialize(stream) as CutSceneData;
            stream.Close();
            return data;

        }
        else
        {

            //Debug.LogError("Save file not found is" + path);
            return null;
        }



    }



}
