using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_ex_rpg
{
    public class User
    {
        public int health { get; set; } = 100;
        public int attack { get; set; } = 5;
        public string userName { get; set; }
        public string job { get; set; }
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
                    health += 50;
                    break;
                }else if (select == "2")
                {
                    user.job = "마법사";
                    attack += 3;
                    break;
                }else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        public virtual void baseAttack(Monster monster) { }
        public virtual void skillAttack(Monster monster) { }
        public virtual void buff() { }
        public void chooseAct(User user, Monster monster)
        {
            Console.WriteLine("행동을 선택하세요.");
            Console.WriteLine("1. 기본 공격");
            Console.WriteLine("2. 스킬 공격");
            Console.WriteLine("3. 버프");
            string select = Console.ReadLine();

            if (select == "1")
            {
                Console.WriteLine($"{userName}이(가) 기본 공격을 선택했습니다.");
                if (user is Warrior warrior)
                {
                    warrior.baseAttack(monster);
                }
                else if (user is Mage mage)
                {
                    mage.baseAttack(monster);
                }
                monster.monsterInfo();
            }
            else if (select == "2")
            {
                Console.WriteLine($"{userName}이(가) 스킬 공격을 선택했습니다.");
                if (user is Warrior warrior)
                {
                    warrior.skillAttack(monster);
                }
                else if (user is Mage mage)
                {
                    mage.skillAttack(monster);
                }
                monster.monsterInfo();
            }
            else if (select == "3")
            {
                Console.WriteLine($"{userName}이(가) 버프를 선택했습니다.");
                if (user is Warrior warrior)
                {
                    warrior.buff();
                }
                else if (user is Mage mage)
                {
                    mage.buff();
                }
                user.currentStatus();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                chooseAct(user, monster);
                return;
            }
            if (monster.health <= 0)
            {
                Console.WriteLine($"{monster.monsterName}을(를) 처치했습니다.");
                Console.WriteLine($"{userName}의 현재 체력은 {user.health}입니다.");
                Console.WriteLine($"토벌에 성공하였습니다.");
                user.currentStatus();
                return;
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
            Console.WriteLine($"{userName}이(가) 사망했습니다.");
            Console.WriteLine($"게임을 종료합니다.");
        }
    }
    public class Warrior : User
    {
        public Warrior() { }

        public override void baseAttack(Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 검으로 {monster.monsterName}을(를) 공격해 {attack}의 데미지를 입혔습니다.");
            monster.takeDamage(attack);
        }

        public override void skillAttack(Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 검으로 {monster.monsterName}을(를) 강하게 내리쳐 {this.attack + 5}의 데미지를 입혔습니다.");
            monster.takeDamage(attack + 5);
        }

        public override void buff()
        {
            Console.WriteLine($"{userName}이(가) 사기를 올려 공격력을 {this.attack + 3}으로 증가시켰습니다.");
            this.attack += 3;
        }
    }

    public class Mage : User
    {
        public Mage() { }
        public override void baseAttack(Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 마법으로 {monster.monsterName}을(를) 공격해 {this.attack}의 데미지를 입혔습니다.");
        }
        public override void skillAttack(Monster monster)
        {
            Console.WriteLine($"{userName}이(가) 불꽃을 소환해 {monster.monsterName}에게 {this.attack * 2}의 데미지를 입혔습니다.");
            monster.takeDamage(this.attack * 2);
        }
        public override void buff()
        {
            Console.WriteLine($"{userName}이(가) 정신을 집중해 공격력을 {this.attack + 5}으로 증가시켰습니다.");
            this.attack += 3;
        }
    }
}
