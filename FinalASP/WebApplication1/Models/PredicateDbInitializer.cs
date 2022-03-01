using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PredicateDbInitializer : DropCreateDatabaseIfModelChanges<PredicateContext>
    {
        protected override void Seed(PredicateContext context)
        {
            context.Predicates.Add(new Predicate
            {
                OperandA = "A",
                OperandB = "B",
                Op = BinaryOperator.IMPL
            });
            context.Predicates.Add(new Predicate
            {
                OperandA = "B",
                OperandB = "C",
                Op = BinaryOperator.IMPL
            });
            context.Predicates.Add(new Predicate
            {
                OperandA = "A",
                OperandB = "C",
                Op = BinaryOperator.IMPL
            });
            context.Predicates.Add(new Predicate
            {
                OpA = UnaryOperator.NOT,
                OperandA = "C",
                OperandB = "B",
                Op = BinaryOperator.EQUALS
            });
            context.Predicates.Add(new Predicate
            {
                OperandA = "A",
                OperandB = "B",
                Op = BinaryOperator.AND
            });
            context.Predicates.Add(new Predicate
            {
                OpA = UnaryOperator.NOT,
                OperandA = "A",
                OpB = UnaryOperator.NOT,
                OperandB = "B",
                Op = BinaryOperator.AND
            });
            base.Seed(context);
        }
    }
}