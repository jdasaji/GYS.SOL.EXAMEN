using GYS.SOL.CapaEntidad.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.CapaEntidad.Base
{
    public class ResultadoCE<T>  
    {
        public ResultadoCE()
        {
            if (typeof(T) != typeof(string)
                & typeof(T) != typeof(byte[]))
            {
                this.data = Activator.CreateInstance<T>();
            }

        }
        public enumRespuesta respuesta { get; set; }
        public string mensaje { get; set; }
        public T data{ get; set; }
    }
}
