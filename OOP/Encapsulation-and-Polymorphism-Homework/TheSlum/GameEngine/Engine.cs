using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class Engine
    {
        private const int GameTurns = 4;

        protected List<Character> characterList = new List<Character>();
        protected List<Bonus> timeoutItems;

        public virtual void Run()
        {
            ReadUserInput();
            InitializeTimeoutItems();
            for (int i = 0; i < GameTurns; i++)
            {
                foreach (var character in characterList)
                {
                    if (character.IsAlive)
                    {
                        ProcessTargetSearch(character);
                    }
                }
                ProcessItemTimeout(timeoutItems);
            }

            PrintGameOutcome();
        }

        private void ReadUserInput()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != "")
            {
                string[] parameters = inputLine.Split(
                    new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                ExecuteCommand(parameters);
                inputLine = Console.ReadLine();
            }
        }

        public void ProcessItemTimeout(List<Bonus> timeoutItems)
        {
            for (int i = 0; i < timeoutItems.Count; i++)
            {
                timeoutItems[i].Countdown--;
                if (timeoutItems[i].Countdown == 0)
                {
                    var item = timeoutItems[i];
                    item.HasTimedOut = true;
                    var itemHolder = GetCharacterByItem(item);
                    itemHolder.RemoveFromInventory(item);
                    i--;
                }
            }
        }

        public void InitializeTimeoutItems()
        {
            timeoutItems = characterList
                .SelectMany(c => c.Inventory)
                .Where(i => i is Bonus)
                .Cast<Bonus>()
                .ToList();
        }

        protected void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    ExecuteCommand(inputParams);
                    break;
            }
        }
        
        protected void CreateCharacter(string[] inputParams)
        {
            Character character;
            Team team;
            switch (inputParams[5].ToLower())
            {
                case "red":
                    team = Team.Red;
                    break;
                case "blue":
                    team = Team.Blue;
                    break;
                default:
                    throw new ApplicationException("Wrong color team.");
            }

            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    character = new Warrior(
                    id: inputParams[2],
                    x: int.Parse(inputParams[3]),
                    y: int.Parse(inputParams[4]),
                    healthPoints: 100,
                    defensePoints: 30,
                    team: team,
                    range: 10,
                    attackPoints: 60);
                    break;
                case "healer":
                    character = new Healer(
                    id: inputParams[2],
                    x: int.Parse(inputParams[3]),
                    y: int.Parse(inputParams[4]),
                    healthPoints: 100,
                    defensePoints: 0,
                    team: team,
                    range: 10,
                    healingPoints: 30);
                    break;
                case "mage":
                    character = new Mage(
                    id: inputParams[2],
                    x: int.Parse(inputParams[3]),
                    y: int.Parse(inputParams[4]),
                    healthPoints: 100,
                    defensePoints: 5,
                    team: team,
                    range: 10,
                    attackPoints: 30);
                    break;
                default:
                    throw new ApplicationException("No such kind of hero.");
            }

            this.characterList.Add(character);
        }

        protected void AddItem(string[] inputParams)
        {
            Item item;
            switch (inputParams[2].ToLower())
            {
                case "axe":
                    item = new Axe(inputParams[3]);
                    break;
                case "shield":
                    item = new Shield(inputParams[3]);
                    break;
                case "injection":
                    item = new Injection(inputParams[3]);
                    break;
                case "pill":
                    item = new Pill(inputParams[3]);
                    break;
                default:
                    throw new ApplicationException("No such kind of item.");
            }

            var character = this.characterList.First(c => c.Id == inputParams[1]);
            character.AddToInventory(item);
        }

        protected void ProcessTargetSearch(Character currentCharacter)
        {
            var availableTargets = characterList
                .Where(t => IsWithinRange(currentCharacter.X, currentCharacter.Y, t.X, t.Y, currentCharacter.Range)).ToList();
            if (availableTargets.Count == 0)
            {
                return;
            }

            var target = currentCharacter.GetTarget(availableTargets);
            if (target == null)
            {
                return;
            }

            ProcessInteraction(currentCharacter, target);
        }

        protected void ProcessInteraction(Character currentCharacter, Character target)
        {
            if (currentCharacter is IHeal)
            {
                target.HealthPoints += (currentCharacter as IHeal).HealingPoints;
            }
            else if (currentCharacter is IAttack)
            {
                target.HealthPoints -= (currentCharacter as IAttack).AttackPoints - target.DefensePoints;
                if (target.HealthPoints <= 0)
                {
                    target.IsAlive = false;
                }
            }
        }

        protected bool IsWithinRange(int attackerX, int attackerY, 
            int targetX, int targetY, int range)
        {
            double distance = Math.Sqrt(
                (attackerX - targetX) * (attackerX - targetX) + 
                (attackerY - targetY) * (attackerY - targetY)
                );
            return distance <= (double)range;
        }

        protected Character GetCharacterById(string characterId)
        {
            return characterList.FirstOrDefault(x => x.Id == characterId);
        }

        protected Character GetCharacterByItem(Item item)
        {
            return characterList.FirstOrDefault(x => x.Inventory.Contains(item));
        }

        protected void PrintCharactersStatus(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                Console.WriteLine(character.ToString());
            }
        }

        protected void PrintGameOutcome()
        {
            var charactersAlive = characterList.Where(c => c.IsAlive);
            var redTeamCount = charactersAlive.Count(x => x.Team == Team.Red);
            var blueTeamCount = charactersAlive.Count(x => x.Team == Team.Blue);
            if (redTeamCount == blueTeamCount)
            {
                Console.WriteLine("Tie game!");
            }
            else
            {
                string winningTeam = redTeamCount > blueTeamCount ? "Red" : "Blue";
                Console.WriteLine(winningTeam + " team wins the game!");
            }

            var aliveCharacters = characterList.Where(c => c.IsAlive);
            PrintCharactersStatus(aliveCharacters);
        }
    }
}
