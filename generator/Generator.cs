using System;
using System.Collections.Generic;
using System.Linq;

namespace Algebros.Generator
{
    public interface INode
    {
        bool IsLeaf();
        IEnumerable<INode> GetChildren();
        void SetObscured();
        String AsTeX(bool directlyInsideFraction);
    }

    public class NumberLeaf : INode
    {
        public int Number;
        private bool IsObscured;

        public NumberLeaf(int number)
        {
            Number = number;
            IsObscured = false;
        }

        public override string ToString()
        {
            return IsObscured ? "_" : Number.ToString();
        }

        public bool IsLeaf()
        {
            return true;
        }

        public IEnumerable<INode> GetChildren()
        {
            return new List<INode>();
        }

        public void SetObscured()
        {
            IsObscured = true;
        }

        public string AsTeX(bool directlyInsideFraction)
        {
            return IsObscured ? "x" : Number.ToString();
        }
    }

    public class Equation : INode
    {
        public INode LHS;
        public INode RHS;
        public Operator Operation;
        
        public Equation()
        {
        }

        public Equation( Operator op )
        {
            Operation = op;
        }

        public override string ToString()
        {
            var ans = LHS.ToString() + opString() + RHS.ToString();

            if( Operation != Operator.Equals )
            {
                ans = "(" + ans + ")";
            }

            return ans;
        }

        public bool IsLeaf()
        {
            return false;
        }

        public IEnumerable<INode> GetChildren()
        {
            return new List<INode>() { LHS,RHS };
        }

        public void SetObscured()
        {
            // Do nothing
        }

        public string AsTeX(bool directlyInsideFraction)
        {
            String ans = string.Empty;
            switch (Operation)
            {
                case Operator.Equals:
                    ans = "\\dpi{200}{\\color{White}" + LHS.AsTeX(false) + " \\quad = " + RHS.AsTeX(false) + "}";
                    break;

                case Operator.Multiplication:
                    ans = LHS.AsTeX(false) + " * " + RHS.AsTeX(false);
                    break;

                case Operator.Addition:
                    ans = LHS.AsTeX(false) + " + " + RHS.AsTeX(false);
                    break;
                
                case Operator.Subtraction:
                    ans = LHS.AsTeX(false) + " - " + RHS.AsTeX(false);
                    break;

                case Operator.Division:
                    if( directlyInsideFraction && LHS.IsLeaf() && RHS.IsLeaf() )
                    {
                        ans = LHS.AsTeX(true) + "/" + RHS.AsTeX(true);
                    }
                    else
                    {
                        ans = "\\frac{" + LHS.AsTeX(true) + "}{" + RHS.AsTeX(true) + "}";
                    }
                    break;
            }

            if( Operation != Operator.Equals && !directlyInsideFraction )
            {
                ans = "\\left( " + ans + " \\right)";
            }

            return ans;
        }

        private String opString()
        {
            switch (Operation)
            {
                case Operator.Equals:
                    return "=";
                    break;

                case Operator.Subtraction:
                    return "-";
                    break;

                case Operator.Division:
                    return "/";
                    break;
                    
                case Operator.Multiplication:
                    return "*";
                    break;

                case Operator.Addition:
                    return "+";
                    break;
            }

            return "?";
        }
    }

    public enum Operator
    {
        Subtraction,
        Addition,
        Multiplication,
        Division,
        Equals
    }

    public static class EquationGenerator
    {
        private static Random _rng = new Random();

        public static Equation GenerateRandomEquation( int maxIterations )
        {
            // Figure out what our target number is going to be
            var target = _rng.Next(1, 100);

            // Create a root element for the equation tree structure
            var eqn = new Equation();
            eqn.Operation = Operator.Equals;
            eqn.RHS = new NumberLeaf(target);
            
            // Recursively find a solution to come up with that number
            eqn.LHS = WorkBackwards(0, maxIterations, target);

            return eqn;
        }

