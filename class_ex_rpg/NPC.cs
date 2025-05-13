using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_ex_rpg
{
    internal class NPC
    {
        public int attack { get; set; } = 3;
        public string npcJob { get; set; }

        public void npcChoice()
        {
            Console.WriteLine("NPC를 선택하세요. 1. 힐러 2. 버퍼 3. 디버퍼");
            string select = Console.ReadLine();
            if (select == "1")
            {
                Console.WriteLine("힐러를 선택했습니다.");
                npcJob = "힐러";
            }
            else if (select == "2")
            {
                Console.WriteLine("버퍼를 선택했습니다.");
                npcJob = "버퍼";
            }
            else if (select == "3")
            {
                Console.WriteLine("디버퍼를 선택했습니다.");
                npcJob = "디버퍼";
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                npcChoice();
            }
        }

        public class Healer : NPC
        {
            NPC healer = new Healer();
            public Healer()
            {
                npcJob = "힐러";
            }
            public int healAmount { get; set; }
            public void npcAction(User user, NPC npc)
            {
                Console.WriteLine($"{user.userName}이(가) {healAmount}만큼 회복했습니다.");
                user.health += healAmount;
            }
        }
        public class Buffer : NPC
        {
            NPC buffer = new Buffer();
            public Buffer()
            {
                npcJob = "버퍼";
            }
            public int bufferAmount { get; set; }
            public void npcAction(User user, NPC npc)
            {
                Console.WriteLine($"{user.userName}이(가) {bufferAmount}만큼 공격력이 증가했습니다.");
                user.attack += bufferAmount;
            }
        }
        public class Debuffer : NPC
        {
            NPC debuffer = new Debuffer();
            public Debuffer()
            {
                npcJob = "디버퍼";
            }
            public int debuffAmount { get; set; }
            public void npcAction(Monster monster, NPC npc)
            {
                Console.WriteLine($"{monster.monsterName}이(가) {debuffAmount}만큼 공격력이 감소했습니다.");
                monster.attack -= debuffAmount;
            }
        }
    }
}
