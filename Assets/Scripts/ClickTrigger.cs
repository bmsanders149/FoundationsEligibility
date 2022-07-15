using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
	TicTacToeAI _ai;

	[SerializeField]
	private int _myCoordX = 0;
	[SerializeField]
	private int _myCoordY = 0;

//	public int[] rows = {0, 0, 0};
//	public int[] columns = {0, 0, 0};

	[SerializeField]
	public  bool canClick;

	private void Awake()
	{
		_ai = FindObjectOfType<TicTacToeAI>();
	}

	private void Start(){

		_ai.onGameStarted.AddListener(AddReference);
		_ai.onGameStarted.AddListener(() => SetInputEndabled(true));
		_ai.onPlayerWin.AddListener((win) => SetInputEndabled(false));
	}

	private void SetInputEndabled(bool val){
		canClick = val;
	}

	private void AddReference()
	{
		_ai.RegisterTransform(_myCoordX, _myCoordY, this);
		canClick = true;
	}

	private void OnMouseDown()
	{
		if(canClick){
			_ai.PlayerSelects(_myCoordX, _myCoordY);
			//canClick = false;

			if (_myCoordX  == 0 && _myCoordY == 2 && _ai.boardState[2,0] == TicTacToeState.none){
				_ai.AiSelects(2,0);
					return;
			}

			if (_myCoordX  == 0 && _myCoordY == 0 && _ai.boardState[2,2] == TicTacToeState.none){
				_ai.AiSelects(2,2);
					return;
			}

			if (_myCoordX  == 2 && _myCoordY == 0 && _ai.boardState[0,2] == TicTacToeState.none){
				_ai.AiSelects(0,2);
					return;
			}

			if (_myCoordX  == 2 && _myCoordY == 2 && _ai.boardState[0,0] == TicTacToeState.none){
				_ai.AiSelects(0,0);
					return;
			}





			int testy = _ai.columns[_myCoordX];
			if(testy == 2){
					for (int i = 0; i<3; i++){
					if(_ai.boardState[_myCoordX,i] == TicTacToeState.none){
					_ai.AiSelects(_myCoordX, i);
					return;
					}
				}
			}
			testy = _ai.rows[_myCoordY];
			if(testy == 2){
					for (int i = 0; i<3; i++){
					if(_ai.boardState[i,_myCoordY] == TicTacToeState.none){
					_ai.AiSelects(i,_myCoordY);
					return;
					}
				}
			}
			for (int i = 0; i<3; i++){
				for (int g = 0; g<3; g++){
					if (_ai.boardState[i,g] == TicTacToeState.none){
						_ai.AiSelects(i,g);
						return;
					}
				}
			}
			/*if(_myCoordX+1<3 && _myCoordY+1 < 3 && _ai.boardState[_myCoordX+1,_myCoordY+1] == TicTacToeState.none){
			_ai.AiSelects(_myCoordX+1, _myCoordY+1); return;}
			
			if(_myCoordX == 2 && _myCoordY == 0 && _ai.boardState[0,2] == TicTacToeState.none){
			_ai.AiSelects(0, 2); return;}
			if(_ai.boardState[_myCoordX-1, _myCoordY-1] == TicTacToeState.none){
			_ai.AiSelects(_myCoordX-1, _myCoordY-1); return;}*/
		







			//if(_ai.boardState[_myCoordX+1, _myCoordY] == TicTacToeState.cross)
				





				/*{
					if (_myCoordX+2 == 3)
					{_ai.AiSelects(0, _myCoordY);} 
					else 
					{_ai.AiSelects(_myCoordX+2, _myCoordY);} 
					return;}
			/*else if(_ai.boardState[_myCoordX-1, _myCoordY] == TicTacToeState.cross)
				{_ai.AiSelects(_myCoordX-2, _myCoordY); return;}
			else if(_ai.boardState[_myCoordX, _myCoordY+1] == TicTacToeState.cross) 
				{_ai.AiSelects(_myCoordX, _myCoordY+2); return;}
			_ai.AiSelects(_myCoordX+1, _myCoordY+1);*/


			
		}
	}
}
