using System;
namespace P0
{
    class Shooter
    {
        public int bullets = 0;
        public bool shoot = false;
        public bool reload = false;
        public bool shield = false;
        public bool alive = true;

        public Shooter() { }
        public Shooter(int bullets, bool shoot, bool reload, bool shield, bool alive)
        {
            this.bullets = bullets;
            this.shoot = shoot;
            this.reload = reload;
            this.shield = shield;
            this.alive = alive;
        }
    }
}