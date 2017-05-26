using System;
using System.Collections.Generic;
using System.Linq;
using BSA_2.Animals;

namespace BSA_2
{
    class Zoo
    {
        //public zoo
        IList<IAnimal> _animals;

        public Zoo()
        {
            _animals = new List<IAnimal>();
            _animals.Add(new Lion("KingLion"));
            _animals.Add(new Tiger("Tigrenok"));
            _animals.Add(new Elephant("Bony"));
            _animals.Add(new Bear("Balu"));
        }

        public void Add(IAnimal animalState)
        {
            _animals.Add(animalState);
            Console.WriteLine($"You just added new animal: {animalState.GetType().Name} - {animalState.Name}");
        }

        public void Feed(string name)
        {
            IEnumerable<IAnimal> animalfeed = _animals.Where(animal => animal.Name == name);
            if (!animalfeed.Any())
                Console.WriteLine($"Can`t feed, there is no animal with name {name}");
            else
            {
                foreach (var animal in animalfeed)
                {
                    if (animal.AnimalCondition == State.sick) animal.AnimalCondition = State.hungry;
                    if (animal.AnimalCondition == State.hungry) animal.AnimalCondition = State.full;
                    if (animal.AnimalCondition == State.full) Console.WriteLine($"{animal.GetType().Name} - {name} is already full");
                    if (animal.AnimalCondition == State.dead) Console.WriteLine($"we can`t feed dead {name}");
                }
            }
        }

        public IList<IAnimal> GetAnimals()
        {
            return _animals;
        }

        public void Cure(string name)
        {
            IEnumerable<IAnimal> animalcure = _animals.Where(animal => animal.Name == name);
            if (!animalcure.Any())
                Console.WriteLine($"Can`t cure, there is no animal with name {name}");
            else
            {
                foreach (var animal in animalcure)
                {
                    if (animal.HealthPoints < animal.MaxHealthPoints) animal.HealthPoints++;
                    Console.WriteLine($"We cured {animal.GetType().Name}-{name} and health point = {animal.HealthPoints}");
                }
            }
        }

        public void Remove()
        {
            var animalsdead = _animals.Where(animal => animal.AnimalCondition == State.dead);
            foreach (var element in animalsdead)
            {
                _animals.Remove(element);
                Console.WriteLine($"{element.Name} was removed from zoo");
            }
        }

        public void Display()
        {
            Console.WriteLine("All residents of the zoo are - {0} ", _animals.Count());
            foreach (var resident in _animals)
            {
                Console.WriteLine($"{resident.GetType().Name} - Name: {resident.Name}, " +
                    $"state: {resident.AnimalCondition}, health point: {resident.HealthPoints}");
            }
        }

        public int CountAnimals { get { return _animals.Count(); } }


    }
}
