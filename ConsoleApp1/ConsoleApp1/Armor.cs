using System;

namespace ZuulCS
{
	public class Armor : Item
    {
        private float protection;
        private Random random = new Random();
        private int armorType = -1;

        public Armor(int typeOfArmor,float protection, string nameItem, float weightOfItem) : base(nameItem, weightOfItem)
        {
            this.protection = protection;
            this.armorType = typeOfArmor;
        }

        public override void use(Player player)
        {
            if (this.GetType() == typeof(Armor))
            {  
                int hasArmorEquipt;

                if(this.armorType == 1)
                {
                    if (!player.getHelmet())
                    {
                        player.setHelmet(true);
                        hasArmorEquipt = 1;
                    }
                    else
                    {
                        player.setHelmet(false);
                        hasArmorEquipt = 2;
                    }
                    
                }
                else if (this.armorType == 2)
                {
                    if (!player.getChestplate())
                    {
                        player.setChestplate(true);
                        hasArmorEquipt = 1;
                    }
                    else
                    {
                        player.setChestplate(false);
                        hasArmorEquipt = 2;
                    }
                }
                else if (this.armorType == 3)
                {
                    if (!player.getChestplate())
                    {
                        player.setLeggings(true);
                        hasArmorEquipt = 1;
                    }
                    else
                    {
                        player.setLeggings(false);
                        hasArmorEquipt = 2;
                    }
                }
                else if (this.armorType == 4)
                {
                    if (!player.getChestplate())
                    {
                        player.setBoots(true);
                        hasArmorEquipt = 1;
                    }
                    else
                    {
                        player.setBoots(false);
                        hasArmorEquipt = 2;
                    }
                }
                else
                {
                    hasArmorEquipt = 0;
                }

                if(hasArmorEquipt == 1)
                {
                    player.setArmorProtection(this.protection);
                    Console.WriteLine("You are now wearing the armor...");
                }

                if (hasArmorEquipt == 2)
                {
                    player.setArmorProtection(-this.protection);
                    Console.WriteLine("You took off the armor...");
                }
            }
        }
    }
}
