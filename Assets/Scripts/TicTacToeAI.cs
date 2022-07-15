using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TicTacToeState{none, cross, circle}

[System.Serializable]
public class WinnerEvent : UnityEvent<int>
{
}

public class TicTacToeAI : MonoBehaviour
{

	int _aiLevel;

	public TicTacToeState[,] boardState = new TicTacToeState[,] {{TicTacToeState.none, TicTacToeState.none, TicTacToeState.none},
																{TicTacToeState.none, TicTacToeState.none, TicTacToeState.none},
																{TicTacToeState.none, TicTacToeState.none, TicTacToeState.none}};
	//Initialized Board State

	[SerializeField]
	private bool _isPlayerTurn;

	[SerializeField]
	private int _gridSize = 3;
	
	[SerializeField]
	private TicTacToeState playerState = TicTacToeState.cross;
	private TicTacToeState aiState = TicTacToeState.circle;
	//aiState wasn't private? Weird. So now calling AiSelects actually places an O.

	[SerializeField]
	private GameObject _xPrefab;

	[SerializeField]
	private GameObject _oPrefab;

	public UnityEvent onGameStarted;

	//Call This event with the player number to denote the winner
	public WinnerEvent onPlayerWin;

	ClickTrigger[,] _triggers;

	public int[] rows = {0, 0, 0};
	public int[] columns = {0, 0, 0};
	
	private void Awake()
	{
		if(onPlayerWin == null){
			onPlayerWin = new WinnerEvent();
		}
		//Debug.Log(boardState[0,0].ToString());
	}

	public void StartAI(int AILevel){
		_aiLevel = AILevel;

		StartGame();

	}

	public void RegisterTransform(int myCoordX, int myCoordY, ClickTrigger clickTrigger)
	{
		_triggers[myCoordX, myCoordY] = clickTrigger;
	}

	private void StartGame()
	{
		_triggers = new ClickTrigger[3,3];
		//foreach (ClickTrigger testTrigger in _triggers){
		//	Debug.Log(testTrigger.canClick)
		//}
		onGameStarted.Invoke();
	}

	public void PlayerSelects(int coordX, int coordY){

		columns[coordX]++;
		rows[coordY]++;
		_triggers[coordX, coordY].canClick = false;
		SetVisual(coordX, coordY, playerState);
		boardState[coordX, coordY] = playerState;

		//Debug.Log(_triggers.toString());

	}

	public void AiSelects(int coordX, int coordY){


		SetVisual(coordX, coordY, aiState);
		boardState[coordX, coordY] = aiState;
	}

	private void SetVisual(int coordX, int coordY, TicTacToeState targetState)
	{
		Instantiate(
			targetState == TicTacToeState.circle ? _oPrefab : _xPrefab,
			_triggers[coordX, coordY].transform.position,
			Quaternion.identity
		);
	}
}
