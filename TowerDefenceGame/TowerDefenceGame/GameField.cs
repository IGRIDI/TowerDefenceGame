using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TowerDefenceGame.GameCore
{
	public class GameField
	{
		public GameField(int defenceCount, PictureBox gameField)
		{
			gameInterface=gameField;
			monsters=new List<Defence>();
			for (int i=0;i<defenceCount;i++)
				monsters.Add(null);
			enemies=new List<Enemy>();
			shots=new List<Shot>();
		}

		private PictureBox gameInterface;
		private List<Defence> monsters;
		private List<Enemy> enemies;
		private List<Shot> shots;

		public List<Defence> Monsters { get { return monsters; } }

		~GameField()
		{
			for (int i=0;i<monsters.Count;i++)
			{
				// monsters[i].Dispose();
				monsters[i]=null;
			}
			monsters.Clear();
			monsters=null;
			for (int i=0;i<enemies.Count;i++)
			{
				// enemies[i].Dispose();
				enemies[i]=null;
			}
			enemies.Clear();
			enemies=null;
			for (int i=0;i<shots.Count;i++)
			{
				// shots[i].Dispose();
				shots[i]=null;
			}
			shots.Clear();
			shots=null;
			gameInterface=null;
		}
	}
}
