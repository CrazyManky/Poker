using _Project.Scripts;
using _Project.Scripts.Screens;
using UnityEngine;
using Random = System.Random;

public class LeaderboardScreen : BaseScreen
{
    [SerializeField] private LeaderboardItem _itemPrefab;
    [SerializeField] private RectTransform _spawnPoint;
    [SerializeField] private Sprite[] _medals;

    private Sprite _medal;

    private string[] _userNames =
    {
        "Liam",
        "Noah",
        "Oliver",
        "James",
        "Elijah",
        "Mateo",
        "Theodore",
        "Lucas",
        "William"
    };

    public override void Init()
    {
        base.Init();
        for (int i = 0; i < 8; i++)
        {
            var instanceItem = Instantiate(_itemPrefab, _spawnPoint);
            var randomName = new Random().Next(0, _userNames.Length);
            var randomValueScore = new Random().Next(0, 15000);
            var randomValue = new Random().Next(0, 15000);
            if (i < _medals.Length)
                _medal = _medals[i];
            else
                _medal = null;
            instanceItem.SetData(_userNames[randomName], randomValueScore, randomValue, _medal);
        }
    }

    public void BackToMenu()
    {
        AudioManager.PlayButtonClick();
        Dialog.ShowMenuScreen();
    }
}