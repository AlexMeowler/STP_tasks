using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum BinaryOperator
    {
        [Display(Name = "∧ (И)")]
        AND,
        [Display(Name = "∨ (ИЛИ)")]
        OR,
        [Display(Name = "⊕ (ИСКЛЮЧАЮЩЕЕ ИЛИ)")]
        XOR,
        [Display(Name = "→ (ИМПЛИКАЦИЯ)")]
        IMPL,
        [Display(Name = "⇔ (ЭКВИВАЛЕНТНО)")]
        EQUALS
    }

    public enum UnaryOperator
    {
        [Display(Name = "¬ (НЕ)")]
        NOT
    }
    public static class Extensions
    {
        public static string GetNameToDisplay(this BinaryOperator? op)
        {
            string name;
            switch(op)
            {
                case BinaryOperator.AND:
                    name = "∧";
                    break;
                case BinaryOperator.OR:
                    name = "∨";
                    break;
                case BinaryOperator.XOR:
                    name = "⊕";
                    break;
                case BinaryOperator.IMPL:
                    name = "→";
                    break;
                case BinaryOperator.EQUALS:
                    name = "⇔";
                    break;
                default:
                    name = "";
                    break;
            }
            return name;
        }

        public static string GetNameToDisplay(this UnaryOperator? op)
        {
            string name;
            switch (op)
            {
                case UnaryOperator.NOT:
                    name = "¬";
                    break;
                default:
                    name = "";
                    break;
            }
            return name;
        }

        public static BinaryOperator? FromString(string str)
        {
            BinaryOperator? op;
            switch (str)
            {
                case "∧":
                    op = BinaryOperator.AND;
                    break;
                case "∨":
                    op = BinaryOperator.OR;
                    break;
                case "⊕":
                    op = BinaryOperator.XOR;
                    break;
                case "→":
                    op = BinaryOperator.IMPL;
                    break;
                case "⇔":
                    op = BinaryOperator.EQUALS;
                    break;
                default:
                    op = null;
                    break;
            }
            return op;
        }
    }
    public class Operation
    {
        private readonly bool x;
        private readonly bool y;
        private readonly Operation X;
        private readonly Operation Y;
        private UnaryOperator? xU;
        private UnaryOperator? yU;
        private BinaryOperator? op;

        public Operation(UnaryOperator? xU, bool x, UnaryOperator? yU, bool y, BinaryOperator op)
        {
            this.xU = xU;
            this.x = x;
            this.yU = yU;
            this.y = y;
            this.op = op;
        }

        public bool Execute()
        {
            bool result;
            bool x = this.x;
            bool y = this.y;
            if(xU.HasValue)
            {
                switch(xU.Value)
                {
                    case UnaryOperator.NOT:
                        x = !x;
                        break;
                }
            }
            if (yU.HasValue)
            {
                switch (yU.Value)
                {
                    case UnaryOperator.NOT:
                        y = !y;
                        break;
                }
            }
            switch (op)
            {
                case BinaryOperator.AND:
                    result = x && y;
                    break;
                case BinaryOperator.OR:
                    result = x || y;
                    break;
                case BinaryOperator.XOR:
                    result = x ^ y;
                    break;
                case BinaryOperator.IMPL:
                    result = !x || y;
                    break;
                case BinaryOperator.EQUALS:
                    result = x && y || !x && !y;
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}