using System;
using Laba10_1;
using System.Collections;

namespace Laba11C
{
    class MenuArrayList
    {
        public bool Exit = true;

        ArrayList personsList=new ArrayList();

        Random random = new Random();


        int CheckEnterNumber()
        {
            while (true)
            {
                try
                {
                    int Number = int.Parse(Console.ReadLine());
                    if(Number>0)
                        return Number;
                    else
                        Console.WriteLine("Ошибка! Попробуйте ввести целое число больше 0");
                }
                catch
                {
                    Console.WriteLine("Ошибка! Попробуйте ввести целое число больше 0");
                }
            }
        }


        int ShowMenu(params string[] options) // вывод меню
        {
            const int startX = 0;
            const int startY = 0;
            const int optionsPerLine = 1;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX, startY + i);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection + 1;
        }


        void ShowArray(ArrayList arrayList)
        {
            int count = 0;
            foreach(Persona persona in arrayList)
            {
                count++;
                Console.WriteLine($"{count}. {persona}\n") ;
            }
        }
       

        ArrayList CreateRandomArrayList()
        {
            Console.Clear();
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < random.Next(3, 8); i++)
            {
                switch (random.Next(1, 5))
                {
                    case 1:
                        Persona persona = new Persona();
                        persona.Init();
                        arrayList.Add(persona);

                        break;
                    case 2:
                        Clerk clerk = new Clerk();
                        clerk.Init();
                        arrayList.Add(clerk);
                        break;
                    case 3:
                        Engineer engineer = new Engineer();
                        engineer.Init();
                        arrayList.Add(engineer);
                        break;
                    case 4:
                        Worker worker = new Worker();
                        worker.Init();
                        arrayList.Add(worker);
                        break;
                }
            }

            ShowArray(arrayList);
            Console.ReadKey();
            return arrayList;
        }


        ArrayList AddRandomPerson(ArrayList arrayList)
        {
            Console.Clear();

            switch (random.Next(1, 5))
            {
                case 1:
                    Persona persona = new Persona();
                    persona.Init();
                    arrayList.Add(persona);

                    break;
                case 2:
                    Clerk clerk = new Clerk();
                    clerk.Init();
                    arrayList.Add(clerk);
                    break;
                case 3:
                    Engineer engineer = new Engineer();
                    engineer.Init();
                    arrayList.Add(engineer);
                    break;
                case 4:
                    Worker worker = new Worker();
                    worker.Init();
                    arrayList.Add(worker);
                    break;
            }

            ShowArray(arrayList);
            Console.ReadKey();
            return arrayList;
        }


        ArrayList DelPerson(ArrayList arrayList)
        {
            if (personsList.Count!=0)
            {
                Console.Clear();
                ShowArray(arrayList);
                Console.WriteLine("Введите номер персоны который хотите удалить");
                try
                {
                    int index = CheckEnterNumber();
                    arrayList.RemoveAt(index-1);
                }
                catch
                {
                    Console.WriteLine("Данного индекса несуществует");
                }

                ShowArray(arrayList);
                return arrayList;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Пустой массив");
                Console.ReadKey();
                ArrayList personsList = new ArrayList();
                return personsList;
            }
        }


        void NamesWoman(ArrayList persons)
        {
            Console.Clear();
            if (persons != null)
            {
                ArrayList namesWoman = new ArrayList();
                ArrayList nameWomanList = new ArrayList();
                int count = 0;
                foreach (Persona persona in persons)
                {
                    if (persona.Gender == "Женский")
                    {
                        persona.Show();
                        count++;
                        nameWomanList.Add(persona);
                    }
                }
                if (nameWomanList.Count == 0)
                {
                    Console.WriteLine("Женщин нет");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Пустой массив");
                Console.ReadKey();
            }
        }


        int CountEngineer(ArrayList persons)
        {
            Console.Clear();
            if (persons != null)
            {
                int count = 0;
                foreach (Persona persona in persons)
                {
                    if (persona is Engineer)
                    {
                        if (((Engineer)persona).FirstName != "Нет имени")
                            count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Инеженеров нет");
                    Console.ReadKey();
                    return 0;
                }
                else
                {
                    Console.WriteLine($"Количество инженеров:{count}");
                    Console.ReadKey();
                    return count;
                }
            }
            else
            {
                Console.WriteLine("Пустой массив");
                Console.ReadKey();
                return 0;
            }
        }


        int MaxEngineerCategory(ArrayList persons)
        {
            Console.Clear();
            if (persons != null)
            {
                int maxCategory = -1;
                foreach (Persona persona in persons)
                {
                    if (persona is Engineer)
                    {
                        if (maxCategory < ((Engineer)persona).Category)
                        {
                            maxCategory = ((Engineer)persona).Category;
                        }
                    }
                }


                if (maxCategory == -1)
                {
                    Console.WriteLine("Инженеров нет");
                    Console.ReadKey();
                    return 0;
                }
                else
                {
                    Console.WriteLine($"Мaксимальная категория: {maxCategory}");
                    Console.ReadKey();
                    return maxCategory;
                }
            }
            else
            {
                Console.WriteLine("Пустой массив");
                Console.ReadKey();
                return 0;
            }
        }


        ArrayList SortArrayList(ArrayList persons)
        {
            Console.Clear();
            persons.Sort();
            ShowArray(persons);
            Console.ReadKey();
            return persons;
        }


        ArrayList CloneArrayList(ArrayList persons)
        {
            Console.Clear();
            ArrayList personsClone = (ArrayList)persons.Clone();
            ShowArray(persons);
            Console.ReadKey();
            return personsClone;
        }


        void FindElementArrayList(ArrayList persons)
        {
            Console.Clear();
            if (persons.Count != 0)
            {
                Console.WriteLine("Введите имя персоны, которую хотите найти");
                string name = Console.ReadLine();
                foreach (Persona persona in persons)
                {
                    if (persona.FirstName == name)
                    {
                        Console.WriteLine(persona);
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Пустой массив");
                Console.ReadKey();
            }
        }


        public void PointMenu()
        {
            int point = ShowMenu("Создать колекцию ArrayList",
                "Удалить элемент из ArrayList",
                "Добавить элемент в ArrayList",
                "Показать женщин",
                "Показать количество инженеров",
                "Показать максимальную категорию инженеров",
                "Клонирование ArrayLine",
                "Сортировка ArrayList",
                "Поиск по имени",
                "Выход");

            switch (point)
            {
                case 1:
                    personsList = CreateRandomArrayList();
                    break;
                case 2:
                    personsList=DelPerson(personsList);
                    break;
                case 3:
                    personsList=AddRandomPerson(personsList);
                    break;
                case 4:
                    NamesWoman(personsList);
                    break;
                case 5:
                    CountEngineer(personsList);
                    break;
                case 6:
                    MaxEngineerCategory(personsList);
                    break;
                case 7:
                    CloneArrayList(personsList);
                    break;
                case 8:
                    SortArrayList(personsList);
                    break;
                case 9:
                    FindElementArrayList(personsList);
                    break;
                case 10:
                    Exit = false;
                    break;
            }
        }
    }
}
