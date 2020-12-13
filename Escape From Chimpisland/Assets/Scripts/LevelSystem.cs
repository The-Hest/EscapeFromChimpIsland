using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public string[] levels;
    public int bossEncounterLevel;
    public Transform playerPos;

    private int _curretnLevel;

    private void Start()
    {
        _curretnLevel = 0;
    }
    public string GetNextLevel()
    {
        if (_curretnLevel >= 0 && _curretnLevel < bossEncounterLevel)
        {
            _curretnLevel++;
            // Reset Player position
            playerPos.position = Vector3.zero;
            return levels[1];
        }
        else
            return levels[2];
    }
}
