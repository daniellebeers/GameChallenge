using System;

namespace GameChallenge
{
    class ProgramUI
    {
        private HeroRepository _heroRepo = new HeroRepository();
        private EnemyRepository _enemyRepo = new EnemyRepository();

        public void Run()
        {
            SetUpGame();
            RunGame();
            EndGame();
        }

        private void SetUpGame()
        {
            CreateHero();
            CreateEnemy();
            ShowHeroDetails();
            ShowEnemyDetails();
        }

        private void CreateHero()
        {
            Console.WriteLine("What is thy name, wanderer?\n");

            string name = Console.ReadLine();

            _heroRepo.CreateCharacter(name);
        }

        private void CreateEnemy()
        {
            Console.WriteLine("What is they name, foe?\n");

            string name = Console.ReadLine();

            _enemyRepo.CreateCharacter(name);
        }

        private void ShowHeroDetails()
        {
            Console.WriteLine("Here are the details for the your Hero:\n");

            var hero = _heroRepo.CharacterDetails();

            Console.WriteLine($"Character Details {hero.Name}" +
                $"health : {hero.Health}" +
                $"Attack: {hero.AttackPower}" +
                $"Stuff: {hero.Name}");

        }

        private void ShowEnemyDetails()
        {
            Console.WriteLine("Here are the details for the your Enemy:\n");

            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Character Details {enemy.Name}" +
                $"health : {enemy.Health}" +
                $"Attack: {enemy.AttackPower}" +
                $"Stuff: {enemy.Name}");
        }

        private void RunGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            while (hero.IsAlive && enemy.IsAlive)
            {
                //Do stuff
                PromptPlayer();

            }

        }

        private void PromptPlayer()
        {
            Console.WriteLine("What would you like to do:" +
                "1. Attack" +
                "2. Flee");
               // "3. Hide");

            var input = int.Parse(Console.ReadLine());

            HandleBattleInput(input);
        }

        private void HandleBattleInput(int input)
        {
            switch (input)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Flee();
                    break;
                case 3:
                    Hide();
                    break;
                default:
                    break;
            }
        }

        private void Attack()
        {
            //get hero variable
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            //get hero attack value 
            _enemyRepo.TakeDamage(hero.AttackPower);

            //get the new health points of your enemy 
            Console.WriteLine($"{enemy.Name}'s health is {enemy.Health}");

            //$ creates dymanic data for interpolation
            //first the hero will strike
            //then, decrement points from enemy
            //print details 
            
        }

        private void Flee()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            //get hero attack value 
            _enemyRepo.TakeDamage(hero.AttackPower);

            //get the new health points of your enemy 
            Console.WriteLine($"{hero.Name} is Alive! {enemy.Name} is getting tired of chasing {hero.Name}! {enemy.Name}'s health is {enemy.Health}");

        }

        private void Hide()
        {
            throw new NotImplementedException();
        }

        private void EndGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();
            Console.WriteLine($"{hero.Name} won! {enemy.Name} is dead!");
        }
    }
}