using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace class_ex_rpg
{
    public class Monster
    {
        public int attack { get; set; } = 10;
        public int health { get; set; } = 100;

        public string monsterName { get; set; }

        public void takeDamage(int damage)
        {
            health -= damage;
        }
        public void randomEncounter()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 3);
            if (randomNum == 1)
            {
                monsterName = "슬라임";
                attack += 10;
                Monster monster = new Slime();
            }
            else if (randomNum == 2)
            {
                monsterName = "오크";
                health += 100;
                Monster monster = new Orc();
            }
        }
        public virtual void monsAttack(User user) { }
        public virtual void monsAction(User user) { }
        public virtual void monsDie() { }
        public void monsterAttack(User user, Monster monster)
        {
            Console.WriteLine($"{monsterName}이(가) 공격하여 {attack}의 데미지를 입혔습니다.");
            Random random = new Random();
            int randomNum = random.Next(1, 3);
            if (randomNum == 1)
            {
                if(monster is Orc orc)
                {
                    orc.monsAttack(user);
                }
                else if (monster is Slime slime)
                {
                    slime.monsAttack(user);
                }
                user.currentStatus();
            }
            else if (randomNum == 2)
            {
                if (monster is Orc orc)
                {
                    orc.monsAction(user);
                }
                else if (monster is Slime slime)
                {
                    slime.monsAction(user);
                }
                user.currentStatus();
            }
            if (user.health <= 0)
            {
                monsterInfo();
                user.userLoss();
            }
            else
            {
                Console.WriteLine($"{monsterName}의 현재 체력은 {health}입니다.");
                Console.WriteLine($"{user.userName}의 현재 체력은 {user.health}입니다.");
            }
        }
        public void monsterInfo()
        {
            Console.WriteLine($"{monsterName}의 남은 체력은 {health} 공격력은 {attack}입니다.");
        }
    }
    public class Orc : Monster
    {
        public Orc() { }

        public override void monsAttack(User user)
        {
            Console.WriteLine($"{monsterName}이(가) 공격하여 {attack}의 데미지를 입혔습니다.");
            user.health -= attack;
        }
        public override void monsAction(User user)
        {
            Console.WriteLine($"{monsterName}이(가) 포효해 공격력이 {this.attack}만큼 증가합니다.");
            this.attack *= 2;
        }
        public override void monsDie()
        {
            Console.WriteLine($"{monsterName}을(를) 처치했습니다.");
        }
    }
    public class Slime : Monster
    {
        public Slime() { }

        public override void monsAttack(User user)
        {
            Console.WriteLine($"{monsterName}이(가) 공격하여 {attack}의 데미지를 입혔습니다.");
            user.health -= attack;
        }
        public override void monsAction(User user)
        {
            if (user.attack >= 6)
            {
                Console.WriteLine($"{monsterName}이(가) 점액을 발사해 {user.userName}의 공격력을 5 감소시켰습니다.");
                user.attack -= 5;
            }
            else
            {
                Console.WriteLine($"{monsterName}이(가) 점액을 발사해 {user.userName}의 공격력을 1로 감소시켰습니다.");
                user.attack = 1;
            }
        }
        public override void monsDie()
        {
            Console.WriteLine($"{monsterName}을(를) 처치했습니다.");
        }
    }
}
