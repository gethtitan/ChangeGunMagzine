using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGunMagzine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GunMagzine gunMagzine = new GunMagzine(30,100,30);
            gunMagzine.SetAmmo();
            while (true) 
            {
                if (gunMagzine.BallsInMagzine==0&&gunMagzine.RemainBalls>0)
                {
                    gunMagzine.Reload();
                }
                if (gunMagzine.OutOfAmmo())
                {
                    Console.WriteLine("Warning: You're out of ammo");
                }
                Console.WriteLine($"{gunMagzine.RemainBalls} balls, {gunMagzine.BallsInMagzine} in magzine");
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
                char key=Console.ReadKey(true).KeyChar;
                if (key == ' ')
                {
                    Console.WriteLine($"Shooting returned {gunMagzine.Shoot()}");
                }
                else if (key == 'r')
                {
                    gunMagzine.Reload();
                }
                else if (key == '+')
                {
                    gunMagzine.SetAmmo();
                }
                else if (key == 'q')
                {
                    return;
                }
            }
        }
    }

    class GunMagzine
    {

        public int Magzine_Size { get; private set; }


        public int RemainBalls { get; private set; }

        public int BallsInMagzine { get; private set; }

        public bool OutOfAmmo() { return RemainBalls == 0 && BallsInMagzine == 0; }

        public GunMagzine(int magzine_Size, int remainBalls, int ballsInMagzine)
        {
            Magzine_Size = Magzine_Size;
            RemainBalls = remainBalls;
            BallsInMagzine = ballsInMagzine;
        }

        public void SetAmmo()
        {
            RemainBalls = 100;
            BallsInMagzine = 30;
        }

        public void Reload()
        {
            if (BallsInMagzine < Magzine_Size)
            {
               int needBallsToFull=Magzine_Size- BallsInMagzine;

                if (RemainBalls <= needBallsToFull)
                {
                    BallsInMagzine = RemainBalls;
                    RemainBalls = 0;
                }
                else
                {
                    BallsInMagzine = Magzine_Size;
                    RemainBalls -= needBallsToFull;
                }
            }
            else
            {
                Console.WriteLine("Magzine is full");
            }

        }

        public bool Shoot()
        {
            if (BallsInMagzine == 0)
            {
                return false;
            }
            else
            { 
                BallsInMagzine--;
                return true;
            }
        }

    }
}
