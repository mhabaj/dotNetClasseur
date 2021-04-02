﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// SousFamille class, subclass of Famille.
    /// </summary>
    class SousFamille : Famille
    {
        /// <summary>
        /// Famille attribute of the SousFamille class.
        /// </summary>
        public Famille Famille { get; set; }

        /// <summary>
        /// confort constructor of the class.
        /// </summary>
        /// <param name="SousFamName"></param>
        /// <param name="Famille"></param>
        public SousFamille(string SousFamName, Famille Famille) : base(SousFamName)
        {
            this.Famille = Famille;
        }

        /// <summary>
        /// default constructor of the SousFamille class.
        /// </summary>
        public SousFamille()
        {
            this.Famille = new Famille();
        }

        /// <summary>
        /// redefinition of the Equals method to compare two Famille object.
        /// </summary>
        /// <param name="Famille"></param>
        /// <returns></returns>
        public override bool Equals(object Famille)
        {
            return base.Equals(Famille);
        }

        /// <summary>
        /// redefinition of the GetHashCode() method.(autogenerated)
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "..............................." + Famille.ToString();
        }

    }
}
