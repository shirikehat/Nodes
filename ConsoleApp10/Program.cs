namespace ConsoleApp10
{
    internal class Program
    {
        //פעולה המקבלת מצביע לחוליה 
        //מחזירה אמת אם החוליות מסודרות בסדר עולה
        //ושקר אחרת
        //אורך הקלט n: מספר הקרונות שיש
        //המקרה הגרוע: שהחוליות מסודרות בסדר עולה
        //n הפעולה מתבצעת פעם 1 ובכל סיבוב הלולאה מתבצעות
        // פעמים
        //מכאן שסיבוכיות הפעולה: n


        //אורך הקלט n: כמות החוליות
        //המקרה הגרוע: שהחוליות בסדר עולה
        //הפעולה מבצעת n  קריאות ובכל קריאה הלולאה מתבצעות1  מכאן שסיבוכיות הפעולה: n

        //כמו קודם רק מימוש רקורסיבי
        public static bool IsAscendingRecursive(Node<int> lst)
        {
            if (lst == null) return true;
            if (lst.HasNext())
            {
                if (lst.GetValue() > lst.GetNext().GetValue()) return false;
            }

            return IsAscendingRecursive(lst.GetNext());
        }

        //פעולה גנרית המחזירה אמת אם 
        //x 
        //קיים בשרשרת החוליות 
        //lst
        //ושקר אחרת
        //שימו לב שבפעולה גנרית אין 
        //לא ניתן להשתמש ב
        //==
        //יש להתשמש בפעולה של
        //object
        //Equals

        //אורך הקלט n: כמות החוליות
        //המקרה הגרוע: שאין איקס בחוליות
        //הפעולה מתבצעת פעם 1 ובכל סיבוב הלולאה מתבצעות n מכאן שסיבוכיות הפעולה: n
        public static bool IsExists<T>(Node<T> lst, T x)
        {
            while (lst.HasNext())
            {
                if (lst.GetValue().Equals(x))
                {
                    return true;
                }
                else
                {
                    lst = lst.GetNext();
                }
            }
            return false;
        }
        //אורך הקלט n: כמות החוליות
        //המקרה הגרוע: שאין איקס בחוליות
        //הפעולה מבצעת n  קריאות ובכל קריאה הלולאה מתבצעות 1 מכאן שסיבוכיות הפעולה: n

        public static bool IsExistsRecursive<T>(Node<T> lst, T x)
        {
            if (lst == null) return false;
            if (lst.GetValue().Equals(x)) return true;
            return IsExistsRecursive<T>(lst.GetNext(), x);
        }

        //שאלה 2
        public static int RezefCount(Node<int> lst, int x)
        {
            int counter = 0;
            while (lst != null && lst.HasNext())
            {
                while (lst != null && lst.GetValue() == x)
                {
                    if (lst.HasNext() && lst.GetNext().GetValue() != x)
                    {
                        counter++;
                    }
                    lst = lst.GetNext();
                }

                lst = lst.GetNext();
            }
            if (lst.GetValue() == x)
                return counter + 1;
            return counter;
        }


        //שאלה 4
        public static string HowManyZoogi(Node<int> lst)
        {
            int countZogi = 0;
            int countNotZogi = 0;
            while (lst != null && lst.HasNext())
            {
                if (lst.GetValue() % 2 == 0) countZogi++;
                else countNotZogi++;
                lst = lst.GetNext();
            }
            if (countZogi > countNotZogi) return "z";
            if (countZogi < countNotZogi) return "e";
            return "s";
        }


        //שאלה 6
        public static Node<int> NewLst(Node<int> lst)
        {
            Node<int> head = new Node<int>(lst.GetValue());
            lst = lst.GetNext();
            while (lst != null && lst.HasNext())
            {
                if (IsExists(lst, lst.GetValue()) && !IsExists(lst.GetNext(), lst.GetValue()))
                    head.SetNext(lst.GetNext());
                lst = lst.GetNext();
            }
            return head;
        }


        //שאלה 8
        public static bool IsAscending(Node<int> lst)
        {
            while (lst.HasNext())
            {
                if (lst.GetValue() < lst.GetNext().GetValue())
                {
                    lst = lst.GetNext();
                }
                else return false;
            }
            return true;
        }


        //שאלה 10
        public static Node<int> Creat(int beginner, int num)
        {
            Node<int> lst = new Node<int>(beginner);
            for (int i = beginner + 1; i < num; i++)
            {
                lst.GetNext().SetValue(i);
                lst = lst.GetNext();
            }
            return lst;
        }

        public static void AddToEnd<T>(Node<T> newNode, Node<T> lst)
        {
            while (lst.HasNext())
            {
                lst = lst.GetNext();
            }
            lst.SetNext(newNode);
        }

        public static void AddToMiddle<T>(Node<T> newNode, Node<T> lst)
        {
            while (lst.HasNext() && lst.GetNext().GetValue() < newNode.GetValue())
            {
                lst = lst.GetNext();
            }
            newNode.SetNext(lst.GetNext());
            lst.SetNext(newNode);
        }

        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null

            Console.WriteLine(IsAscending(lst1));//should print True
            Console.WriteLine(IsAscendingRecursive(lst1));//should print True
            Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(2))));//[4, next]=>[5, next]=>[6, next]=>[2, next]=>null
            Console.WriteLine(IsAscending(lst2));//should print False
            Console.WriteLine(IsAscendingRecursive(lst2));//should print False
            Node<int> lst3 = new Node<int>(4, new Node<int>(5, new Node<int>(4, new Node<int>(9))));//[4, next]=>[5, next]=>[4, next]=>[9, next]=>null
            Console.WriteLine(IsAscending(lst3));//should print False
            Console.WriteLine(IsAscendingRecursive(lst3));//should print False

            Node<char> lst4 = new Node<char>('t', new Node<char>('A', new Node<char>('l', new Node<char>('s', new Node<char>('i')))));//['t', next]=>['a', next]=>['l', next]=>['s', next]=>['i', next]=>null
            Console.WriteLine(IsExists(lst1, 5));//should print True
            Console.WriteLine(IsExists(lst4, 'i'));//should print True
            Console.WriteLine(IsExists(lst4, 'I'));//should print False
            Console.WriteLine(IsExistsRecursive(lst1, 5));//should print True
            Console.WriteLine(IsExistsRecursive(lst4, 'i'));//should print True
            Console.WriteLine(IsExistsRecursive(lst4, 'I'));//should print False 
        }
    }
}