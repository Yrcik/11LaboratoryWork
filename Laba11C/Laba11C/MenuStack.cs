using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Laba10_1;

namespace Laba11C
{
    class MenuStack<T> where T : Persona, new() 
    {
        Stopwatch stopWatch = new Stopwatch();

        TestCollections<Persona, Worker> collections = new TestCollections<Persona, Worker>();

        static Stack<T> personsStack = new Stack<T>();

        Random random = new Random();

        public bool Exit = true;

        int CheckEnterNumber()
        {
            while (true)
            {
                try
                {
                    int Number = int.Parse(Console.ReadLine());
                    if (Number > 0)
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


        void Show(Stack<T> personsStack)
        {
            int count = 0;
            foreach (T persona in personsStack)
            {
                count++;
                Console.WriteLine($"{count}. {persona}\n");
            }
        }


        Stack<T> Add(Stack<T> stack, T item)
        {
            stack.Push(item);
            return stack;
        }


        Stack<T> CreateRandomStack(Stack<T> personsStack)
        {
            Console.Clear();
            personsStack.Clear();
            for (int i = 0; i < random.Next(3, 8); i++)
            {
                switch (random.Next(1, 5))
                {
                    case 1:
                        Persona persona = new Persona();
                        persona.Init();
                        personsStack.Push((T)persona);

                        break;
                    case 2:
                        Persona clerk = new Clerk();
                        clerk.Init();
                        personsStack.Push((T)clerk);
                        break;
                    case 3:
                        Persona engineer = new Engineer();
                        engineer.Init();
                        personsStack.Push((T)engineer);
                        break;
                    case 4:
                        Persona worker = new Worker();
                        worker.Init();
                        personsStack.Push((T)worker);
                        break;
                }
            }

            Show(personsStack);
            Console.ReadKey();
            return personsStack;
        }


        Stack<T> AddRandomPerson(Stack<T> personsStack)
        {
            Console.Clear();

            switch (random.Next(1, 5))
            {
                case 1:
                    Persona persona = new Persona();
                    persona.Init();
                    personsStack.Push((T)persona);
                    break;
                case 2:
                    Persona clerk = new Clerk();
                    clerk.Init();
                    personsStack.Push((T)clerk);
                    break;
                case 3:
                    Persona engineer = new Engineer();
                    engineer.Init();
                    personsStack.Push((T)engineer);
                    break;
                case 4:
                    Persona worker = new Worker();
                    worker.Init();
                    personsStack.Push((T)worker);
                    break;
            }

            Show(personsStack);
            Console.ReadKey();
            return personsStack;
        }


        Stack<T> DelPerson(Stack<T> personsStack)
        {
            if (personsStack.Count != 0)
            {
                Console.Clear();
                Show(personsStack);
                Console.WriteLine("Удален верхний элемент стэка");
                try
                {
                    personsStack.Pop();
                }
                catch
                {
                    Console.WriteLine("Данного индекса несуществует");
                }

                Show(personsStack);
                Console.ReadKey();
                return personsStack;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Пустой массив");
                Console.ReadKey();
                Stack<T> personsList = new Stack<T>();
                return personsList;
            }
        }


        void NamesWoman(Stack<T> personsStack)
        {
            Console.Clear();
            if (personsStack.Count != 0)
            {
                ArrayList namesWoman = new ArrayList();
                ArrayList nameWomanList = new ArrayList();
                int count = 0;
                foreach (Persona persona in personsStack)
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


        int CountEngineer(Stack<T> personsStack)
        {
            Console.Clear();
            if (personsStack != null)
            {
                int count = 0;
                foreach (T persona in personsStack)
                {
                    if (persona is Engineer)
                    {
                        if (persona.FirstName != "Нет имени")
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


        int MaxEngineerCategory(Stack<T> personsStack)
        {
            Console.Clear();
            if (personsStack != null)
            {
                int maxCategory = -1;
                foreach (Persona persona in personsStack)
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


        Stack<T> SortArrayList(Stack<T> personsStack)
        {
            Console.Clear();
            T[] persons = personsStack.ToArray();
            Array.Sort(persons);
            foreach (T persona in persons)
            {
                personsStack.Push(persona);
            }
            Show(personsStack);
            Console.ReadKey();
            return personsStack;
        }


        Stack<T> CloneArrayList(Stack<T> personsStack)
        {
            Console.Clear();
            Stack<T> stackClone = new Stack<T>();
            foreach (T persona in personsStack)
            {
                Persona clone =new Persona(persona.FirstName,persona.LastName,persona.Gender,persona.Age);
                stackClone.Push((T)clone);
            }
            Show(stackClone);
            Console.ReadKey();
            return stackClone;
        }


        void FindElementArrayList(Stack<T> personsStack)
        {
            Console.Clear();
            if (personsStack.Count != 0)
            {
                Console.WriteLine("Введите имя персоны, которую хотите найти");
                string name = Console.ReadLine();
                foreach (Persona persona in personsStack)
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


        TestCollections<Persona, Worker> CreateCollection()
        {
            TestCollections<Persona, Worker> collections = new TestCollections<Persona, Worker>();
            return collections;
        }


        TestCollections<Persona, Worker> AddElementCollections(TestCollections<Persona, Worker> collections)
        {

            Worker worker = new Worker();
            worker.Init();
            Persona persona = worker.BasePerson;
            collections.LinkedList1.AddLast(worker);
            collections.LinkedList2.AddLast(worker.ToString());
            collections.SortedDictionary1[persona] = worker;
            collections.SortedDictionary2[persona.ToString()] = worker;
            return collections;
        }


        TestCollections<Persona, Worker> DelFirstElementCollections(TestCollections<Persona, Worker> collections)
        {
            collections.LinkedList1.RemoveFirst();
            collections.LinkedList2.RemoveFirst();
            Console.WriteLine("Введите ключ, который хотите удалить");
            foreach (Persona persona in collections.SortedDictionary1.Keys)
            {
                collections.SortedDictionary1.Remove(persona);
                break;
            }
            foreach (string persona in collections.SortedDictionary2.Keys)
            {
                collections.SortedDictionary2.Remove(persona);
                break;
            }
            return collections;
        }


        void FindElenent(TestCollections<Persona, Worker> collections)
        {
            Console.Clear();
            bool ok;
            int i = 0;
            Worker noneWorker = new Worker();

            foreach (Persona worker in collections.LinkedList1)
            {
                if (i == 0)
                {
                    Worker workerr = (Worker)worker;
                    Worker findWorker = new Worker(workerr.FirstName, workerr.LastName, workerr.Gender, workerr.Age, workerr.Experience);
                    stopWatch.Start();
                    ok=collections.LinkedList1.Contains(findWorker);
                    stopWatch.Stop();
                    Console.WriteLine($"Первый элемент LinkedList<Worker>: {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }

                if (i == collections.LinkedList1.Count / 2)
                {
                    Worker workerr = (Worker)worker;
                    Worker findWorker = new Worker(workerr.FirstName, workerr.LastName, workerr.Gender, workerr.Age, workerr.Experience);
                    stopWatch.Start();
                    ok = collections.LinkedList1.Contains(findWorker);
                    stopWatch.Stop();
                    Console.WriteLine($"Серединный элемент LinkedList<Worker>: {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }

                if(i== collections.LinkedList1.Count-1)
                {
                    Worker workerr = (Worker)worker;
                    Worker findWorker = new Worker(workerr.FirstName, workerr.LastName, workerr.Gender, workerr.Age, workerr.Experience);
                    stopWatch.Start();
                    ok = collections.LinkedList1.Contains(findWorker);
                    stopWatch.Stop();
                    Console.WriteLine($"Последний элемент LinkedList<Worker>: {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }
                i++;
            }

            stopWatch.Start();
            ok = collections.LinkedList1.Contains(noneWorker);
            stopWatch.Stop();
            Console.WriteLine($"Несуществующий элемент LinkedList<Worker>: {stopWatch.ElapsedTicks}  {ok}");
            stopWatch.Reset();

            i = 0;

            foreach (string worker in collections.LinkedList2)
            {
                if (i == 0)
                {
                    stopWatch.Start();
                    ok = collections.LinkedList2.Contains(worker.ToString());
                    stopWatch.Stop();
                    Console.WriteLine($"\nПервый элемент LinkedList<string>: {stopWatch.ElapsedTicks}  {ok}");
                    stopWatch.Reset();
                }

                if (i == collections.LinkedList2.Count / 2)
                {
                    stopWatch.Start();
                    ok = collections.LinkedList2.Contains(worker.ToString());
                    stopWatch.Stop();
                    Console.WriteLine($"Серединный элемент LinkedList<string>: {stopWatch.ElapsedTicks}  {ok}");
                    stopWatch.Reset();
                }

                if (i == collections.LinkedList2.Count-1)
                {
                    stopWatch.Start();
                    ok = collections.LinkedList2.Contains(worker.ToString());
                    stopWatch.Stop();
                    Console.WriteLine($"Последний элемент LinkedList<string>: {stopWatch.ElapsedTicks}  {ok}");
                    stopWatch.Reset();
                }

                i++;
            }

            stopWatch.Start();
            ok = collections.LinkedList2.Contains(noneWorker.ToString());
            stopWatch.Stop();
            Console.WriteLine($"Несуществующий элемент LinkedList<string>: {stopWatch.ElapsedTicks}  {ok}");
            stopWatch.Reset();

            i = 0;

            foreach (Persona worker in collections.SortedDictionary1.Values)
            {
                if (i == 0)
                {
                    Worker workerr = (Worker)worker;
                    Persona findWorker = new Persona(worker.FirstName, worker.LastName, worker.Gender, worker.Age);
                    stopWatch.Start();
                    ok = collections.SortedDictionary1.ContainsKey(findWorker);
                    stopWatch.Stop();
                    Console.WriteLine($"\nПервый элемент SortedDictionary<Persona,Worker> (по ключю): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                    stopWatch.Start();
                    ok = collections.SortedDictionary1.ContainsValue(workerr);
                    stopWatch.Stop();
                    Console.WriteLine($"Первый элемент SortedDictionary<Persona,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }

                if (i == collections.SortedDictionary1.Count / 2)
                {
                    Worker workerr = (Worker)worker;
                    Persona findWorker = new Persona(worker.FirstName, worker.LastName, worker.Gender, worker.Age);
                    stopWatch.Start();
                    ok = collections.SortedDictionary1.ContainsKey(findWorker);
                    stopWatch.Stop();
                    Console.WriteLine($"Серединный элемент SortedDictionary<Persona,Worker> (по ключю): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                    stopWatch.Start();
                    ok = collections.SortedDictionary1.ContainsValue(workerr);
                    stopWatch.Stop();
                    Console.WriteLine($"Серединный элемент SortedDictionary<Persona,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }

                if (i == collections.SortedDictionary1.Count-1)
                {
                    Worker workerr = (Worker)worker;
                    Persona findWorker = new Persona(worker.FirstName, worker.LastName, worker.Gender, worker.Age);
                    stopWatch.Start();
                    ok = collections.SortedDictionary1.ContainsKey(findWorker);
                    stopWatch.Stop();
                    Console.WriteLine($"Последний элемент SortedDictionary<Persona,Worker> (по ключю): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                    stopWatch.Start();
                    ok = collections.SortedDictionary1.ContainsValue(workerr);
                    stopWatch.Stop();
                    Console.WriteLine($"Последний элемент SortedDictionary<Persona,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }
                i++;
            }

            stopWatch.Start();
            ok = collections.SortedDictionary1.ContainsKey((Persona)noneWorker);
            stopWatch.Stop();
            Console.WriteLine($"Несуществующий элемент SortedDictionary<Persona,Worker> (по ключю): {stopWatch.ElapsedTicks} {ok}");
            stopWatch.Reset();
            stopWatch.Start();
            ok = collections.SortedDictionary1.ContainsValue(noneWorker);
            stopWatch.Stop();
            Console.WriteLine($"Несуществующий SortedDictionary<Persona,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
            stopWatch.Reset();
            i = 0;

            foreach (string worker in collections.SortedDictionary2.Keys)
            {
                if (i == 0)
                {
                    stopWatch.Start();
                    ok = collections.SortedDictionary2.ContainsKey(worker.ToString());
                    stopWatch.Stop();
                    Console.WriteLine($"\nПервый элемент SortedDictionary<string,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }    

                if (i == collections.SortedDictionary2.Count / 2)
                {
                    stopWatch.Start();
                    ok = collections.SortedDictionary2.ContainsKey(worker.ToString());
                    stopWatch.Stop();
                    Console.WriteLine($"Серединный элемент SortedDictionary<string,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }

                if (i == collections.SortedDictionary2.Count-1)
                {
                    stopWatch.Start();
                    ok = collections.SortedDictionary2.ContainsKey(worker.ToString());
                    stopWatch.Stop();
                    Console.WriteLine($"Последний элемент SortedDictionary<string,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
                    stopWatch.Reset();
                }

                i++;
            }

           
            stopWatch.Start();
            ok = collections.SortedDictionary2.ContainsKey(noneWorker.ToString());
            stopWatch.Stop();
            Console.WriteLine($"Несуществуюний элемент SortedDictionary<string,Worker> (по значению): {stopWatch.ElapsedTicks} {ok}");
            stopWatch.Reset();
            Console.ReadKey();
        }



        public void PointMenu()
        {
            int point = ShowMenu("1. Создать колекцию Stack",
                "2. Удалить элемент из Stack",
                "3. Добавить элемент в Stack",
                "4. Показать женщин",
                "5. Показать количество инженеров",
                "6. Показать максимальную категорию инженеров",
                "7. Клонирование Stack",
                "8. Сортировка Stack",
                "9. Поиск по имени",
                "10. Создание TestCollections",
                "11. Удаление элемента в TestCollections",
                "12. Добавление элемента в TestCollections",
                "13. Поиск элементов",
                "14. Выход");

            switch (point)
            {
                case 1:
                    personsStack = CreateRandomStack(personsStack);
                    break;
                case 2:
                    personsStack = DelPerson(personsStack);
                    break;
                case 3:
                    personsStack = AddRandomPerson(personsStack);
                    break;
                case 4:
                    NamesWoman(personsStack);
                    break;
                case 5:
                    CountEngineer(personsStack);
                    break;
                case 6:
                    MaxEngineerCategory(personsStack);
                    break;
                case 7:
                    CloneArrayList(personsStack);
                    break;
                case 8:
                    SortArrayList(personsStack);
                    break;
                case 9:
                    FindElementArrayList(personsStack);
                    break;
                case 10:
                    collections = CreateCollection();
                    break;
                case 11:
                    collections = DelFirstElementCollections(collections);
                    break;
                case 12:
                    collections = AddElementCollections(collections);
                    break;
                case 13:
                    FindElenent(collections);
                    break;
                case 14:
                    Exit = false;
                    break;
            }

        }
          
    }
}
