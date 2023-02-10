using System.Collections;

public struct Attribute
{
    public Attribute(){}
    public Attribute(int hp, int speed, int power)
    {
        this.hp = hp;
        this.speed = speed;
        this.power = power;
    }

    public int hp;
    public int speed;
    public int power;
}
namespace Program
{
    public class Project
    {
        static public void Main(string[] args)
        {

        }

        public static void TakeWeaponIfDead(ref Fighter taker, ref Fighter giver)
        {
            if (taker.IsAlive() && !giver.IsAlive() && giver.HasWeapon())
            {
                if (giver.Wep.Rank > taker.Wep.Rank)
                {
                    Console.WriteLine(
                        "{0} takes the {1} from {2}",
                        taker.Name, giver.Wep.Name, giver.Name);
                    taker.GiveWeapon(giver.PilferWeapon());
                }
            }
        }

        public static void Engage(ref Fighter F1, ref Fighter F2)
        {
            if( F1.GetInitiative() < F2.GetInitiative() )
        	{
        	    F1.Attack( ref F2 );
        	    TakeWeaponIfDead( ref F1, ref F2 );
        	    F2.Attack( ref F1 );
        	    TakeWeaponIfDead( ref F2, ref F1 );
        	}
            else
            {
                F2.Attack( ref F1 );
        	    TakeWeaponIfDead( ref F2, ref F1 );
        	    F1.Attack( ref F2 );
        	    TakeWeaponIfDead( ref F1, ref F2 );
            }
        }

        public static void DoSpecials(ref Fighter F1,ref Fighter F2 )
        {
        	if( F1.GetInitiative() < F2.GetInitiative() )
        	{
        	    F1.SpecialMove( ref F2 );
        	    TakeWeaponIfDead( ref F1, ref F2 );
        	    F2.SpecialMove( ref F1 );
        	    TakeWeaponIfDead( ref F2, ref F1 );
        	}
            else
            {
                F2.SpecialMove( ref F1 );
        	    TakeWeaponIfDead( ref F2, ref F1 );
        	    F1.SpecialMove( ref F2 );
        	    TakeWeaponIfDead( ref F1, ref F2 );
            }
        }
    
        public static bool AnyAliveFighter(ref List<Fighter> fighters)
        {
            foreach (var f in fighters)
            {
                if (f.IsAlive())
                {
                    return true;
                }
            }
            return false;
        }
    
        public static void PartitionAlive(ref List<Fighter> fighters)
        {
            var alive = new List<Fighter>();
            var dead = new List<Fighter>();

            foreach (var f in fighters)
            {
                if (f.IsAlive())
                {
                    alive.Add(f);
                }
                else
                {
                    dead.Add(f);
                }
            }

            var complete = new List<Fighter>();
            complete.AddRange(alive);
            complete.AddRange(dead);
            fighters = complete;
        }
    
        public static void Shuffle(ref List<Fighter> fighters)
        {
            //Hitary, your turn man, also try the game in c++ and c#
            //Tell me the differences and we can fix them boiiiii
            //Also shuffle means لخبط
        }
    }
}
