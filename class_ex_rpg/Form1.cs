using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class_ex_rpg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            User user = new User();
            NPC npc = new NPC();

            Console.Write("이름을 입력하세요: ");
            user.userName = Console.ReadLine();
            npc.Talk(user);
            user.SelectClass(user);
            if (user.job == "전사")
            {
                user = new Warrior(user);
            }
            else if (user.job == "마법사")
            {
                user = new Mage(user);
            }
            user.userInfo(user);
            user.currentStatus();

            Monster monster = Monster.RandomEncounter();

            while (user.health > 0)
            {
                monster.Talk();
                npc.npcChoice(user, monster, npc);

                while (monster.health > 0 && user.health > 0)
                {
                    user.chooseAct(user, monster);
                    monster.monsterAttack(user, monster);
                }
                if (user.health > 0) 
                {
                    Console.WriteLine("새로운 몬스터가 나타났습니다!");
                    monster = Monster.RandomEncounter();
                }
            }
            user.userLoss();
        }
    }
}
