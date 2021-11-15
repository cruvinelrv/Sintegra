using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Multisoft.SistemaSintegra.Code
{
    /// <summary>
    /// Inscrição Estadual
    /// </summary>

    public class InscrEstadual
    {
        private string mIE;
        private string mUF;

        public const string ISENTO = "ISENTO";
        public const string ESTADOS = "AC AL AP AM BA BA CE DF GO ES MA MG MT MS PA PB PR PE PI RJ RN RS RO RR SP SC SE TO";
        public const string EXTERIOR = "EX";


        public InscrEstadual(string ie, string uf, bool aceitaIsento)
        {
            construtor(ie, uf, aceitaIsento);
        }

        public InscrEstadual(string ie, string uf)
        {
            construtor(ie, uf, false);
        }

        private void construtor(string ie, string uf, bool aceitaIsento)
        {
            if (UF == null)
                uf = "GO";

            uf = uf.ToUpper().Replace(" ", "");
            if (aceitaIsento && ie == ISENTO)
            {
                if (!ESTADOS.Contains(uf) && uf!=EXTERIOR)
                    throw new ExceptionInscrEstadual("Estado Inválido: "+ uf);
            }
            else
            {
                ie = Functions.SoNumero(ie);

                switch (Functions.ValidaIE(ie, uf))
                {
                    case enumValidaIE.OK:
                        break;
                    case enumValidaIE.UFINVALIDA:
                        throw new ExceptionInscrEstadual("Inscrição " + ie + " inválida para " + uf);
                    case enumValidaIE.PARAMETROINVALIDOS:
                        throw new ExceptionInscrEstadual("Parametros inválidos " + ie + " / " + uf);
                    default:
                        throw new ExceptionInscrEstadual("Retorno desconhecido " + ie + " / " + uf);
                }
            }
            this.mIE = ie;
            this.mUF = uf;
        }

        #region Propriedades
        public string IE
        {
            get { return mIE; }
        }
        public string UF
        {
            get { return mUF; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return Functions.SoNumero(this.mIE);
        }
        #endregion


    }
}
