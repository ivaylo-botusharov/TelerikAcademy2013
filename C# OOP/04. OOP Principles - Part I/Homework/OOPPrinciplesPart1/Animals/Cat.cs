﻿namespace Animals
{
    /// <summary>
    /// Represents cats
    /// </summary>
    public class Cat : Animal
    {
        public Cat(string name, double age, Sex sex) : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Miaou";
        }
    }
}