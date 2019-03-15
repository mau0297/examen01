using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exmane1.Collections
{
    [MetadataType(typeof(EstudianteMetadata))]
    public class Estudiante
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string carne { get; set; }
        public string nombre { get; set; }
        public string carrera { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public IList<Visitas> visitas { get; set; }
    }
    public class EstudianteMetadata
    {
        [Required]
        [DisplayName("Identificador")]
        public object carne { get; set; }

        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres"), MinLength(10,ErrorMessage ="Minimo 10 caracteres")]
        [DisplayName("Nombre")]
        public object nombre { get; set; }

        [DisplayName("Carrera")]
        public object carrera { get; set; }

        [DisplayName("Fecha de nacimiento")]
        public object fecha_nacimiento { get; set; }

        public IList<Visitas> visitas { get; set; }
    }

    public class Visitas
    {
        public DateTime fecha { get; set; }
        public string nombre_biblioteca { get; set; }
        public IList<Ejemplares> ejemplares { get; set; }
    }

    public class Ejemplares
    {
        public int _numero { get; set; }
        public string nombre { get; set; }
        public DateTime devolucion_propuesta { get; set; }
        public DateTime devolucion_real { get; set; }
    }
}