using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwapController : MonoBehaviour
{
public static List<PlayerSwapController> allPlayers = new List<PlayerSwapController>();

private void OnEnable()
{
    allPlayers.Add(this);
}

private void OnDisable()
{
    allPlayers.Remove(this);
}
public void SwapWithRandomPlayer()
{
if (allPlayers.Count <= 1) return;

PlayerSwapController target;
do
{
    target = allPlayers[Random.Range(0,allPlayers.Count)];
}
while (target == this);

Vector3 myPos = transform.position;
Vector3 theirPos = target.transform.position;

transform.position = theirPos;
target.transform.position = myPos;

   Debug.Log($"{name} swapped with {target.name}!");
}
}
