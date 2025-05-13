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
            Monster monster = new Monster();

            Console.Write("이름을 입력하세요: ");
            user.userName = Console.ReadLine();

            user.SelectClass(user);
            if (user.job == "전사")
            {
                user = new Warrior();
            }
            else if (user.job == "마법사")
            {
                user = new Mage();
            }
            user.userInfo(user);
            user.currentStatus();

            monster.randomEncounter();
            if (monster is Orc orc)
            {
                monster = new Orc();
            }
            else if (monster is Slime slime)
            {
                monster = new Slime();
            }

            if (monster.health == 0)
            {
                monster.randomEncounter();
            }else
            {
                user.chooseAct(user, monster);
                monster.monsterAttack(user, monster);
            }
        }
    }
}
