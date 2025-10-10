using unityengine;

public class savedata : Monobehaviour
{
    public struct savedata
    {
        public int highscore;
    }

    void start()
    {

    }
    public class savemanager : monobehaviour
    {
        [serializefield] private savedata data;
        [serializefield] string filename;

        public int gethighscore => data.highscore;
        string getpath()
        {
            return application.persistentdatapath + "/" + filename + ".json"
        }
        private void loaddata()
        {
            if (!filename.exists(getpath()))
            {
                savegamefile();
                return;
            }
        }
        private void savegamefile()
        {
            string jsonfile = jsonutility.tojson(data, true);
            filename.writealltext(getpath(), jsonfile);
        }
        public void sethighscore(int somescore)
        {
            if (data.highscore > somescore) return;

            data.highscore = somescore;
            savegamefile();
        }
    }
}
