using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Lab_work_1
{
    class Notebook

    {

        List<Note> storage = new List<Note>();
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();

            Console.WriteLine(" Записная книга готова к работе! \n Что вы хотите сделать?");


            int num = 0;
            while (num != 6)

            {
                try
                {
                    Console.WriteLine(" Нажмите цифру, чтобы выполнить действие :\n   1 - Создание новой записи\n" +
                                                                                  "   2 - Редактирование ранее созданной записи \n" +
                                                                                  "   3 - Удаление ранее созданной записи \n" +
                                                                                  "   4 - Просмотр созданной записи\n" +
                                                                                  "   5 - Просмотр всех созданных записей в общем списке\n" +
                                                                                  "   6 - Выход");
                    num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("");
                            notebook.CreateNewNote();
                            Console.WriteLine("");
                            break;
                        case 2:
                            Console.WriteLine("");
                            notebook.EditNote();
                            Console.WriteLine("");
                            break;
                        case 3:
                            Console.WriteLine("");
                            notebook.DeleteNote();
                            Console.WriteLine("");
                            break;
                        case 4:
                            Console.WriteLine("");
                            notebook.ReadNote();
                            Console.WriteLine("");
                            break;
                        case 5:
                            Console.WriteLine("");
                            notebook.ShowAllNotes();
                            Console.WriteLine("");
                            break;
                        case 6:
                            num = 6;
                            break;
                        default:
                            Console.WriteLine(("Несуществующая цифра"));
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }





        public void CreateNewNote()  // Создание новой записи 
        {
            Console.WriteLine("Введите основную информацию ");
            Console.WriteLine("");
            Console.WriteLine("Введите имя");
            string firstname = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            string familyname = Console.ReadLine();
            Console.WriteLine("Введите номер телефона");
            ulong phonenumber = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine("Введите страну");
            string country = Console.ReadLine();

            Console.WriteLine("Хотите добавить дополнительную информацию? Y/N?");
            string yn = Console.ReadLine().ToLower();
            if (yn == "y")
            {
                Console.WriteLine("Введите отчество");
                string nMiddlename = Console.ReadLine();
                Console.WriteLine("Введите дату рождения, Пример ввода : 08.11.20");
                DateTime nBirthdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Введите место работы");
                string nThePlacework = Console.ReadLine();
                Console.WriteLine("Введите должность");
                string nPosition = Console.ReadLine();
                Console.WriteLine("Введите дополнительные заметки");
                string nOthernotes = Console.ReadLine();
                storage.Add(new Note(familyname, firstname, phonenumber, country)
                {
                    Middlename = nMiddlename,
                    Birthdate = nBirthdate,
                    ThePlacework = nThePlacework,
                    Position = nPosition,
                    Othernotes = nOthernotes
                });
                Console.WriteLine("Запись создана");

            }
            else
            {
                storage.Add(new Note(familyname, firstname, phonenumber, country));
                Console.WriteLine("Запись создана");
            }




        }
        public void EditNote() //  Редактирование ранее созданной записи
        {
            Console.WriteLine("Извините, данная функция в данном релизе недоступна");
        }

        public void DeleteNote() //Удаление ранее созданной записи
        {
            storage.RemoveAt(storage.Count - 1);
        }

        public void ReadNote()  // Просмотр созданной записи
        {
            Console.WriteLine(storage[storage.Count - 1]);
            /*Console.WriteLine($"Дата рождения: {storage[storage.Count - 1].Birthdate.ToString("dd.MM.yy")}\n" +
                $"Место работы: {storage[storage.Count - 1].ThePlacework}\n" +
                $"Должность: {storage[storage.Count-1].Position}\n" +
                $"Заметки: {storage[storage.Count - 1].Othernotes}");*/
            Console.WriteLine("");
        }

        public void ShowAllNotes() // Просмотр всех созданных записей в общем списке
        {
            foreach (var item in storage)
            {
                Console.WriteLine(item);
                Console.WriteLine("");
            }
        }


    }

    class Note
    {
        public string Firstname { get; set; }
        public string Familyname { get; set; }
        public string Middlename { get; set; }
        public ulong Phonenumber { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string ThePlacework { get; set; }
        public string Position { get; set; }
        public string Othernotes { get; set; }

        public Note(string firstname, string familyname, ulong phonenumber, string country)
        {
            Firstname = firstname;
            Familyname = familyname;
            Phonenumber = phonenumber;
            Country = country;
            Middlename = "Нет данных";
            Birthdate = DateTime.MinValue;
            ThePlacework = "Нет данных";
            Position = "Нет данных";
            Othernotes = "Нет данных";
        }

        public override string ToString()
        {
            return $"Имя: {Firstname}\n" +
                $"Фамилия: {Familyname}\n" +
                $"Номер: {Phonenumber}\n" +
                $"Страна: {Country}\n" +
                $"Отчество: { Middlename}\n" +
                 $"Дата Рождения: {Birthdate.ToString("dd.MM.yy")}\n" +
                 $"Место работы: {ThePlacework}\n" +
                 $"Должность: {Position}\n" +
                 $"Другие заметки: {Othernotes}";
        }
    }

}
