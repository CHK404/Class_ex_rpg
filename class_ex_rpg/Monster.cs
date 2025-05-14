using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace class_ex_rpg
{
    public class Monster
    {
        public int attack { get; set; } = 10;
        public int health { get; set; } = 100;

        public string monsterName { get; set; }

        public void monsDamage(int damage)
        {
            health -= damage;
        }
        public static Monster RandomEncounter()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 3);
            if (randomNum == 1)
            {
                return new Slime();
            }
            else
            {
                return new Orc();
            }
        }
        public virtual void monsAttack(User user, Monster monster) { }
        public virtual void monsAction(User user, Monster monster) { }
        public virtual void monsDie(Monster monster) { }
        public virtual void Talk() { }
        public void monsterAttack(User user, Monster monster)
        {
            if (monster.health <= 0)
            {
                return;
            }
            if (user.health <= 0)
            {
                return;
            }
            {
                Random random1 = new Random();
                int randomNum = random1.Next(1, 100);
                if (randomNum % 2 == 0)
                {
                    monster.monsAttack(user, monster);
                    user.currentStatus();
                    monster.monsterInfo();
                }
                else if (randomNum % 2 == 1)
                {
                    monster.monsAction(user, monster);
                    user.currentStatus();
                    monster.monsterInfo();
                }
            }
        }
        public void monsterInfo()
        {
            Console.WriteLine($"{monsterName}의 남은 체력은 {health} 공격력은 {attack}입니다.");
        }
        
    }
    public class Orc : Monster
    {
        public Orc()
        {
            this.monsterName = "오크";
            this.attack = 5;
            this.health = 250;
        }

        public override void monsAttack(User user, Monster monster)
        {
            Console.WriteLine($"{monsterName}이(가) 공격하여 {this.attack}의 데미지를 입혔습니다.");
            user.userDamage(this.attack);
        }
        public override void monsAction(User user, Monster monster)
        {
            Console.WriteLine($"{monsterName}이(가) 포효해 공격력이 {this.attack}만큼 증가합니다.");
            this.attack *= 2;
        }
        public override void monsDie(Monster monster)
        {
            Console.WriteLine($"{monsterName}을(를) 처치했습니다.");
        }
        public override void Talk()
        {
            MessageBox.Show("취익취익");
        }
    }
    public class Slime : Monster
    {
        public Slime()
        {
            this.monsterName = "슬라임";
            this.attack = 20;
            this.health = 100;
        }

        public override void monsAttack(User user, Monster monster)
        {
            Console.WriteLine($"{monsterName}이(가) 공격하여 {this.attack}의 데미지를 입혔습니다.");
            user.userDamage(this.attack);
        }
        public override void monsAction(User user, Monster monster)
        {
            if (user.attack >= 4)
            {
                Console.WriteLine($"{monsterName}이(가) 점액을 발사해 {user.userName}의 공격력을 3 감소시켰습니다.");
                user.attack -= 3;
            }
            else
            {
                Console.WriteLine($"{monsterName}이(가) 점액을 발사해 {user.userName}의 공격력을 1로 감소시켰습니다.");
                user.attack = 1;
            }
        }
        public override void monsDie(Monster monster)
        {
            Console.WriteLine($"{monsterName}을(를) 처치했습니다.");
        }
        public override void Talk()
        {
            MessageBox.Show("스르륵");
        }
    }
}
