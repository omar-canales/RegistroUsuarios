using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity.EntRegistro
{
    public class EntPaciente
    {
        public EntPaciente() { }

        public int Id { get; set; }
        public bool Estatus { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int IdSexo { get; set; }

        private EntSexo sexo;
        public EntSexo Sexo
        {
            get 
            {
                if (sexo == null)
                    sexo = new EntSexo();
                return sexo; 
            }
            set  
            {
                if (sexo == null)
                    sexo = new EntSexo();
                sexo = value; 
            }
        }
        
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int IdDelegacion { get; set; }

        private EntDelegacion delegacion;
        public EntDelegacion Delegacion
        {
            get 
            {
                if (delegacion == null)
                    delegacion = new EntDelegacion();
                return delegacion;
            }
            set 
            {
                if (delegacion == null)
                    delegacion = new EntDelegacion();
                delegacion = value;
            }
        }

        public int IdColonia { get; set; }

        private EntColonia colonia;
        public EntColonia Colonia
        {
            get 
            {
                if (colonia == null)
                    colonia = new EntColonia();
                return colonia;
            }
            set 
            {
                if (colonia == null)
                    colonia = new EntColonia();
                colonia = value;
            }
        }

        public string Horario { get; set; }
        public int Edad { get; set; }
        public string Alergia { get; set; }
        public DateTime FechaAlta { get; set; }
        
        
    }
}
