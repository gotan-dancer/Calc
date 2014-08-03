using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Operation
    {
        private int operand1;
        private int operand2;
        private string operator_;

        public Operation()
        { 
        }

        ~Operation()
        {             
        }

        public Operation(int operand1, int operand2, string operator_)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operator_ = operator_;
        }

        public bool SetOperation(string words)
        {
            // Разбиение строки на элементы
            string[] split = words.Split(new Char[] { ' ' });

            int memberCount = 0;

            bool[] memberCheck = { false, false, false, false };

            // Обработка строки
            foreach (string s in split)
            {
                memberCount++;

                // Первый операнд
                if (memberCount == 1)
                {
                    bool isDigit = true;

                    foreach (char c in s)
                    {
                        if (!(Char.IsDigit(c)))
                        {
                            isDigit = false;
                            break;
                        }
                    }

                    if (isDigit)
                    {
                        this.operand1 = (int)Convert.ChangeType(s, typeof(int));
                        Console.WriteLine("Операнд1 - " + this.operand1);
                        memberCheck[memberCount - 1] = true;
                    }
                    else
                    {
                        Console.WriteLine("Операнд1 - не целое число");
                        memberCheck[memberCount - 1] = false;
                    }
                }

                // Знак операции
                if (memberCount == 2)
                {
                    if (s == "*" || s == "/" || s == "+" || s == "-")
                    {
                        this.operator_ = s;
                        Console.WriteLine("Операция - " + s);
                        memberCheck[memberCount - 1] = true;
                    }
                    else
                    {
                        Console.WriteLine("Не операция!");
                        memberCheck[memberCount - 1] = false;
                    }
                }

                // Второй операнд
                if (memberCount == 3)
                {
                    bool isDigit = true;

                    foreach (char c in s)
                    {
                        if (!(Char.IsDigit(c)))
                        {
                            isDigit = false;
                            break;
                        }
                    }

                    if (isDigit)
                    {
                        this.operand2 = (int)Convert.ChangeType(s, typeof(int));
                        Console.WriteLine("Операнд2 - " + this.operand2);
                        memberCheck[memberCount - 1] = true;
                    }
                    else
                    {
                        Console.WriteLine("Операнд2 - не целое число");
                        memberCheck[memberCount - 1] = false;
                    }
                }

                // Знак равенства
                if (memberCount == 4)
                {
                    if (s == "=")
                    {
                        Console.WriteLine("Операция завершена знаком равенства");
                        memberCheck[memberCount - 1] = true;
                    }
                    else
                    {
                        Console.WriteLine("Операция не завершена знаком равенства");
                        memberCheck[memberCount - 1] = false;
                    }
                }

                // Количество элементов - больше нужного
                if (memberCount >= 5)
                {
                    Console.WriteLine("Количество элементов более 4");
                    return false;
                }
            }

            // Возврат разбора строки
            // Истина - в случае, если строка разобрана нормально
            // Ложь - что-то пошло не так
            return memberCheck[0] && memberCheck[1] && memberCheck[2] && memberCheck[3];
        }

        public void SetOperand1(int operand1)
        {
            this.operand1 = operand1;
        }

        public void SetOperand2(int operand2)
        {
            this.operand2 = operand2;
        }

        public void SetOperator(string operator_)
        {
            this.operator_ = operator_;
        }

        public void SetOperation(int operand1, int operand2, string operator_)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operator_ = operator_;
        }

        public int GetOperand1()
        {
            return operand1;
        }

        public int GetOperand2()
        {
            return operand2;
        }

        public string GetOperator()
        {
            return operator_;
        }

        public float GetOperation(int operand1, int operand2, string operator_)
        {
            if (operator_ == "+")
            {
                Console.WriteLine("Сложение");
                return (operand1 + operand2);
            }

            if (operator_ == "-")
            {
                Console.WriteLine("Вычитание");
                return (operand1 - operand2);
            }

            if (operator_ == "*")
            {
                Console.WriteLine("Умножение");
                return (operand1 * operand2);
            }

            if (operator_ == "/")
            {
                Console.WriteLine("Деление");
                if (operand2 == 0)
                {
                    Console.WriteLine("Делитель - нуль. На нуль делить нельзя!");
                    // Что возвращать в этом случае?
                    // Следующий return "проглатывает" деление на нуль
                }
                return ((float)operand1 / (float)operand2);
            }

            return 0;
           
        }

        public float GetOperation()
        {
            return GetOperation(this.operand1, this.operand2, this.operator_);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите арифметическое действие:");

            // Считывание  строки
            string words = Console.ReadLine();

            Operation operation = new Operation();
            
            // Разбор строки
            // Результаты разбора заносятся в класс Operation
            // resultCheck - успешность разбора строки
            bool resultCheck = operation.SetOperation(words);

            if (resultCheck)
            {
                Console.WriteLine("Пример составлен верно");
                // Нахождение результата
                float result = operation.GetOperation();
                Console.WriteLine(result.ToString());
            }
            else 
            {
                Console.WriteLine("Пример составлен неверно");
                Console.WriteLine("Решение невозможно");
            }

            Console.ReadLine();
        }
    }
}
