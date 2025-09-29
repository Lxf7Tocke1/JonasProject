//using UnityEngine;
//
//public class SaveData : MonoBehaviour
//{
//    public struct SaveData
//    {
//        public int Highscore;
//    }
//
//    void Start()
//    {
//        
//    }
//    public class SaveManager : MonoBehaviour
//    {
//        [SerializeField] private SaveData data;
//        [SerializeField] string fileName;
//        
//        public int GetHighscore => data.Highscore;
//        string GetPath()
//        {
//            return Application.persistentDataPath + "/" + fileName + ".json"
//        }
//            private void LoadData()
//        {
//            if (!fileName.Exists(GetPath()))
//            {
//                SaveGameFile();
//                return;
//            }
//        }
//        private void SaveGameFile()
//        {
//            string jsonfile = JsonUtility.ToJson(data, true);
//            fileName.WriteAllText(GetPath(), jsonfile);
//        }
//        public void SetHighscore(int someScore)
//        {
//            if (data.Highscore > someScore) return;
//
//            data.Highscore = someScore;
//            SaveGameFile();
//        }
//    }
//}
//