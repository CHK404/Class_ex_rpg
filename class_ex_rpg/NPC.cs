using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class_ex_rpg
{
    public class NPC
    {
        public string npcJob { get; set; }

        public void npcChoice(User user, Monster monster, NPC npc)
        {
            Console.WriteLine("NPC가 나타나 전투에 도움을 줍니다.");
            Random rand = new Random();
            int randomNum = rand.Next(1, 3);
            if (randomNum == 1)
            {
                Console.WriteLine("힐러가 나타났습니다.");
                npc.npcJob = "힐러";
                npc = new Healer();
                npc.npcAction(user, monster, npc);
            }
            else if (randomNum == 2)
            {
                Console.WriteLine("버퍼가 나타났습니다.");
                npc.npcJob = "버퍼";
                npc = new Buffer();
                npc.npcAction(user, monster, npc);
            }
            else if (randomNum == 3)
            {
                Console.WriteLine("디버퍼가 나타났습니다.");
                npc.npcJob = "디버퍼";
                npc = new Debuffer();
                npc.npcAction(user, monster, npc);
            }
        }
        public void Talk(User user)
        {
            MessageBox.Show($"{user.userName}용사님 몬스터를 무찔러주세요.");
        }
        public virtual void npcAction(User user, Monster monster, NPC npc) { }
        public class Healer : NPC
        {
            public Healer()
            {
                this.npcJob = "힐러";
            }
            public int healAmount { get; set; }
            public override void npcAction(User user, Monster monster, NPC npc)
            {
                healAmount = 20;
                Console.WriteLine($"{user.userName}의 체력이 {healAmount}만큼 증가했습니다.");
                user.health += healAmount;
            }
        }
        public class Buffer : NPC
        {
            public Buffer()
            {
                this.npcJob = "버퍼";
            }
            public int bufferAmount { get; set; }
            public override void npcAction(User user, Monster monster, NPC npc)
            {
                bufferAmount = 5;
                Console.WriteLine($"{user.userName}의 공격력이 {bufferAmount}만큼 증가했습니다.");
                user.attack += bufferAmount;
            }
        }
        public class Debuffer : NPC
        {
            public Debuffer()
            {
                this.npcJob = "디버퍼";
            }
            public int debuffAmount { get; set; }
            public override void npcAction(User user, Monster monster, NPC npc)
            {
                debuffAmount = 3;
                Console.WriteLine($"{monster.monsterName}의 공격력이 {debuffAmount}만큼 감소했습니다.");
                monster.attack -= debuffAmount;
            }
        }
    }
}
