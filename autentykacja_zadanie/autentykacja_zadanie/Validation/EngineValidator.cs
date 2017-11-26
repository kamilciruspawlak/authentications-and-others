using autentykacja_zadanie.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja_zadanie.Validation
{
    public class EngineValidator : AbstractValidator<Engine>
    {
        public EngineValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pole nazwa nie może być pusta!");
            RuleFor(x => x.Capacity).GreaterThan(1500).WithMessage("Capacity must be OVER 1500!");
            RuleFor(x => x.Capacity).LessThan(6000).WithMessage("capacity Mniej niz 6000");
            RuleFor(x => x.Name).Must(name => FirstLetter(name)).WithMessage("Pierwsza litera musi być duża!");
            RuleFor(x => x.Name).Must(name => NameLength(name)).WithMessage("Nazwa musi byc dłuższa niż 3 znaki i krótsza niż 16");
            RuleFor(x => x).Must(x => CapacityAndWeight(x)).WithMessage("Jezeli pojemnosc jest miedzy 1598 i 1601 to waga musi byc wieksza od 650");
            RuleFor(x => x).Must(x => CapacityAndName(x)).WithMessage("pojemnosc dziwna i nazwa AAA");
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Pojemność nie może być pust");
        }

        public bool FirstLetter(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                return char.IsUpper(name[0]);
                    
            }
            return false;
        }


        public bool NameLength(string name)
        {
            if (name.Length > 3 && name.Length <16)
            { return true; }
            return false;
        }


        public bool CapacityAndWeight(Engine engine)
        {
            if (engine.Capacity > 1598 && engine.Capacity < 1601)
            {
                if(engine.Weight>650)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool CapacityAndName(Engine engine)
        {
            if(engine.Capacity > 200 && engine.Name == "AAA")
            {
                return false;
            }
            return true;
        }
    }
}