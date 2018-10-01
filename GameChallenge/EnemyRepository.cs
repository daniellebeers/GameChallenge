using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class EnemyRepository : ICharacter
    {
        private Enemy _enemy = new Enemy();


        public void CreateCharacter(string name)
        {
            _enemy = new Enemy
            {
                Name = name,
                AttackPower = 10,
                Health = 100,
                IsAlive = true
            };
        }

        public Character CharacterDetails()
        {
            return _enemy;
        }

        public void TakeDamage(int attackDamage)
        {
            _enemy.Health -= attackDamage;
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            _enemy.Health = 0;
        }
    }
}
