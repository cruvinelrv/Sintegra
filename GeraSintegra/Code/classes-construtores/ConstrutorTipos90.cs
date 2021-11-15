using System;
using System.Collections.Generic;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo90 : IConstrutorTipo
    {
        #region atributos
        long cgc_mf;
        string ie;
        IArquivoMagnetico arq;
        #endregion

        public ConstrutorTipo90(string cgc_mf, string ie, IArquivoMagnetico arq)
        {
            this.arq = arq;
            this.cgc_mf = long.Parse(Functions.SoNumero(cgc_mf));
            this.ie = Functions.SoNumero(ie);

            IList<Tipo90> lsT90 = new List<Tipo90>();

            int tt99 = 3;//10,11,ultimo 90 final
            int tt90 = 1;

            if (arq.countTipo50 > 0)
            {
                tt99 += arq.countTipo50 + 1;//NxT50 + 1xT90
                tt90++;
            }
            if (arq.countTipo51 > 0)
            {
                tt99 += arq.countTipo51 + 1;
                tt90++;
            }
            if (arq.countTipo53 > 0)
            {
                tt99 += arq.countTipo53 + 1;
                tt90++;
            }
            if (arq.countTipo54 > 0)
            {
                tt99 += arq.countTipo54 + 1;
                tt90++;
            }
            if (arq.countTipo55 > 0)
            {
                tt99 += arq.countTipo55 + 1;
                tt90++;
            }
            if (arq.countTipo56 > 0)
            {
                tt99 += arq.countTipo56 + 1;
                tt90++;
            }
            if (arq.countTipo60 > 0)
            {
                tt99 += arq.countTipo60 + 1;
                tt90++;
            }
            if (arq.countTipo75 > 0)
            {
                tt99 += arq.countTipo75 + 1;
                tt90++;
            }

            if (arq.countTipo50 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 50, arq.countTipo50, tt90)
                    );
            if (arq.countTipo51 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 51, arq.countTipo51, tt90)
                    );
            if (arq.countTipo53 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 53, arq.countTipo53, tt90)
                    );
            if (arq.countTipo54 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 54, arq.countTipo54, tt90)
                    );
            if (arq.countTipo55 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 55, arq.countTipo55, tt90)
                    );
            if (arq.countTipo56 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 56, arq.countTipo56, tt90)
                    );
            if (arq.countTipo60 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 60, arq.countTipo60, tt90)
                    );
            if (arq.countTipo75 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 75, arq.countTipo75, tt90)
                    );
            if (arq.countTipo75 > 0)
                lsT90.Add(
                    new Tipo90(this.cgc_mf, this.ie, 99, tt99, tt90)
                    );
            foreach (Tipo90 t90 in lsT90)
                arq.insere(t90);
        }

        public IArquivoMagnetico preenche()
        {
            return arq;
        }

        public Tipo constroi()
        {
            return null;
        }
    }
}