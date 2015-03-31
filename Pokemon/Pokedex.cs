﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Pokedex
    {
        public BaseStats baseStats { get; set; }
        public Abilities abilities { get; set; }
        public List<string> types { get; set; }
        public double heightm { get; set; }
        public double weightkg { get; set; }
        public string species { get; set; }


        public string key { get; set; }

        public Pokedex(string name)
        {
            var pokedex = Util.loadJson("pokedex.json").BattlePokedex;

            this.key = Util.toKey(name);

            baseStats = new BaseStats();
            abilities = new Abilities();
            types = new List<string>();


            baseStats.hp  = (uint) pokedex[key].baseStats.hp;
            baseStats.atk = (uint) pokedex[key].baseStats.atk;
            baseStats.def = (uint) pokedex[key].baseStats.def;
            baseStats.spa = (uint) pokedex[key].baseStats.spa;
            baseStats.spd = (uint) pokedex[key].baseStats.spd;
            baseStats.spe = (uint) pokedex[key].baseStats.spe;

            abilities.first = pokedex[key].abilities.first;
            if (pokedex[key].abilities.IsDefined("second")) abilities.second = pokedex[key].abilities.second;
            if (pokedex[key].abilities.IsDefined("H")) abilities.hidden = pokedex[key].abilities.H;

            foreach (string type in pokedex[key].types)
            {
                types.Add(type);
            }

            heightm = pokedex[key].heightm;
            weightkg = pokedex[key].weightkg;

            species = pokedex[key].species;

        }
    }
}
