using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace BattleShip.UI
{
     public class Sound

    {
       public void Intro()
        {
            var intro = new System.Media.SoundPlayer();
            intro.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Music\Intro.wav";
            intro.PlayLooping();
        }
        public void Prompt()
        {
            var prompt = new System.Media.SoundPlayer();
            prompt.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Effects\Prompt.wav";
            prompt.Play();
        }
        public void FireHit()
        {
            var hit = new System.Media.SoundPlayer();
            hit.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Effects\1FireHit.wav";
            hit.Play();
        }
        public void FireMiss()
        {
            var miss = new System.Media.SoundPlayer();
            miss.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Effects\FireMiss.wav";
            miss.Play();
        }
        public void FireHitandSink()
        {
            var hitsink = new System.Media.SoundPlayer();
            hitsink.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Effects\FireHitAndSink.wav";
            hitsink.Play();
        }
        public void Error()
        {
            var error = new System.Media.SoundPlayer();
            error.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Effects\Error.wav";
            error.Play();
        }
        public void Victory()
        {
            var victory = new System.Media.SoundPlayer();
            victory.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Music\Victory.wav";
            victory.Play();
        }

         public void NuclearOption()
         {
             var nuke = new System.Media.SoundPlayer();
             nuke.SoundLocation = @"C:\_repos\battleship-zachm-and-bryantc\Battleship\BattleShip_Start\Sounds\Effects\NuclearOption.wav";
             nuke.Play();
         }


    }
}
