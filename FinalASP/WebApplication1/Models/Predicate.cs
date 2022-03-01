using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.Models
{
    public class Predicate
    {
        public int Id { get; set; }
        public UnaryOperator? OpA { get; set; }
        [DisplayName("Первый операнд")]
        [Required]
        public string OperandA { get; set; }
        public UnaryOperator? OpB { get; set; }
        [DisplayName("Второй операнд")]
        [Required]
        public string OperandB { get; set; }
        [DisplayName("Операция")]
        [Required]
        public BinaryOperator? Op { get; set; }

        public static bool CheckTheory(List<Predicate> predicates)
        {
            List<string> vars = (from p in predicates
                                select p.OperandA).ToList();
            vars.AddRange((from p in predicates
                           select p.OperandB).ToList());
            vars = vars.Distinct().ToList();
            int correctSets = 0;
            int n = (int)Math.Pow(2, vars.Count);
            for(int i = 0; i < n; i++)
            {
                string binary = IntToBinaryWithPadding(i, vars.Count);       
                bool f = true;
                foreach(Predicate p in predicates)
                {
                    bool x = binary[vars.IndexOf(p.OperandA)] == '1';
                    bool y = binary[vars.IndexOf(p.OperandB)] == '1';
                    f &= new Operation(p.OpA, x, p.OpB, y, p.Op.Value).Execute();
                }
                if(f)
                {
                    correctSets++;
                }
            }

            return correctSets != 0;
        }

        public static List<List<Predicate>> FindNotConflictingPredicates(List<Predicate> predicates)
        {
            if(CheckTheory(predicates))
            {
                return new List<List<Predicate>>() { predicates };
            }
            List<List<Predicate>> resolvedPredicates = new List<List<Predicate>>();
            for(int i = 0; i < predicates.Count; i++)
            {
                List<Predicate> predicatesCopy = new List<Predicate>(predicates);
                predicatesCopy.RemoveAt(i);
                List<List<Predicate>> result = FindNotConflictingPredicates(predicatesCopy);
                resolvedPredicates.AddRange(result);
            }
            return resolvedPredicates;
        }

        public static List<List<Predicate>> FindConflictingPredicates(List<Predicate> allPredicates)
        {
            List<List<Predicate>> predicates = Predicate.FindNotConflictingPredicates(allPredicates)
                    .Distinct(new ListComparer()).ToList();
            predicates = (from pList in predicates
                          orderby pList.Count descending
                          select pList).ToList();
            predicates = (from pList in predicates
                          where pList.Count == predicates.First().Count
                          select allPredicates.Except(pList).ToList()).ToList();
            return predicates;
        }
        public override string ToString()
        {
            return $"{OpA.GetNameToDisplay()}{OperandA} {Op.GetNameToDisplay()} {OpB.GetNameToDisplay()}{OperandB}";
        }

        private static string IntToBinaryWithPadding(int x, int length)
        {
            string binary = Convert.ToString(x, 2);
            StringBuilder stringBuilder = new StringBuilder();
            for (int j = 0; j < length - binary.Length; j++)
            {
                stringBuilder.Append("0");
            }
            return stringBuilder.ToString() + binary;
        }

        private class ListComparer : IEqualityComparer<List<Predicate>>
        {
            public bool Equals(List<Predicate> x, List<Predicate> y)
            {
                if (x.Count != y.Count)
                {
                    return false;
                }
                Dictionary<int, int> mapX = new Dictionary<int, int>();
                Dictionary<int, int> mapY = new Dictionary<int, int>();
                foreach (Predicate p in x)
                {
                    try
                    {
                        mapX[p.Id]++;
                    }
                    catch (Exception)
                    {
                        mapX[p.Id] = 1;
                    }
                }
                foreach (Predicate p in y)
                {
                    try
                    {
                        mapY[p.Id]++;
                    }
                    catch (Exception)
                    {
                        mapY[p.Id] = 1;
                    }

                }
                bool flag = true;
                foreach (KeyValuePair<int, int> entry in mapX)
                {
                    int num = -1;
                    mapY.TryGetValue(entry.Key, out num);
                    flag &= num == entry.Value;
                }
                return flag;
            }

            public int GetHashCode(List<Predicate> obj)
            {
                return 0;
            }
        }
    }
}