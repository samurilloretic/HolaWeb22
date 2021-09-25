using System.Collections.Generic;
using HolaWeb.App.Dominio;
using System;
using System.Collections;
using System.Linq;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> saludos;
        Saludo saludo;
        public RepositorioSaludosMemoria()
        {
            saludos= new List<Saludo>()
            {
                new Saludo{Id=1,EnEspañol="Buenos Dias",EnIngles="Good Morning",EnItaliano="Bungiorno"},
                new Saludo{Id=2,EnEspañol="Buenas Tardes",EnIngles="Good Afternoon",EnItaliano="Buon pomeriggio"},
                new Saludo{Id=3,EnEspañol="Buenas Noches",EnIngles="Good Evening",EnItaliano="Buona notte"},
                new Saludo{Id=4,EnEspañol="Hora Invalida",EnIngles="Invalid hour",EnItaliano="Tempo no valido"}
            };
        }
        public IEnumerable<Saludo> GetAll()
        {
            return saludos;
        }

        public IEnumerable<Saludo> GetSaludoFiltro(string filtro=null)
        {
            var saludos = GetAll();
            if (saludos!=null)
            {
                if(!String.IsNullOrEmpty(filtro))
                {
                    saludos = saludos.Where(s=>s.EnEspañol.Contains(filtro)|s.EnIngles.Contains(filtro)|s.EnItaliano.Contains(filtro));
                }
            }
            return saludos;
        }

        public Saludo GetSaludoPorId(int Id)
        {
            var saludo = saludos.SingleOrDefault(s=>s.Id==Id);
            return saludo;
        }

        public Saludo GetSaludoPorId(DateTime filtro)
        {
            if (filtro<Convert.ToDateTime("12:00:00"))
            {
                saludo = GetSaludoPorId(1);
            }else if(filtro<Convert.ToDateTime("18:00:00"))
            {
                saludo =GetSaludoPorId(2);
            }else if(filtro<Convert.ToDateTime("23:59:00"))
            {
                saludo =GetSaludoPorId(3);
            }else if(filtro>=Convert.ToDateTime("23:59:00")|filtro>=Convert.ToDateTime("00:00:00"))
            {
                saludo =GetSaludoPorId(4);
            }
            return saludo;
        }
    }
}