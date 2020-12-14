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

    public string GetCurrentLevel()
    {
        if (_curretnLevel == 0)
            return levels[0];
        else if (_curretnLevel == bossEncounterLevel)
            return levels[2];

        return levels[1];
    }
    public string GetNextLevel()
    {
        // Reset Player position
        playerPos.position = Vector3.zero;
        if (_curretnLevel != bossEncounterLevel)
        {
            _curretnLevel++;
            return levels[1];
        }
        else
        {
            return levels[2];
        }
    }
}
