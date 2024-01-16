using System.Globalization;
using System.Linq.Expressions;

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

        //סופרת כמה רצפים יש לערך בשרשרת
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


        //מוחקת כפילויות מהשרשרת היא לא עובדת בנתייםםםםם
        public static Node<int> NoDouble(Node<int> lst)
        {
            Node<int> head = new Node<int>(lst.GetValue());
            Node<int> tail = head;

            while (lst != null && lst.HasNext())
            {
                if (lst.GetNext().GetValue() == lst.GetValue())
                {

                    tail.SetNext(new Node<int>(lst.GetNext().GetNext().GetValue()));
                    tail = tail.GetNext();

                }
                lst = lst.GetNext();
            }
            return head;
        }


        //בודקת אם השרשרת מסודרת בסדר עולה 
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


        //יוצרת שרשרת חדשה עם נאמ חוליות, שמתחילה במספר בגינר וממשיכה בסדר עולה
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


        //מוסיפה חולייה לסוף שרשרת
        public static void AddToEnd<T>(Node<T> newNode, Node<T> lst)
        {
            while (lst.HasNext())
            {
                lst = lst.GetNext();
            }
            lst.SetNext(newNode);
        }


        //מוסיפה חוליה לאמצע שרשרת
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



        //ממזגת שתי שרשראות
        public static Node<int> Merge(Node<int> lst1, Node<int> lst2)
        {
            Node<int> comb = new Node<int>(lst1.GetValue());
            lst1 = lst1.GetNext();
            Node<int> tail = comb;
            while (lst1 != null && lst2 != null)
            {
                tail.SetNext(new Node<int>(lst2.GetValue()));
                tail = tail.GetNext();

                tail.SetNext(new Node<int>(lst1.GetValue()));
                tail = tail.GetNext();


                lst1 = lst1.GetNext();
                lst2 = lst2.GetNext();
            }
            while (lst1 != null)
            {
                tail.SetNext(new Node<int>(lst1.GetValue()));
                tail = tail.GetNext();
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


        //סופרת כמה חוליות יש בשרשרת
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
            return count / counter;
        }


        //אם מספר הערכים שגדולים מהממוצע, שווה למספר הערכים שקטן מהממוצע, הרשימה מאוזנת והפעולה תחזיר true 
        public static bool IsMeozan(Node<int> lst)
        {
            int countBigger = 0;
            int countSmaller = 0;
            while (lst != null)
            {
                if (lst.GetValue() > Average(lst)) { countBigger++; }
                else { countSmaller++; }
                lst = lst.GetNext();
            }
            return countBigger == countSmaller;
        }


        //מוחקת חולייה לפי הערך
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


        //מוצאת את הערך הכי גדול בשרשרת
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


        //מוחקת את החולייה עם הערך הכי גדול בשרשרת
        public static void DeleteBiggest(Node<int> lst)
        {
            int max = 0;
            while (lst != null)
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
            for (int i = 0; i < n; i++)
            {
                DeleteBiggest(lst);
            }
        }


        //הסכום של כל הערכים בשרשרת
        public static int CountVals(Node<int> lst)
        {
            int counter = 0;
            Node<int> head = lst;
            while (head != null)
            {
                counter += head.GetValue();
                head = head.GetNext();
            }
            return counter;
        }


        //כ שרשרת מייצגת מספר שכל חולייה בה היא ספרהת הפעולה תבדוק איזה רשימה מייצגת מספר גדול יותר תחזיר 1 אם זה 1, 2 אם זה 2, 0 אם הן שוות
        public static int WhoBigger(Node<int> lst1, Node<int> lst2)
        {
            if (CountList(lst1) > CountList(lst2)) return 1;
            else if (CountList(lst1) < CountList(lst2)) return 2;

            while (lst1 != null && lst2 != null)
            {
                if (lst1.GetValue() > lst2.GetValue()) return 1;
                else if (lst1.GetValue() < lst2.GetValue()) return 2;
                lst1 = lst1.GetNext();
                lst2 = lst2.GetNext();
            }
            return 0;
        }



        //השרשרת השנייה מוכלת בתוך הראשונה, הפעולה תמחוק מהראשונה את השרשרת השנייה (ותשאיר את השנייה כמו שהיא)
        public static Node<int> TakePart(Node<int> lst1, Node<int> lst2)
        {
            Node<int> prv = lst1;
            Node<int> nxt = lst2;
            Node<int> tail = lst2;

            while (tail.HasNext())
            {
                tail = tail.GetNext();
            }

            while (prv != null)
            {
                while (prv == nxt)
                {
                    prv = prv.GetNext();
                    nxt = nxt.GetNext();
                }
                prv = lst1;
                nxt = lst2;

                prv = prv.GetNext();
            }
            return lst1;
        }





        //הפעולה תהפוך את השרשרת
        public static Node<int> Reverse(Node<int> lst)
        {
            Node<int> prev = lst;
            Node<int> curr = lst.GetNext();
            Node<int> temp = lst;

            prev.SetNext(null);

            while (curr != null)
            {
                temp = curr.GetNext();
                curr.SetNext(prev);
                prev = curr;
                curr = temp;
            }

            lst = prev;
            return lst;
        }


        //פעולה שיוצרת שרשרת חדשה, כל חולייה בה היא ספרה מהסכום של שתי השרשראות שהיא מקבלת
        public static Node<int> Sum(Node<int> lst1, Node<int> lst2)
        {
            int sum = CountVals(lst1) + CountVals(lst2);
            Node<int> head = new Node<int>(sum % 10, lst2);
            Node<int> tail = head;
            sum = sum / 10;
            while (tail.HasNext())
            {
                tail.SetNext(new Node<int>(sum % 10));
                tail = tail.GetNext();
                sum = sum / 10;
            }
            
            return Reverse(head);
        }


        //יוצרת רשימה חדשה עם ערכים רנדומליים
        public static Node<int> RandomList(int Length, int start, int end)
        {
            Random rnd= new Random();
            Node<int> head= new Node<int>(rnd.Next(start, end+1));
            Node<int> lst = head;
            for(int i=0; i<Length-1; i++)
            {
                lst.SetNext(new Node<int>(rnd.Next(start, end+1)));
                lst=lst.GetNext();
            }
            return head;
        }


        public static Node<int> CompList(Node<int> lst)
        {
            Node<int> head = lst;
            Node<int> nxt = lst.GetNext();
            while(lst!=null)
            {
                lst.SetNext(new Node<int>(nxt.GetValue()-lst.GetValue()));
                lst=lst.GetNext();
                head.SetNext(nxt);
                
                lst= lst.GetNext();
                nxt=nxt.GetNext();
            }
            return head;
        }

        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7, new Node<int>(7, new Node<int>(8))))));
            Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6)));

            Console.WriteLine(lst1);
            Console.WriteLine(CompList(lst1));
        }
    }
}