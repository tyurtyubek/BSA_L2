using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using BSA_2.Animals;

namespace BSA_2
{
    class ZooAlive
    {
        private Zoo _zoo;
        private System.Timers.Timer aTimer;
        public ZooAlive()
        {
            _zoo = new Zoo();
        }
        public void LetsZooAlive()
        {
            while (Timer5() == 1)
            {
                Console.WriteLine("Enter 1 for displaing all animal\n" +
                    "Enter 2 for adding new animal\n" +
                    "Enter 3 for feeding animal\n" +
                    "Enter 4 for curing animal\n" +
                    "Enter 5 for removing animal");

                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());

                    switch (number)
                    {
                        case 1:
                            {
                                _zoo.Display();
                                break;
                            }
                        case 2:
                            {

                                Console.WriteLine("Enter animal type: 1-lion 2-tiger 3-elephant 4-bear 5-wolf 6-fox");

                                int number2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Please enter animal name");
                                string name = Console.ReadLine();
                                switch (number2)
                                {
                                    case 1: _zoo.Add(new Lion(name)); break;
                                    case 2: _zoo.Add(new Tiger(name)); break;
                                    case 3: _zoo.Add(new Elephant(name)); break;
                                    case 4: _zoo.Add(new Bear(name)); break;
                                    case 5: _zoo.Add(new Wolf(name)); break;
                                    case 6: _zoo.Add(new Fox(name)); break;
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Please enter name animal for feeding\n");
                                string name = Console.ReadLine();
                                _zoo.Feed(name);
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Please enter name animal for curing\n");
                                string name = Console.ReadLine();
                                _zoo.Cure(name);
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Please enter name animal for removing dead pets\n");
                                string name = Console.ReadLine();
                                _zoo.Remove();
                                break;
                            }

                    }
                }
                catch
                {
                    Console.WriteLine("Eror entering");
                }
            }

        }
        public int Timer5()
        {
            if (_zoo.CountAnimals == 0) { return 0; aTimer.Elapsed -= OnTimedEvent; }
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 5000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            return 1;

        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var rand = new Random();
            int random = rand.Next(0, _zoo.CountAnimals);
            if (_zoo.CountAnimals != 0)
            {
                var animal = _zoo.GetAnimals().ElementAt(random);
                if (animal.AnimalCondition == State.full)
                {
                    animal.AnimalCondition = State.hungry;
                    Console.WriteLine($"{animal.Name} change state from full -> hungry ");
                }

                else if (animal.AnimalCondition == State.hungry)
                {
                    animal.AnimalCondition = State.sick;
                    Console.WriteLine($"{animal.Name} change state from hungry ->  sick");
                }

                else if (animal.AnimalCondition == State.sick)
                {
                    animal.HealthPoints--;
                    if (animal.HealthPoints == 0)
                    {
                        animal.AnimalCondition = State.dead;
                        _zoo.Remove();
                        Console.WriteLine($"{animal.Name} died and removed from zoo");

                    }
                    Console.WriteLine($"{animal.Name} Lost health position and now health is {animal.HealthPoints}");
                }

            }
        }
    }
}
