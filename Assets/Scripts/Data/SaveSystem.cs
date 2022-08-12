using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UI;
using UnityEngine;

namespace Data
{
    public static class SaveSystem
    {
        static readonly string Path = Application.persistentDataPath + "/level.fun";
        
        public static void SaveLevel(UILevelController level)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Create);


            LevelData data = new LevelData(level);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static LevelData LoadLevel()
        {
            if (File.Exists(Path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(Path, FileMode.Open);

                LevelData data = formatter.Deserialize(stream) as LevelData;
                stream.Close();

                return data;
            }
            Debug.LogError("Save file not found in" + Path);
            return null;
        }
    }
}