        private static INode WorkBackwards(int currentIteration, int maxIterations, int targetNumber)
        {
            // Generate a simple solution to come up with the targetNumber
            var eqn = SimpleSolution(targetNumber);

            // Recurse that bitch!
            if( currentIteration < maxIterations )
            {
                eqn.LHS = WorkBackwards(currentIteration+1, maxIterations, ((NumberLeaf) eqn.LHS).Number);
                eqn.RHS = WorkBackwards(currentIteration+1, maxIterations, ((NumberLeaf) eqn.RHS).Number);
            }

            return eqn;
        }

        private static Equation SimpleSolution(int targetNumber)
        {
            Equation eqn = null;

            // We might not be able to use some operations to reach this target number, list them here
            var excludedOperations = new List<Operator>() {Operator.Equals};

            while (eqn == null)
            {
                // Randomly pick an operation type for this solution
                var op = Enum.GetValues(typeof(Operator)).Cast<Operator>().Where(x => ! excludedOperations.Contains(x)).OrderBy(x => _rng.Next()).FirstOrDefault();
                
                switch (op)
                {
                    case Operator.Subtraction:
                        GenerateSubtractionEquation(targetNumber, out eqn);
                        break;

                    case Operator.Addition:
                        GenerateAdditionEquation(targetNumber, out eqn);
                        break;

                    case Operator.Division:
                        GenerateDivisionEquation(targetNumber, out eqn);
                        break;

                    case Operator.Multiplication:
                        GenerateMultiplicationEquation(targetNumber, out eqn);
                        break;
                }

                // If we got back null from the generator, we can't use this operation type
                // Don't try to run it again - add it to the exclusions list and try again
                if( eqn == null )
                {
                    excludedOperations.Add(op);
                }
            }

            return eqn;
        }

        private static void GenerateMultiplicationEquation(int targetNumber, out Equation eqn)
        {
            eqn = null;
            if( targetNumber < 2 )
            {
                return;
            }

            // We'll try to keep multiplication bits not so taxing, so we'll only allow this
            // if one of the multipliers is <= 20
            int maxMultiplier = 10;
            var start = (targetNumber < maxMultiplier) ? targetNumber - 1 : maxMultiplier;
            
            // Also I'm lazy so ima brute force it. cycles are cheap
            
            for (int i = start; i > 2; i--)
            {
                if( targetNumber % i == 0 )
                {
                    eqn = new Equation(Operator.Multiplication);
                    eqn.LHS = new NumberLeaf(i);
                    eqn.RHS = new NumberLeaf(targetNumber / i); // yeah I know, i know...
                    break;
                }
            }
        }

        private static void GenerateDivisionEquation(int targetNumber, out Equation eqn)
        {
            eqn = null;

            // These are boring problems - let's not make it too easy!
            if( targetNumber < 2 )
            {
                return;
            }
            
            // Keep division simple, only make the person divide by up to 10
            var maxDivision = 10;
            var divisor = _rng.Next(2, maxDivision);

            // Fill out the equation
            eqn = new Equation(Operator.Division);
            eqn.LHS = new NumberLeaf(targetNumber*divisor);
            eqn.RHS = new NumberLeaf(divisor);
        }

        private static void GenerateAdditionEquation(int targetNumber, out Equation eqn)
        {
            eqn =  new Equation(Operator.Addition);

            // Randomly pick a number between 0 and targetNumber
            var theNumber = _rng.Next(0, targetNumber);

            eqn.LHS = new NumberLeaf(theNumber);
            eqn.RHS = new NumberLeaf(targetNumber - theNumber);
        }

        private static void GenerateSubtractionEquation(int targetNumber, out Equation eqn)
        {
            eqn = new Equation(Operator.Subtraction);

            // Pick a number higher than the target
            var range = (targetNumber < 10) ? 10 : 2*targetNumber;

            // Pick a number between targetNumber and range
            var point = _rng.Next(targetNumber, range);

            eqn.LHS = new NumberLeaf(point);
            eqn.RHS = new NumberLeaf(point-targetNumber);

            return;
        }
    }

}
