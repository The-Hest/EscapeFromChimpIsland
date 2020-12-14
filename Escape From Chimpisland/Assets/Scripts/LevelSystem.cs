using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public string[] levels;
    public int bossEncounterLevel;
    public Transform playerPos;

    private int _curretnLevel;
    private bool _bossReached;

    private void Start()
    {
        _curretnLevel = 0;
        _bossReached = false;
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

        // If current level is boss go back to dungeon
        if (_bossReached)
        {
            _bossReached = false;
            _curretnLevel = 1;
            return levels[1];
        }

        // If current level is sample go back to next dungeon level
        else if (_curretnLevel < bossEncounterLevel)
        {
            _curretnLevel++;
            return levels[1];
        }

        // Reached boss
        _bossReached = true;
        return levels[2];
    }
}
