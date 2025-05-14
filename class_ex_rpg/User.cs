using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace class_ex_rpg
{
    public class User
    {
        public int health { get; set; } = 100;
        public int attack { get; set; } = 5;
        public string userName { get; set; }
        public string job { get; set; }
        public void userDamage(int damage)
        {
            health -= damage;
        }
        public void SelectClass(User user)
        {
            while (true)
            {
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                string select = Console.ReadLine();

                if (select == "1")
                {
                    user.job = "전사";
                    health += 100;
                    break;
                }else if (select == "2")
                {
                    user.job = "마법사";
                    attack += 2;
                    break;
                }else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public virtual void baseAttack(User user, Monster monster)
        {
            if (user.job == "전사")
            {
                user = new Warrior(user);
            }
            else if (user.job == "마법사")
            {
                user = new Mage(user);
            }
        }
        public virtual void skillAttack(User user, Monster monster)
        {
            if (user.job == "전사")
            {
                user = new Warrior(user);
            }
            else if (user.job == "마법사")
            {
                user = new Mage(user);
            }
        }
        public virtual void buff(User user, Monster monster) 
        {
            if (user.job == "전사")
            {
                user = new Warrior(user);
            }
            else if (user.job == "마법사")
            {
                user = new Mage(user);
            }
        }
        public void chooseAct(User user, Monster monster)
        {
            if (user.health <= 0)
            {
                user.userLoss();
                return;
            }
            if (monster.health <= 0)
            {
                monster.monsDie(monster);
                Console.WriteLine($"{userName}의 현재 체력은 {user.health}입니다.");
                Console.WriteLine($"토벌에 성공하였습니다!");
                user.LevelUp(user);
                user.currentStatus();
                return;
            }
            Console.WriteLine("행동을 선택하세요. 1. 기본 공격 2. 스킬 공격 3. 버프");
            string select = Console.ReadLine();

            if (select == "1")
            {
                Console.WriteLine($"{userName}이(가) 기본 공격을 선택했습니다.");
                user.baseAttack(user, monster);
            }
            else if (select == "2")
            {
                Console.WriteLine($"{userName}이(가) 스킬 공격을 선택했습니다.");
                user.skillAttack(user, monster);
            }
            else if (select == "3")
            {
                Console.WriteLine($"{userName}이(가) 버프를 선택했습니다.");
                user.buff(user, monster);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                user.chooseAct(user, monster);
            }
            chooseAct(user, monster);
        }
        public void userInfo(User user)
        {
            Console.WriteLine($"{userName}님의 직업은 {user.job}입니다.");
        }
        public void currentStatus()
        {
            Console.WriteLine($"{userName}님의 현재 공격력은 {attack} 체력은 {health}입니다.");
        }
        public void userLoss()
        {
            Console.WriteLine($"{userName}이(가) 사망했습니다...");
            Console.WriteLine($"게임을 종료합니다...");
        }
        public void LevelUp(User user)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length == 2)
            {
                int hp = int.Parse(input[0]);
                int power = int.Parse(input[1]);
            }else if (input.Length == 1)
            {
                int hp = int.Parse(input[0]);
            }else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            user.health += this.hp;

        }
    }
    public class Warrior : User
    {
        public Warrior(User user)
        {
            this.userName = user.userName;
            this.job = "전사";
            this.health = user.health;
            this.attack = user.attack;
        }
        public override void baseAttack(User user, Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 검으로 {monster.monsterName}을(를) 공격해 {this.attack}의 데미지를 입혔습니다.");
            monster.monsDamage(this.attack);
            monster.monsterAttack(user, monster);
        }

        public override void skillAttack(User user, Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 검으로 {monster.monsterName}을(를) 강하게 내리쳐 {this.attack * 2}의 데미지를 입혔습니다.");
            monster.monsDamage(this.attack * 2);
            monster.monsterAttack(user, monster);
        }

        public override void buff(User user, Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 사기를 올려 공격력을 {this.attack + 3}으로 증가시켰습니다.");
            this.attack += 3;
            monster.monsterAttack(user, monster);
        }
    }

    public class Mage : User
    {
        public Mage(User user)
        {
            this.userName = user.userName;
            this.job = "마법사";
            this.health = user.health;
            this.attack = user.attack;
        }
        public override void baseAttack(User user, Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 마법으로 {monster.monsterName}을(를) 공격해 {this.attack}의 데미지를 입혔습니다.");
            monster.monsDamage(this.attack);
            monster.monsterAttack(user, monster);
        }
        public override void skillAttack(User user, Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 거대한 불꽃을 소환해 {monster.monsterName}에게 {this.attack * 3}의 데미지를 입혔습니다.");
            monster.monsDamage(this.attack * 3);
            monster.monsterAttack(user, monster);
        }
        public override void buff(User user, Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 정신을 집중해 공격력을 {this.attack + 5}으로 증가시켰습니다.");
            this.attack += 5;
            monster.monsterAttack(user, monster);
        }
    }
}
