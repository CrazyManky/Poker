using UnityEngine;

namespace _Project.Configs
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        public bool SoundActive { get; private set; }
        public  bool MusicActive { get; private set; }
        
        public void SetSound(bool value)
        {
            SoundActive = value;
            PlayerPrefs.SetInt("Sound", value ? 1 : 0);
        }
        
        public void SetMusic(bool value)
        {
            MusicActive = value;
            PlayerPrefs.SetInt("Sound", value ? 1 : 0);
        }

        public void GetSaveValue() => SoundActive = PlayerPrefs.GetInt("Sound", 0) == 1;
        
    }
}