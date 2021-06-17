using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public abstract class Person : Entity
    {
        //Ideja ove klase je bila da bude nadklasa klase USER i TRAINER,
        //ali kada se napravi migracija napravi se samo tabela PERSON dok se USER i TRAINER ignorise.

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        //public int Age { get; set; }
        //public Gender Gender { get; set; }
        //public float? Height { get; set; }
        //public float? Weight { get; set; }
        //public float? BodyFatPercent { get; set; }
        //public float? BodyMusclePercent { get; set; }
        //public int CardId { get; set; }
        //public virtual Card Card { get; set; }

    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
