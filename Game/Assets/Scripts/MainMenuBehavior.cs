using DataContracts;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    private List<Challenge> _activeChallenges;
    private Dictionary<int,Player> _challengees;

    public void GoToCpuFight()
    {
        var newChallenge = HttpClientHelper.Put<Challenge>("/Challenge", 0);
    }
    public void LoadChallenges()
    {
        _activeChallenges = HttpClientHelper.Get<List<Challenge>>("/Challenge");
    }
    public void LoadPlayers()
    {
        foreach (var challenge in _activeChallenges) 
        {
            if (!_challengees.ContainsKey(challenge.ChallengeeId))
            {
                _challengees.Add(challenge.ChallengeeId, HttpClientHelper.Get<Player>($"/Player/{challenge.ChallengeeId}"));
            }
            if (!_challengees.ContainsKey(challenge.ChallengerId))
            {
                _challengees.Add(challenge.ChallengerId, HttpClientHelper.Get<Player>($"/Player/{challenge.ChallengerId}"));
            }
        }
    }
}
