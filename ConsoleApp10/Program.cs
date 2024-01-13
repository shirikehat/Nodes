using System.Globalization;

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
        public static bool IsExists<T>(Node<T> list, T value)
        {
            while (list != null)
            {
                if (list.GetValue().Equals(value))
                    return true;
                list = list.GetNext();
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
        public static Node<int> NoDouble(Node<int> lst)
        {
            Node<int> head = new Node<int>(lst.GetValue());
            Node<int> tail= head;  
            
            while (lst != null && lst.HasNext())
            {
                if(lst.GetNext().GetValue() == lst.GetValue())
                {
                    
                    tail.SetNext(new Node<int>(lst.GetNext().GetNext().GetValue()));
                    tail=tail.GetNext();
                    
                }
                lst=lst.GetNext();
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

        public static void AddToMiddle(Node<int> lst, int val)
        {
            Node<int> newNode = new Node<int>(val);
            while (lst.HasNext() && lst.GetNext().GetValue() < newNode.GetValue())
            {
                lst = lst.GetNext();
            }
            newNode.SetNext(lst.GetNext());
            lst.SetNext(newNode);
        }

        

        public static Node<int> Merge(Node<int> lst1, Node<int> lst2)
        {
            Node<int> comb = new Node<int>(lst1.GetValue());
            lst1 = lst1.GetNext();
            Node<int> tail = comb;
            while (lst1 != null && lst2!=null)
            {
                tail.SetNext(new Node<int>(lst2.GetValue()));
                tail= tail.GetNext();

                tail.SetNext(new Node<int>(lst1.GetValue()));
                tail = tail.GetNext();


                lst1 =lst1.GetNext();
                lst2 = lst2.GetNext(); 
            }
            while(lst1 != null)
            {
                tail.SetNext(new Node<int>(lst1.GetValue())); 
                tail= tail.GetNext();
                lst1 = lst1.GetNext();
            }
            while (lst2 != null)
            {
                tail.SetNext(new Node<int>(lst2.GetValue()));
                tail = tail.GetNext();
                lst2 = lst2.GetNext();
            }
            return comb;
        }


        public static int CountList<T>(Node<T> head)
        {
            int counter = 0;
            while (head != null)
            {
                counter++;
                head = head.GetNext();//i++
            }
            return counter;
        }


        //עושה ממוצע לכל הערכים בשרשרת
        public static double Average(Node<int> lst)
        {
            double count = 0;
            double counter = 0;
            while (lst != null)
            {
                count += lst.GetValue();
                counter++;  
                lst = lst.GetNext();
            }
            return count/counter;
        }


        //אם מספר הערכים שגדולים מהממוצע, שווה למספר הערכים שקטן מהממוצע, הרשימה מאוזנת והפעולה תחזיר true 
        public static bool IsMeozan(Node<int> lst)
        {
            int countBigger = 0;
            int countSmaller = 0;
            while (lst != null)
            {
                if(lst.GetValue() > Average(lst)) { countBigger++; }
                else { countSmaller++; }
                lst = lst.GetNext();
            }
            return countBigger==countSmaller;
        }

        public static Node<T> Deletevlue<T>(Node<T> lst, T value)
        {
            Node<T> head = lst;
            if (lst == null)
                return head;

            if (lst.GetValue().Equals(value))
            {
                head = lst.GetNext();
                lst.SetNext(null);
                return head;
            }
            Node<T> next = lst.GetNext();
            while (lst.HasNext() && !next.GetValue().Equals(value))
            {
                lst = next;
                next = lst.GetNext();
            }
            lst.SetNext(next.GetNext());
            next.SetNext(null);

            return head;
        }


        public static int FindMax(Node<int> lst)
        {
            int max = int.MinValue;
            while (lst != null)
            {
                if (lst.GetValue() > max)
                {
                    max = lst.GetValue();
                    lst = lst.GetNext();
                }

            }
            return max;
        }

        public static void DeleteBiggest(Node<int> lst)
        {
            int max = 0;
            while(lst != null)
            {
                max = FindMax(lst);
                Deletevlue(lst, max);
                lst = lst.GetNext();
            }
        }

        //פעולה שמוחקת מהרשימה את
        //n
        //האיברים הגדולים ביותר
        public static void DeleteBiggerN(Node<int> lst, int n)
        {
            for(int i=0; i<n; i++)
            {
                DeleteBiggest(lst);
            }
        }
        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(7, new Node<int>(8))));
            Node<int> lst2 = new Node<int>(3, new Node<int>(4, new Node<int>(5, new Node<int>(6))));
            DeleteBiggerN(lst2, 2);
            Console.WriteLine(lst2);
        }
    }
}