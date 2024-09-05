﻿#nullable enable

using UnityEngine;

namespace InGame
{
    public class Game : MonoBehaviour
    {
        private GameSettings _gameSettings = null!;
        [SerializeField] private Turn _turn = null!;

        // Start is called before the first frame update
        private void Start()
        {
            _gameSettings = new();

            _turn.Initialize(_gameSettings.Player, _gameSettings.OpponentPlayer, _gameSettings.MaxTurn);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}