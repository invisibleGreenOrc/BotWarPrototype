﻿using CodeBase.Infrastructure;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemies.Spawners
{
    public class BotSpawner : MonoBehaviour
    {
        private IBotFactory _botFactory;

        [SerializeField]
        private BotType _botType;

        [SerializeField]
        private Material _material;

        private void Awake()
        {
            _botFactory = Game.Instance.BotFactory;
            GetComponent<MeshRenderer>().material = _material;
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            _botFactory.CreateBot(_botType, _material, transform);
            yield return new WaitForSeconds(2);
            _botFactory.CreateBot(_botType, _material, transform);
        }
    }
}
