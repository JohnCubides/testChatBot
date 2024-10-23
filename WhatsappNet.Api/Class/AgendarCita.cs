namespace WhatsappNet.Api.Class
{
    public class AgendarCita
    {
        public Parents Parent {  get; set; }
        public Propertie Properties {  get; set; }
        public class Parents
        {
            public string Database_id { get; set; }
        }
        public class Propertie
        {
            public Nombre Nombre {  get; set; }   
            public Horarios Horario {  get; set; }
        }
        public class Horarios
        {
            public Dates Date { get; set; }
        }
        public class Dates
        {
            public string Start {  get; set; }
        }
        public class Nombre
        {
            public List<Titles> Title {  get; set; }
        }
        public class Titles
        {
            public Texts Text { get; set; }
        }
        public class Texts
        {
            public string Content { get; set; }
        }
    }
}
